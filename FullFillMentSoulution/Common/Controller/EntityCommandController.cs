using AutoMapper;
using Common.Cache;
using Common.DTO;
using Common.FileStorage;
using Common.Model;
using Common.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO.Compression;

namespace Common.Controller
{
    public class EntityCommandController<TEntity, TDto> : ControllerBase
    where TEntity : Entity
    where TDto : CudDTO
    {
        private readonly IEntityCommandRepository<TEntity> _commandRepository;
        private readonly IEntityQueryRepository<TEntity> _queryRepository;
        private readonly MemoryModule<TEntity> _memoryModule;
        private readonly IMapper _mapper;
        private readonly ILogger<TEntity> _logger;
        private readonly IFileStorageModule<TEntity> _fileStorageModule;

        public EntityCommandController(IEntityCommandRepository<TEntity> commandRepository, IFileStorageModule<TEntity> fileStorageModule,
            IEntityQueryRepository<TEntity> queryRepository, MemoryModule<TEntity> memoryModule,
            IMapper mapper, ILogger<TEntity> logger)
        {
            _commandRepository = commandRepository;
            _fileStorageModule = fileStorageModule;
            _mapper = mapper;
            _logger = logger;
            _memoryModule = memoryModule;
             _queryRepository= queryRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(TDto dto)
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity>(dto);
                _commandRepository.Add(entity);
                _logger.LogInformation("Entity created successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create entity.");
                return StatusCode(500, "Failed to create entity.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, TDto dto)
        {
            try
            {
                TEntity existingEntity = _queryRepository.Get(id);

                if (existingEntity == null)
                {
                    return NotFound();
                }

                TEntity updatedEntity = _mapper.Map(dto, existingEntity);
                _commandRepository.Update(updatedEntity);
                _memoryModule.SetEntity(id, updatedEntity); // Update cache with updated entity
                _logger.LogInformation("Entity updated successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update entity.");
                return StatusCode(500, "Failed to update entity.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                TEntity existingEntity = _queryRepository.Get(id);

                if (existingEntity == null)
                {
                    return NotFound();
                }

                _commandRepository.Delete(existingEntity);
                _memoryModule.RemoveEntity(id); // Remove entity from cache
                _logger.LogInformation("Entity deleted successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete entity.");
                return StatusCode(500, "Failed to delete entity.");
            }
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file, string entityId)
        {
            try
            {
                TEntity entity = await _queryRepository.GetAsync(entityId);

                if (entity == null)
                {
                    return NotFound();
                }

                string fileName = await _fileStorageModule.UploadFileAsync(entityId, file.FileName, file.OpenReadStream());
                entity.FileUrls.Add(fileName); // List<string> 속성으로 변경된 FileUrls에 파일 경로 추가
                await _commandRepository.UpdateAsync(entity);

                // Update cache with updated entity
                _memoryModule.SetEntity(entityId, entity);

                _logger.LogInformation("File uploaded successfully.");
                return Ok(fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to upload file.");
                return StatusCode(500, "Failed to upload file.");
            }
        }

        [HttpGet("download/{id}/all")]
        public async Task<IActionResult> DownloadAllFiles(string id)
        {
            TEntity entity = await _queryRepository.GetAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            try
            {
                List<string> fileUrls = entity.FileUrls;
                var memoryStream = new MemoryStream();

                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var fileUrl in fileUrls)
                    {
                        Stream fileStream = await _fileStorageModule.DownloadFileAsync(id, fileUrl);
                        var entry = zipArchive.CreateEntry(fileUrl, CompressionLevel.Optimal);

                        using (var entryStream = entry.Open())
                        {
                            await fileStream.CopyToAsync(entryStream);
                        }
                    }
                }

                memoryStream.Position = 0;
                return File(memoryStream, "application/octet-stream", $"{id}_files.zip");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to download files.");
                return StatusCode(500, "Failed to download files.");
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFile(string id)
        {
            TEntity entity = await _queryRepository.GetAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(entity.FileUrlJson))
            {
                return NotFound("No files to delete.");
            }

            try
            {
                List<string> fileUrls = entity.FileUrls;
                foreach (var fileUrl in fileUrls)
                {
                    await _fileStorageModule.DeleteFileAsync(id, fileUrl);
                }

                entity.FileUrlJson = null;
                await _commandRepository.UpdateAsync(entity);

                // Update cache with updated entity
                _memoryModule.SetEntity(id, entity);

                _logger.LogInformation("All files deleted successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete files.");
                return StatusCode(500, "Failed to delete files.");
            }
        }

        [HttpDelete("delete/{id}/{fileName}")]
        public async Task<IActionResult> DeleteSpecificFile(string id, string fileName)
        {
            TEntity entity = await _queryRepository.GetAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(entity.FileUrlJson))
            {
                return NotFound("No files to delete.");
            }

            try
            {
                if (entity.FileUrls.Contains(fileName))
                {
                    await _fileStorageModule.DeleteFileAsync(id, fileName);
                    entity.FileUrls.Remove(fileName);
                    await _commandRepository.UpdateAsync(entity);
                    // Update cache with updated entity
                    _memoryModule.SetEntity(id, entity);
                    _logger.LogInformation($"File '{fileName}' deleted successfully.");
                    return NoContent();
                }
                else
                {
                    return NotFound("File not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete file.");
                return StatusCode(500, "Failed to delete file.");
            }
        }
    }
}

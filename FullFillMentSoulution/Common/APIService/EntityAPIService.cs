using Common.DTO;
using Common.Model;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Common.APIService
{
    public interface IEntityCommandAPIService<TEntity, TDto>
    where TEntity : Entity
    where TDto : CudDTO
    {
        Task Create(TDto dto);
        Task Update(string id, TDto dto);
        Task Delete(string id);
        Task<string> UploadFile(string entityId, Stream fileStream, string fileName);
        Task DeleteFile(string id);
        Task DeleteSpecificFile(string id, string fileName);
    }
    public class EntityCommandAPIService<TEntity, TDto> : JwtTokenAPIService, IEntityCommandAPIService<TEntity, TDto>
        where TEntity : Entity
        where TDto : CudDTO
    {
        public EntityCommandAPIService(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task Create(TDto dto)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"api/{typeof(TEntity).Name}", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(string id, TDto dto)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/{typeof(TEntity).Name}/{id}", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(string id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/{typeof(TEntity).Name}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<string> UploadFile(string entityId, Stream fileStream, string fileName)
        {
            var formContent = new MultipartFormDataContent
            {
                { new StreamContent(fileStream), "file", fileName }
            };

            HttpResponseMessage response = await _httpClient.PostAsync($"api/{typeof(TEntity).Name}/uploadFile?entityId={entityId}", formContent);
            response.EnsureSuccessStatusCode();

            string fileNameResponse = await response.Content.ReadAsStringAsync();
            return fileNameResponse;
        }

        public async Task DeleteFile(string id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/{typeof(TEntity).Name}/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSpecificFile(string id, string fileName)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/{typeof(TEntity).Name}/delete/{id}/{fileName}");
            response.EnsureSuccessStatusCode();
        }
    }
    public interface IEntityQueryAPIService<TEntity, TDto>
        where TEntity : Entity
        where TDto : ReadDto
    {
        Task<TDto> GetById(string id);
        Task<List<TDto>> GetAll();
        Task<Stream> DownloadFile(string id, string fileName);
    }
    public class EntityQueryAPIService<TEntity, TDto> : JwtTokenAPIService, IEntityQueryAPIService<TEntity, TDto>
    where TEntity : Entity
    where TDto : ReadDto
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public EntityQueryAPIService(HttpClient httpClient)
            : base(httpClient)
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        public async Task<TDto> GetById(string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/{typeof(TEntity).Name}/{id}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            TDto dto = JsonSerializer.Deserialize<TDto>(json, _jsonSerializerOptions);
            return dto;
        }

        public async Task<List<TDto>> GetAll()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/{typeof(TEntity).Name}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<TDto> dtos = JsonSerializer.Deserialize<List<TDto>>(json, _jsonSerializerOptions);
            return dtos;
        }

        public async Task<Stream> DownloadFile(string id, string fileName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/{typeof(TEntity).Name}/download/{id}/{fileName}");
            response.EnsureSuccessStatusCode();

            Stream fileStream = await response.Content.ReadAsStreamAsync();
            return fileStream;
        }
    }
}

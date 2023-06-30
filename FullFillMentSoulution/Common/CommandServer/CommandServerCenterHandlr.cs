using AutoMapper;
using Common.DTO;
using Common.DTO.Interface;
using Common.ForCommand;
using Common.GateWay;
using Common.Model;
using Common.Model.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Common.CommandServer
{
    public class CommandServerCenterHandlr<TDTO, TCenter> : CommandServerHandlerBase<TDTO, TCenter>
        where TDTO : CudDTO where TCenter : Center
    {
        public CommandServerCenterHandlr(
            GateWayCommandContext gateContext, 
            EntityRepository<TCenter> commandRepository, 
            IQueryServerConfiguringServcie queConfigurationService, 
            IQueSelectedService queSelectedService, 
            IMapper mapper, IConfiguration configuration, 
            IWebHostEnvironment webHostEnvironment) 
            : base(gateContext, commandRepository, queConfigurationService, 
                  queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }
        public override async Task<TDTO?> Handle(CudCommand<TDTO> cudCommand)
        {
            TDTO dto = cudCommand.t;
            var entity = _mapper.Map<TCenter>(cudCommand.t);
            if (dto is ICreateDTO && entity is TCenter)
            {
                if (entity != null)
                {
                    await _commandRepository.AddAsync(entity);
                    await _commandRepository.SaveChangesAsync();
                    var result = _mapper.Map<TDTO>(entity);
                    return result;
                }
                return null;
            }
            else if (dto is IUpdateDTO updateDto && entity is TCenter)
            {
                entity = await _commandRepository.GetAsync(dto.Id);
                if (entity != null)
                {
                    _mapper.Map(updateDto, entity);
                    await _commandRepository.UpdateAsync(entity);
                    await _commandRepository.SaveChangesAsync();
                    var result = _mapper.Map<TDTO>(entity);
                    return result;
                }
                return null;
            }
            else if (dto is IDeleteDTO deleteDto && entity is TCenter)
            {
                entity = await _commandRepository.GetAsync(dto.Id);
                if (entity != null)
                {
                    _commandRepository.Delete(entity.Id);
                    await _commandRepository.SaveChangesAsync();
                    var result = _mapper.Map<TDTO>(entity);
                    return result;
                }
                return null;
            }
            return null;
        }
    }
}

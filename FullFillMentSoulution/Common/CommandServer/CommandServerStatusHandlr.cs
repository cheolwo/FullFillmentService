using AutoMapper;
using Common.DTO;
using Common.ForCommand;
using Common.GateWay;
using Common.Model.Repository;
using Common.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Common.DTO.Interface;

namespace Common.CommandServer
{
    public class CommandServerStatusHandlr<TDTO, TStatus> : CommandServerHandlerBase<TDTO, TStatus>
    where TDTO : CudDTO
    where TStatus : Status
    {
        public CommandServerStatusHandlr(
            GateWayCommandContext gateContext,
            EntityRepository<TStatus> commandRepository,
            IQueryServerConfiguringServcie queConfigurationService,
            IQueSelectedService queSelectedService,
            IMapper mapper,
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment)
            : base(gateContext, commandRepository, queConfigurationService, queSelectedService, mapper, configuration, webHostEnvironment)
        {
        }

        public override async Task<TDTO?> Handle(CudCommand<TDTO> cudCommand)
        {
            TDTO dto = cudCommand.t;
            var status = _mapper.Map<TStatus>(cudCommand.t);

            if (dto is ICreateDTO && status is TStatus)
            {
                if (status != null)
                {
                    await _commandRepository.AddAsync(status);
                    await _commandRepository.SaveChangesAsync();
                    var result = _mapper.Map<TDTO>(status);
                    return result;
                }
                return null;
            }
            else if (dto is IUpdateDTO updateDto && status is TStatus)
            {
                status = await _commandRepository.GetAsync(dto.Id);
                if (status != null)
                {
                    _mapper.Map(updateDto, status);
                    await _commandRepository.UpdateAsync(status);
                    await _commandRepository.SaveChangesAsync();
                    var result = _mapper.Map<TDTO>(status);
                    return result;
                }
                return null;
            }
            else if (dto is IDeleteDTO && status is TStatus)
            {
                status = await _commandRepository.GetAsync(dto.Id);
                if (status != null)
                {
                    _commandRepository.Delete(status.Id);
                    await _commandRepository.SaveChangesAsync();
                    var result = _mapper.Map<TDTO>(status);
                    return result;
                }
                return null;
            }

            return null;
        }
    }
}

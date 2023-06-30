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
    public class CommandServerCommodityHandlr<TDTO, TCommodity> : CommandServerHandlerBase<TDTO, TCommodity>
    where TDTO : CudDTO
    where TCommodity : Commodity
    {
        public CommandServerCommodityHandlr(
            GateWayCommandContext gateContext,
            EntityRepository<TCommodity> commandRepository,
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
            var commodity = _mapper.Map<TCommodity>(cudCommand.t);

            if (dto is ICreateDTO && commodity is TCommodity)
            {
                if (commodity != null)
                {
                    await _commandRepository.AddAsync(commodity);
                    await _commandRepository.SaveChangesAsync();
                    var result = _mapper.Map<TDTO>(commodity);
                    return result;
                }
                return null;
            }
            else if (dto is IUpdateDTO updateDto && commodity is TCommodity)
            {
                commodity = await _commandRepository.GetAsync(dto.Id);
                if (commodity != null)
                {
                    _mapper.Map(updateDto, commodity);
                    await _commandRepository.UpdateAsync(commodity);
                    await _commandRepository.SaveChangesAsync();
                    var result = _mapper.Map<TDTO>(commodity);
                    return result;
                }
                return null;
            }
            else if (dto is IDeleteDTO deleteDto && commodity is TCommodity)
            {
                commodity = await _commandRepository.GetAsync(dto.Id);
                if (commodity != null)
                {
                    _commandRepository.Delete(commodity.Id);
                    await _commandRepository.SaveChangesAsync();
                    var result = _mapper.Map<TDTO>(commodity);
                    return result;
                }
                return null;
            }

            return null;
        }
    }
}

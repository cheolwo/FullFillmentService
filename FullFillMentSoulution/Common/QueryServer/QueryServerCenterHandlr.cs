﻿using AutoMapper;
using Common.Cache;
using Common.DTO;
using Common.Extensions;
using Common.ForCommand;
using Common.GateWay;
using Common.Model;
using Microsoft.AspNetCore.Hosting;
using 계정Common.Extensions;

namespace Common.QueryServer
{
    public class QueryServerCenterHandlr<TDTO, TCenter> : QueryServerHandlr<TDTO, TCenter> where TDTO : CudDTO where TCenter : Center
    {
        public QueryServerCenterHandlr(
            ICommandServerConfiguringService commandServerConfiguringService, 
            IWebHostEnvironment webHostEnvironment, 
            IQueSelectedService queSelectedService, 
            IMapper mapper, 
            EntityMemoryModule centerMemoryModule, GateWayQueryContext gateContext) 
            : base(commandServerConfiguringService, webHostEnvironment, queSelectedService, mapper, centerMemoryModule, gateContext)
        {
        }
        public async Task Handle(CudCommand<TDTO> cudCommand)
        {
            if (cudCommand.JwtToken != null)
            {
                var entity = _mapper.Map<TCenter>(cudCommand.t);
                if (entity is TCenter center)
                {
                    var cacheKey = cudCommand.JwtToken.GetUserIdFromToken().GenerateCacheKey<TCenter>(entity.Id);
                    _centerMemoryModule.SetCenter(cacheKey, center);
                    await Task.CompletedTask;
                }
            }
        }
    }
    public class QueryServerCommodityHandlr<TDTO, TCommodity, TCenter> : QueryServerHandlr<TDTO, TCommodity> 
        where TDTO : CudDTO where TCenter : Center where TCommodity : Commodity
    {
        public QueryServerCommodityHandlr(
            ICommandServerConfiguringService commandServerConfiguringService, 
            IWebHostEnvironment webHostEnvironment, 
            IQueSelectedService queSelectedService, 
            IMapper mapper, 
            EntityMemoryModule centerMemoryModule, GateWayQueryContext gateContext) 
            : base(commandServerConfiguringService, webHostEnvironment, queSelectedService, mapper, centerMemoryModule, gateContext)
        {
        }
        public async Task Handle(CudCommand<TDTO> cudCommand)
        {
            var entity = _mapper.Map<TCommodity>(cudCommand.t);
            if (cudCommand.JwtToken != null && entity.CenterId != null)
            {
                if (entity is TCommodity commodity)
                {
                    var cacheKey = cudCommand.JwtToken.GetUserIdFromToken().GenerateCacheKey<TCommodity>(commodity.CenterId);
                    _centerMemoryModule.SetCommodity<TCommodity, TCenter>(cacheKey, commodity); // Cache Key Related Center Key
                    await Task.CompletedTask;
                }
            }
        }
    }
    public class QueryServerStatusHandlr<TDTO, TStatus, TCenter> : QueryServerHandlr<TDTO, TStatus>
        where TDTO : CudDTO where TCenter : Center where TStatus : Status
    {
        public QueryServerStatusHandlr(
            ICommandServerConfiguringService commandServerConfiguringService, 
            IWebHostEnvironment webHostEnvironment, 
            IQueSelectedService queSelectedService, 
            IMapper mapper, 
            EntityMemoryModule centerMemoryModule, GateWayQueryContext gateContext) 
            : base(commandServerConfiguringService, webHostEnvironment, queSelectedService, mapper, centerMemoryModule, gateContext)
        {
        }
        public async Task Handle(CudCommand<TDTO> cudCommand)
        {
            var entity = _mapper.Map<TStatus>(cudCommand.t);
            if (cudCommand.JwtToken != null && entity.CenterId != null)
            {
                if (entity is TStatus status)
                {
                    var cacheKey = cudCommand.JwtToken.GetUserIdFromToken().GenerateCacheKey<TStatus>(status.CenterId);
                    _centerMemoryModule.SetStatus<TStatus, TCenter>(cacheKey, status); // Cache Key Related Center Key
                    await Task.CompletedTask;
                }
            }
        }
    }
}

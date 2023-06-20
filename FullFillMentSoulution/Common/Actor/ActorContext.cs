﻿using Common.Actor;
using Common.Actor.Builder;
using Common.Actor.Builder.TypeBuilder;

namespace FrontCommon.Actor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CQRSAttribute : Attribute
    {
        public bool IsEnabled { get; }

        public CQRSAttribute(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }
        public CQRSAttribute()
        {

        }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DistributedAttribute : Attribute
    {
        public bool IsEnabled { get; }

        public DistributedAttribute(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }
        public DistributedAttribute() 
        {
        }
    }
    public class ActorContextOptions
    {
        public string? ApiGateWayServerReoute { get; set; }
        // 추가적인 옵션들...
    }
    public class ActorQueryContextOptions : ActorContextOptions { }
    public interface IDtoConfiguration<TDto> where TDto : class
    {
        void Configure(DtoTypeBuilder<TDto> builder);
    }
    public interface IDtoTypeCommandConfiguration<TDto> : IDtoConfiguration<TDto> where TDto : class
    {
        void Configure(DtoTypeCommandBuilder<TDto> builder);
    }
    public interface IDtoTypeQueryConfiguration<TDto> : IDtoConfiguration<TDto> where TDto : class
    {
        void Configure(DtoTypeQueryBuilder<TDto> builder);
    }
    public abstract class ActorContext
    {
        protected ActorContextOptions _options { get; }
        public ActorContext(ActorContextOptions options)
        {
            _options = options;
        }
    }
    public class ServerBaseRouteInfo
    {
        public string Route { get; set; }
        public string BaseAddress { get; set; }
        public bool UseApiGateway { get; set; }
    }
}

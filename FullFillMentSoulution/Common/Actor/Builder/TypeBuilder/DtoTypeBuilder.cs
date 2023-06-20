using FrontCommon.Actor;

namespace Common.Actor.Builder
{
    public class DtoTypeBuilder<TDto> where TDto : class
    {
        protected List<ServerBaseRouteInfo> ServerBaseRoutes { get; } = new List<ServerBaseRouteInfo>();
        public DtoTypeBuilder<TDto> SetServerBaseRouteInfo(ServerBaseRouteInfo info)
        {
            ServerBaseRoutes.Add(info);
            return this;
        }
    }
}

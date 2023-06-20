using Microsoft.Extensions.DependencyInjection;

namespace FrontCommon.Actor
{
    public static class ActorContextExtensions
    {
        public static IServiceCollection AddActorContext<TActorContext>(
                                this IServiceCollection services, 
                                Action<ActorContextOptions> configureOptions)
        where TActorContext : ActorContext
        {
            // ActorContextOptions 객체 생성 및 구성
            var options = new ActorContextOptions();
            configureOptions(options);

            // ActorContext 등록
            services.AddScoped(provider =>
            {
                return (TActorContext)ActivatorUtilities.CreateInstance(provider, typeof(TActorContext), options);
            });

            return services;
        }
        public static IServiceCollection AddActorContext<TActorContext>(this IServiceCollection services)
        where TActorContext : ActorContext
        {
            var options = new ActorContextOptions();
            // ActorContext 등록
            services.AddScoped(provider =>
            {
                return (TActorContext)ActivatorUtilities.CreateInstance(provider, typeof(TActorContext));
            });

            return services;
        }
    }
}

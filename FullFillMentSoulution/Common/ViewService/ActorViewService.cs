using Common.Actor;
using FrontCommon.Actor;

namespace Common.ViewService
{
    public interface IActorCommandViewService
    {
        Task Post<T>(T t, string jwtToken) where T : class;
        Task Delete<T>(string id, string jwtToken) where T : class;
        Task Update<T>(T t, string jwtToken) where T : class;
    }
    public interface IActorQueryViewService
    {
        Task<List<T>?> GetToListAsync<T>(string userId, string jwtToken) where T : class;
    }
    public class ActorViewService : IActorCommandViewService, IActorQueryViewService
    {
        protected readonly ActorCommandContext _commandContext;
        protected readonly ActorQueryContext _querytContext;
        public ActorViewService(ActorCommandContext commandContext, ActorQueryContext queryContext)
        {
            _commandContext = commandContext;
            _querytContext = queryContext;
        }

        public async Task Delete<T>(string id, string jwtToken) where T : class
        {
            await _commandContext.Set<T>().DeleteAsync(id, jwtToken);
        }
        public async Task<List<T>?> GetToListAsync<T>(string userId, string jwtToken) where T : class
        {
            return await _querytContext.Set<T>().GetToListAsync(userId, jwtToken);
        }
        public async Task Post<T>(T t, string jwtToken) where T : class
        {
            await _commandContext.Set<T>().PostAsync(t, jwtToken);
        }
        public async Task Update<T>(T t, string jwtToken) where T : class
        {
            await _commandContext.Set<T>().PutAsync(t, jwtToken);
        }
    }
}

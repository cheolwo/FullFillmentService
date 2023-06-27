using Common.Actor;
using FrontCommon.Actor;

namespace Common.ViewService
{
    public interface IActorCommandViewService<T> where T : class
    {
        Task Post(T t, string jwtToken);
        Task Delete(string id, string jwtToken);
        Task Update(T t, string jwtToken);
    }
    public interface IActorQueryViewService<T> where T : class
    {
        Task<List<T>?> GetToListAsync(string userId, string jwtToken);
    }
    public class ActorViewService
    {
        protected readonly ActorCommandContext _commandContext;
        protected readonly ActorQueryContext _querytContext;
        public ActorViewService(ActorCommandContext commandContext, ActorQueryContext queryContext)
        {
            _commandContext = commandContext;
            _querytContext = queryContext;   
        }

        public async Task Delete<T>(string id, string jwtToken) where T: class
        {
            await _commandContext.Set<T>().DeleteAsync(id, jwtToken);
        }
        public async Task<List<T>?> GetToListAsync<T>(string userId, string jwtToken) where T: class
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

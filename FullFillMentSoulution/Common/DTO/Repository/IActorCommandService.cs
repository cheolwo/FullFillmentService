using FrontCommon.Actor;

namespace Common.DTO.Repository
{
    public interface IActorCommandRepository<T> where T : class
    {
        Task<HttpResponseMessage> AddAsync(T item);
        Task<HttpResponseMessage> DeleteAsync(string id);
        Task<HttpResponseMessage> UpdateAsync(T item);

        Task<HttpResponseMessage> AddAsync(T item, string userId, string token);
        Task<HttpResponseMessage> DeleteAsync(string id, string userId, string token);
        Task<HttpResponseMessage> UpdateAsync(T item, string userId, string token);
    }
    public class ActorCommandService<TDto> : IActorCommandRepository<TDto> where TDto : class
    {
        private readonly ActorCommandContext _context;
        public ActorCommandService(ActorCommandContext context)
        {
            _context = context;
        }

        public async Task<HttpResponseMessage> AddAsync(TDto item)
        {
            return await _context.Set<TDto>().PostAsync(item);
        }

        public async Task<HttpResponseMessage> AddAsync(TDto item, string userId, string token)
        {
            return await _context.Set<TDto>().PostAsync(item, userId, token);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string id)
        {
            return await _context.Set<TDto>().DeleteAsync(id);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string id, string userId, string token)
        {
            return await _context.Set<TDto>().DeleteAsync(id, userId, token);
        }

        public async Task<HttpResponseMessage> UpdateAsync(TDto item)
        {
            return await _context.Set<TDto>().PutAsync(item);
        }

        public async Task<HttpResponseMessage> UpdateAsync(TDto item, string userId, string token)
        {
            return await _context.Set<TDto>().PutAsync(item, userId, token);
        }
    }
}

using FrontCommon.Actor;
using Microsoft.JSInterop;

namespace Common.DTO.Repository
{
    public interface IActorCommandRepository<T> where T : class
    {
        Task<HttpResponseMessage> AddAsync(T item);
        Task<HttpResponseMessage> DeleteAsync(string id);
        Task<HttpResponseMessage> UpdateAsync(T item);
    }
    public class ActorCommandService<TDto> : IActorCommandRepository<TDto> where TDto : class
    {
        protected readonly ActorCommandContext _context;
        public ActorCommandService(ActorCommandContext context)
        {
            _context = context;
        }

        public virtual async Task<HttpResponseMessage> AddAsync(TDto item)
        {
            return await _context.Set<TDto>().PostAsync(item);
        }
        public virtual async Task<HttpResponseMessage> DeleteAsync(string id)
        {
            return await _context.Set<TDto>().DeleteAsync(id);
        }
        public virtual async Task<HttpResponseMessage> UpdateAsync(TDto item)
        {
            return await _context.Set<TDto>().PutAsync(item);
        }
    }
    public class WebActorCommandService<TDto> : ActorCommandService<TDto> where TDto : class 
    {
        protected readonly IJSRuntime _jsRuntime;
        protected string _token;
        public WebActorCommandService(ActorCommandContext actorCommandContext, IJSRuntime jSRuntime)
            :base(actorCommandContext)
        {
            _jsRuntime = jSRuntime;
        }
        private async Task SetAuth()
        {
            _token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
        }
        public override async Task<HttpResponseMessage> AddAsync(TDto item)
        {
            await SetAuth();
            return await _context.Set<TDto>().PostAsync(item, _token);
        }
        public override async Task<HttpResponseMessage> DeleteAsync(string id)
        {
            await SetAuth(); 
            return await _context.Set<TDto>().DeleteAsync(id, _token);
        }
        public override async Task<HttpResponseMessage> UpdateAsync(TDto item)
        {
            await SetAuth();
            return await _context.Set<TDto>().PutAsync(item, _token);
        }
    }
}

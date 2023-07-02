using Common.Actor;
using Common.DTO;
using Common.ViewService;
using FrontCommon.Actor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Common.ViewModel
{
    public class ActorWebPageViewModel : WebViewModel
    {
        public ActorWebPageViewModel(
            ActorCommandContext commandContext, ActorQueryContext queryContext
            , ITokenStorage tokenStoage) :
            base(commandContext, queryContext, tokenStoage)
        {
        }
        public virtual async Task<string> GetTokenAsync()
        {
            return await _tokenStorage.GetToken();
        }
        public async Task Delete<T>(string id) where T : class
        {
            var token = await GetTokenAsync();
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            await _actorCommandContext.Set<T>().DeleteAsync(id, token);
        }
        public async Task<List<T>?> GetToListAsync<T>() where T : class
        {
            var token = await GetTokenAsync();
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            return await _actorQueryContext.Set<T>().GetToListAsync(token);
        }
        public async Task Post<T>(T t) where T : class
        {
            var token = await GetTokenAsync();
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            await _actorCommandContext.Set<T>().PostAsync(t, token);
        }
        public async Task Update<T>(T t) where T : class
        {
            var token = await GetTokenAsync();
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            await _actorCommandContext.Set<T>().PutAsync(t, token);
        }
    }
}

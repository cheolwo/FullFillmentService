using System.Net.Http.Headers;

namespace 계정Common.API
{
    public class JwtTokenAPIService
    {
        protected string _token;
        protected readonly HttpClient _httpClient;
        public JwtTokenAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public void SetBearerToken(string token)
        {
            _token = token; 
        }

        protected void ReadyBearerToken()
        {
            if (string.IsNullOrEmpty(_token))
                throw new InvalidOperationException("Token not set. Call SetBearerToken method before making requests.");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }
    }
}

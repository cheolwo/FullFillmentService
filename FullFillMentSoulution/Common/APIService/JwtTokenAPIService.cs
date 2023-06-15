using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.APIService
{
    public interface IJwtTokenAPIService
    {
        void SetBearerToken(string token);
        void ReadyBearerToken();
    }
    public class JwtTokenAPIService
    {
        protected string _token;
        protected HttpClient _httpClient;
        public JwtTokenAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public void SetBearerToken(string token)
        {
            _token = token;
            ReadyBearerToken();
        }
        private void ReadyBearerToken()
        {
            if (string.IsNullOrEmpty(_token))
                throw new InvalidOperationException("Token not set. Call SetBearerToken method before making requests.");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }
    }
}

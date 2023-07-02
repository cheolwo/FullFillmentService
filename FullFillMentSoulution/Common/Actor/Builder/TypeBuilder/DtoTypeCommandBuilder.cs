using FluentValidation;
using FrontCommon.Actor;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Common.Actor.Builder
{
    public class DtoTypeCommandBuilder<TDto> : DtoTypeBuilder<TDto> where TDto : class
    {
        protected IValidator<TDto> Validator { get; private set; }
        protected string Route { get; private set; }
        protected string BaseAddress { get; private set; }

        public DtoTypeCommandBuilder(IDtoTypeCommandConfiguration<TDto> configuration)
        {
            configuration.Configure(this);
        }
        public DtoTypeCommandBuilder<TDto> SetServerBaseAddress(string baseAddress)
        {
            this.Route = baseAddress;
            return this;
        }

        public DtoTypeCommandBuilder<TDto> SetValidator(IValidator<TDto> validator)
        {
            Validator = validator;
            return this;
        }
        public IValidator<TDto> GetValidator()
        {
            return Validator;
        }
        public DtoTypeCommandBuilder<TDto> SetRoute(string route)
        {
            Route = route;
            return this;
        }

        public DtoTypeCommandBuilder<TDto> ApplyConfiguration(IDtoTypeCommandConfiguration<TDto> configuration)
        {
            configuration.Configure(this);
            return this;
        }
        /// <summary>
        /// _ActorContext.Set<TDto>().PostAsync(dto, jwtToken);
        /// </summary>
        public async Task<HttpResponseMessage> PostAsync(TDto dto, string jwtToken)
        {
            var selectedRoute = GetSelectedBaseRoute(dto);
            if (Validator != null)
            {
                var validationResult = await Validator.ValidateAsync(dto);
                if (!validationResult.IsValid)
                {
                    throw new Exception("DTO validation failed: " + string.Join(", ", validationResult.Errors));
                }
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(selectedRoute.BaseAddress);

                // Set Authorization header with JWT token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                var jsonContent = JsonConvert.SerializeObject(dto);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                return await httpClient.PostAsync(selectedRoute.Route, httpContent);
            }
        }
        public async Task<HttpResponseMessage> PostAsync(TDto dto)
        {
            var selectedRoute = GetSelectedBaseRoute(dto);
            if (Validator != null)
            {
                var validationResult = await Validator.ValidateAsync(dto);
                if (!validationResult.IsValid)
                {
                    throw new Exception("DTO validation failed: " + string.Join(", ", validationResult.Errors));
                }
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(selectedRoute.BaseAddress);
                var jsonContent = JsonConvert.SerializeObject(dto);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                return await httpClient.PostAsync(selectedRoute.Route, httpContent);
            }
        }
        public async Task<HttpResponseMessage> PutAsync(TDto dto, string jwtToken)
        {
            var selectedRoute = GetSelectedBaseRoute(dto);
            if (Validator != null)
            {
                var validationResult = await Validator.ValidateAsync(dto);
                if (!validationResult.IsValid)
                {
                    throw new Exception("DTO validation failed: " + string.Join(", ", validationResult.Errors));
                }
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(selectedRoute.BaseAddress);

                // Set Authorization header with JWT token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                var jsonContent = JsonConvert.SerializeObject(dto);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                return await httpClient.PutAsync(selectedRoute.BaseAddress, httpContent);
            }
        }
        public async Task<HttpResponseMessage> PutAsync(TDto dto)
        {
            var selectedRoute = GetSelectedBaseRoute(dto);
            if (Validator != null)
            {
                var validationResult = await Validator.ValidateAsync(dto);
                if (!validationResult.IsValid)
                {
                    throw new Exception("DTO validation failed: " + string.Join(", ", validationResult.Errors));
                }
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(selectedRoute.BaseAddress);;
                var jsonContent = JsonConvert.SerializeObject(dto);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                return await httpClient.PutAsync(selectedRoute.BaseAddress, httpContent);
            }
        }
        public async Task<HttpResponseMessage> DeleteAsync(string id, string jwtToken)
        {
            var selectedRoute = GetSelectedBaseRoute(null);
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(selectedRoute.BaseAddress);

                // Set Authorization header with JWT token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                return await httpClient.DeleteAsync($"{selectedRoute.Route}/{id}");
            }
        }
        public async Task<HttpResponseMessage> DeleteAsync(string id)
        {
            var selectedRoute = GetSelectedBaseRoute(null);
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(selectedRoute.BaseAddress);
                return await httpClient.DeleteAsync($"{selectedRoute.Route}/{id}");
            }
        }
        private bool IsApiGatewayCompatible(TDto dto)
        {
            var cqsAttribute = dto.GetType().GetCustomAttribute<CQRSAttribute>();
            return cqsAttribute != null && cqsAttribute.IsEnabled;
        }
        private ServerBaseRouteInfo GetSelectedBaseRoute(TDto dto)
        {
            var IsCqrs = IsApiGatewayCompatible(dto);
            if (IsCqrs)
            {
                // DTO에 CQRS 특성이 있고 활성화된 경우 API Gateway를 사용하는 서버 선택
                var selectedRoute = ServerBaseRoutes.FirstOrDefault(route => route.UseApiGateway);
                if (selectedRoute != null)
                {
                    return selectedRoute;
                }
            }

            // CQRS 특성이 없거나 비활성화된 경우 비즈니스 서버 선택
            var defaultRoute = ServerBaseRoutes.FirstOrDefault();
            if (defaultRoute != null)
            {
                return defaultRoute;
            }

            throw new Exception("No serve base route available.");
        }

        private async Task SendRequestToApiGateway(HttpClient httpClient, string route, HttpContent httpContent, HttpMethod httpMethod)
        {
            // API Gateway로 요청을 보내는 로직을 구현
            // 필요한 경우 인증 토큰 등을 추가하고 요청을 보낸 후 처리
            var request = new HttpRequestMessage(httpMethod, route);
            if (httpContent != null)
            {
                request.Content = httpContent;
            }

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        private async Task SendRequestToBusinessServer(HttpClient httpClient, string route, HttpContent httpContent, HttpMethod httpMethod)
        {
            // 비즈니스 처리 서버로 직접 요청을 보내는 로직을 구현
            // 필요한 경우 인증 토큰 등을 추가하고 요청을 보낸 후 처리
            var request = new HttpRequestMessage(httpMethod, route);
            if (httpContent != null)
            {
                request.Content = httpContent;
            }

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        private async Task<T> SendRequestToApiGateway<T>(HttpClient httpClient, string route, HttpContent httpContent, HttpMethod httpMethod)
        {
            // API Gateway로 요청을 보내는 로직을 구현
            // 필요한 경우 인증 토큰 등을 추가하고 요청을 보낸 후 처리
            var request = new HttpRequestMessage(httpMethod, route);
            if (httpContent != null)
            {
                request.Content = httpContent;
            }

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        private async Task<T> SendRequestToBusinessServer<T>(HttpClient httpClient, string route, HttpContent httpContent, HttpMethod httpMethod)
        {
            // 비즈니스 처리 서버로 직접 요청을 보내는 로직을 구현
            // 필요한 경우 인증 토큰 등을 추가하고 요청을 보낸 후 처리
            var request = new HttpRequestMessage(httpMethod, route);
            if (httpContent != null)
            {
                request.Content = httpContent;
            }

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

    }
}

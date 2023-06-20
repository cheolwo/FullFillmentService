using FluentValidation;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace FrontCommon.Actor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CQRSAttribute : Attribute
    {
        public bool IsEnabled { get; }

        public CQRSAttribute(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }
    }
    public class ActorContextOptions
    {
        public bool UseApiGateway { get; set; }
        public string ApiGatewayUrl { get; set; }
        public string BusinessServerUrl { get; set; }
        // 추가적인 옵션들...
    }

    public abstract class ActorContext
    {
        protected DtoBuilder DtoBuilder { get; }

        protected ActorContext(ActorContextOptions options)
        {
            DtoBuilder = new DtoBuilder(options);
            OnModelCreating(DtoBuilder);
        }

        protected abstract void OnModelCreating(DtoBuilder dtoBuilder);
        protected DtoTypeBuilder<TDto> Set<TDto>() where TDto : class
        {
            return DtoBuilder.Set<TDto>();
        }
    }
    public class DtoBuilder
    {
        private readonly ActorContextOptions _options;
        private readonly Dictionary<Type, object> _configurations;

        public DtoBuilder(ActorContextOptions options)
        {
            _options = options;
            _configurations = new Dictionary<Type, object>();
        }

        public void ApplyConfiguration<TDto>(IDtoConfiguration<TDto> configuration) where TDto : class
        {
            _configurations[typeof(TDto)] = configuration;
        }

        public DtoTypeBuilder<TDto> Set<TDto>() where TDto : class
        {
            return new DtoTypeBuilder<TDto>(_configurations.ContainsKey(typeof(TDto)) ? (IDtoConfiguration<TDto>)_configurations[typeof(TDto)] : null);
        }
    }
    public class ServeBaseRouteInfo
    {
        public string Route { get; set; }
        public string BaseAddress { get; set; }
        public bool UseApiGateway { get; set; }
        // 추가적인 서버 정보 필드들...
    }
    public class DtoTypeBuilder<TDto> where TDto : class
    {
        protected List<ServeBaseRouteInfo> ServerBaseRoutes { get; } = new List<ServeBaseRouteInfo>();
        protected IValidator<TDto> Validator { get; private set; }

        public DtoTypeBuilder(IDtoConfiguration<TDto> configuration)
        {
            configuration.Configure(this);
        }

        public DtoTypeBuilder<TDto> SetValidator(IValidator<TDto> validator)
        {
            Validator = validator;
            return this;
        }

        public DtoTypeBuilder<TDto> SetServeBaseRouteInfo(ServeBaseRouteInfo info)
        {
            ServerBaseRoutes.Add(info);
            return this;
        }

        public DtoTypeBuilder<TDto> ApplyConfiguration(IDtoConfiguration<TDto> configuration)
        {
            configuration.Configure(this);
            return this;
        }

        public async Task PostAsync(TDto dto)
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

                if (selectedRoute.UseApiGateway && IsApiGatewayCompatible(dto))
                {
                    await SendRequestToApiGateway(httpClient, selectedRoute.Route, httpContent);
                }
                else
                {
                    await SendRequestToBusinessServer(httpClient, selectedRoute.Route, httpContent);
                }
            }
        }
        public async Task PutAsync(TDto dto)
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

                if (selectedRoute.UseApiGateway && IsApiGatewayCompatible(dto))
                {
                    await SendRequestToApiGateway(httpClient, selectedRoute.Route, httpContent, HttpMethod.Put);
                }
                else
                {
                    await SendRequestToBusinessServer(httpClient, selectedRoute.Route, httpContent, HttpMethod.Put);
                }
            }
        }

        public async Task DeleteAsync(string id)
        {
            var selectedRoute = GetSelectedBaseRoute(null);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(selectedRoute.BaseAddress);

                if (selectedRoute.UseApiGateway)
                {
                    await SendRequestToApiGateway(httpClient, $"{selectedRoute.Route}/{id}", null, HttpMethod.Delete);
                }
                else
                {
                    await SendRequestToBusinessServer(httpClient, $"{selectedRoute.Route}/{id}", null, HttpMethod.Delete);
                }
            }
        }

        public async Task<TDto> ReadAsync(string id)
        {
            var selectedRoute = GetSelectedBaseRoute(null);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(selectedRoute.BaseAddress);

                if (selectedRoute.UseApiGateway)
                {
                    return await SendRequestToApiGateway<TDto>(httpClient, $"{selectedRoute.Route}/{id}", null, HttpMethod.Get);
                }
                else
                {
                    return await SendRequestToBusinessServer<TDto>(httpClient, $"{selectedRoute.Route}/{id}", null, HttpMethod.Get);
                }
            }
        }
        private async Task SendRequestToApiGateway(HttpClient httpClient, string route, HttpContent httpContent)
        {
            // API Gateway로 요청을 보내는 로직을 구현
            // 필요한 경우 인증 토큰 등을 추가하고 요청을 보낸 후 처리
            var response = await httpClient.PostAsync(route, httpContent);
            response.EnsureSuccessStatusCode();
        }

        private async Task SendRequestToBusinessServer(HttpClient httpClient, string route, HttpContent httpContent)
        {
            // 비즈니스 처리 서버로 직접 요청을 보내는 로직을 구현
            // 필요한 경우 인증 토큰 등을 추가하고 요청을 보낸 후 처리
            var response = await httpClient.PostAsync(route, httpContent);
            response.EnsureSuccessStatusCode();
        }
        private bool IsApiGatewayCompatible(TDto dto)
        {
            var cqsAttribute = dto.GetType().GetCustomAttribute<CQRSAttribute>();
            return cqsAttribute != null && cqsAttribute.IsEnabled;
        }
        private ServeBaseRouteInfo GetSelectedBaseRoute(TDto dto)
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

    public interface IDtoConfiguration<TDto> where TDto : class
    {
        void Configure(DtoTypeBuilder<TDto> builder);
    }
}

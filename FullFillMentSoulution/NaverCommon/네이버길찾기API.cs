using NaverCommon.Direction;
using Newtonsoft.Json;

namespace NaverCommon.Diriection
{
    public class 네이버길찾기ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public 네이버길찾기ApiClient(string clientId, string clientSecret)
        {
            _httpClient = new HttpClient();
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<RootObject> GetDrivingDirectionsAsync(string start, string goal, string option = "")
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("X-NCP-APIGW-API-KEY-ID", _clientId);
            _httpClient.DefaultRequestHeaders.Add("X-NCP-APIGW-API-KEY", _clientSecret);

            string url = $"https://naveropenapi.apigw.ntruss.com/map-direction/v1/driving?start={start}&goal={goal}";

            if (!string.IsNullOrEmpty(option))
            {
                url += $"&option={Uri.EscapeDataString(option)}";
            }

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                RootObject result = JsonConvert.DeserializeObject<RootObject>(responseBody);
                return result;
            }
            else
            {
                throw new Exception($"Request failed with status code {response.StatusCode}. Error message: {responseBody}");
            }
        }
    }
}

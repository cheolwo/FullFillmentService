using AutoMapper;
using KoreaCommon.Model;
using Newtonsoft.Json;
using System;

namespace ConsoleApp
{
    public class AddressElement
    {
        public List<string> types { get; set; }
        public string longName { get; set; }
        public string shortName { get; set; }
        public string code { get; set; }
    }

    public class Address
    {
        public string roadAddress { get; set; }
        public string jibunAddress { get; set; }
        public string englishAddress { get; set; }
        public List<AddressElement> addressElements { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public double distance { get; set; }
    }

    public class Meta
    {
        public int totalCount { get; set; }
        public int page { get; set; }
        public int count { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public Meta meta { get; set; }
        public List<Address> addresses { get; set; }
        public string errorMessage { get; set; }
    }

    public class 네이버좌표변환ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public 네이버좌표변환ApiClient(string clientId, string clientSecret)
        {
            _httpClient = new HttpClient();
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<RootObject> GetGeocodeAsync(string address, string coordinate = "", string filter = "", string language = "kor", int page = 1, int count = 10)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("X-NCP-APIGW-API-KEY-ID", _clientId);
            _httpClient.DefaultRequestHeaders.Add("X-NCP-APIGW-API-KEY", _clientSecret);

            string url = $"https://naveropenapi.apigw.ntruss.com/map-geocode/v2/geocode?query={Uri.EscapeDataString(address)}";

            if (!string.IsNullOrEmpty(coordinate))
            {
                url += $"&coordinate={coordinate}";
            }

            if (!string.IsNullOrEmpty(filter))
            {
                url += $"&filter={Uri.EscapeDataString(filter)}";
            }

            url += $"&language={language}&page={page}&count={count}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

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

    public class Program
    {
        public static async Task Main(string[] args)
        {
            네이버좌표변환ApiClient geocodeApiClient = new("qnmcxa3j8i", "onuvNfUFBqgm0QGkXHjTWPk7HGoW8BYTU3qipppP");

            var response = await geocodeApiClient.GetGeocodeAsync("인천광역시 강화군 내가면 해안서로 850 경인북부수협 판매사업팀\r\n ");
            Console.WriteLine("Status: " + response.status);
            Console.WriteLine("Meta Total Count: " + response.meta.totalCount);
            Console.WriteLine("Road x: " + response.addresses[0].x);
            Console.WriteLine("Road x: " + response.addresses[0].y);
        }
    }
}

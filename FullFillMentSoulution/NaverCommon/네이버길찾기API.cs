using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaverCommon.Diriection
{
    public class Summary
    {
        public class Location
        {
            public List<double> location { get; set; }
        }

        public Location start { get; set; }
        public class Goal
        {
            public List<double> location { get; set; }
            public int dir { get; set; }
        }
        public Goal goal { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
        public List<List<double>> bbox { get; set; }
        public int tollFare { get; set; }
        public int taxiFare { get; set; }
        public int fuelPrice { get; set; }
    }

    public class Section
    {
        public int pointIndex { get; set; }
        public int pointCount { get; set; }
        public int distance { get; set; }
        public string name { get; set; }
        public int congestion { get; set; }
        public int speed { get; set; }
    }

    public class Guide
    {
        public int pointIndex { get; set; }
        public int type { get; set; }
        public string instructions { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
    }

    public class Trafast
    {
        public Summary summary { get; set; }
        public List<List<double>> path { get; set; }
        public List<Section> section { get; set; }
        public List<Guide> guide { get; set; }
    }

    public class Route
    {
        public List<Trafast> trafast { get; set; }
    }

    public class RootObject
    {
        public int code { get; set; }
        public string message { get; set; }
        public string currentDateTime { get; set; }
        public Route route { get; set; }
    }
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

            string url = $"https://naveropenapi.apigw.ntruss.com/map-direction/v1/driving?start={Uri.EscapeDataString(start)}&goal={Uri.EscapeDataString(goal)}";

            if (!string.IsNullOrEmpty(option))
            {
                url += $"&option={Uri.EscapeDataString(option)}";
            }

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
}

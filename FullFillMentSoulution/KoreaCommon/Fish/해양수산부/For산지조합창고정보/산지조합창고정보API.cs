using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KoreaCommon.Fish.해양수산부.For산지조합창고정보
{
    public class 산지조합창고API
    {
        private string baseUrl = "http://apis.data.go.kr/1192000/select0120List/getselect0120List";
        private readonly IConfiguration _configuration;
        private string serviceKey;

        public 산지조합창고API(IConfiguration configuration)
        {
            _configuration = configuration;
            serviceKey = _configuration.GetSection("APIConnection")["해양수산부_수협"]
                                ?? throw new Exception("해양수산부_수협 service key is missing or empty.");
        }

        public async Task<산지조합창고정보> Get산지조합창고정보(int numOfRows = 10, int pageNo = 1, string dataType = "json")
        {
            string url = $"{baseUrl}?ServiceKey={serviceKey}&numOfRows={numOfRows}&pageNo={pageNo}&type={dataType}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();
                    산지조합창고정보 result = JsonConvert.DeserializeObject<산지조합창고정보>(data);
                    return result;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error occurred during the request: {e.Message}");
                    return null;
                }
                catch (JsonException e)
                {
                    Console.WriteLine($"Error occurred during deserialization: {e.Message}");
                    return null;
                }
            }
        }
    }
    public class Item
    {
        [JsonProperty("mxtrCode")]
        public string MxtrCode { get; set; }

        [JsonProperty("mxtrNm")]
        public string MxtrNm { get; set; }

        [JsonProperty("wrhousCode")]
        public string WrhousCode { get; set; }

        [JsonProperty("wrhousNm")]
        public string WrhousNm { get; set; }

        [JsonProperty("telNo")]
        public string TelNo { get; set; }

        [JsonProperty("fxNum")]
        public string FxNum { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("wrhousBassAdres")]
        public string WrhousBassAdres { get; set; }

        [JsonProperty("wrhousDetailAdres")]
        public string WrhousDetailAdres { get; set; }

        [JsonProperty("bldar")]
        public string Bldar { get; set; }
    }

    public class Body
    {
        [JsonProperty("item")]
        public List<Item> Item { get; set; }
    }

    public class Header
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }

        [JsonProperty("resultMsg")]
        public string ResultMsg { get; set; }

        [JsonProperty("pageNo")]
        public int PageNo { get; set; }

        [JsonProperty("numOfRows")]
        public int NumOfRows { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }

    public class ResponseJson
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }
    public class 산지조합창고정보
    {
        [JsonProperty("responseJson")]
        public ResponseJson ResponseJson { get; set; }
    }
}

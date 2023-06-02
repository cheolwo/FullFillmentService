using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KoreaCommon.Fish.수협산지조합위판장.위판장현황
{
    public class 산지조합위판장현황API
    {
        private HttpClient client;
        private string baseUrl = "http://apis.data.go.kr/1192000/select0060List/getselect0060List";
        private string serviceKey;
        private readonly IConfiguration _configuration;

        public 산지조합위판장현황API(IConfiguration configuration)
        {
            _configuration = configuration;
            serviceKey = _configuration.GetSection("APIConnection")["해양수산부_수협"]
                                ?? throw new Exception("해양수산부_수협 service key is missing or empty.");
            client = new HttpClient();
        }

        public async Task<산지조합위판장현황정보> Get산지조합위판장현황정보(string baseDt = "202305", string dataType = "json")
        {
            string url = $"{baseUrl}?ServiceKey={serviceKey}&type={dataType}&baseDt={baseDt}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string data = await response.Content.ReadAsStringAsync();
                Console.Write(data);
                산지조합위판장현황정보 result = JsonConvert.DeserializeObject<산지조합위판장현황정보>(data);
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
    public class Item
    {
        [JsonProperty("csmtDe")]
        public string CsmtDe { get; set; }

        [JsonProperty("mxtrCode")]
        public string MxtrCode { get; set; }

        [JsonProperty("mxtrNm")]
        public string MxtrNm { get; set; }

        [JsonProperty("csmtmktCode")]
        public string CsmtmktCode { get; set; }

        [JsonProperty("csmtmktNm")]
        public string CsmtmktNm { get; set; }

        [JsonProperty("sCnt")]
        public string SCnt { get; set; }

        [JsonProperty("hCnt")]
        public string HCnt { get; set; }

        [JsonProperty("sAmt")]
        public string SAmt { get; set; }
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

    public class 산지조합위판장현황정보
    {
        [JsonProperty("responseJson")]
        public ResponseJson ResponseJson { get; set; }
    }
}

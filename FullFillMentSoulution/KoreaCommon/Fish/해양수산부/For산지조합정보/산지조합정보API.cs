using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KoreaCommon.Fish.산지조합위판장.해양수산부산지조합정보
{
    public class 산지조합API
    {
        private string baseUrl = "http://apis.data.go.kr/1192000/select0010List/getselect0010List";
        private string? serviceKey;
        private readonly IConfiguration _configuration;
        public 산지조합API(IConfiguration configuration)
        {
            _configuration = configuration;
            serviceKey = _configuration.GetSection("APIConnection")["해양수산부_수협"]
                                ?? throw new Exception("해양수산부_수협 service key is missing or empty.");
        }

        public async Task<산지조합정보> Get산지조합정보(string mxtrNm="", int numOfRows = 10, int pageNo = 1, string dataType = "json")
        {
            string url = $"{baseUrl}?ServiceKey={serviceKey}&numOfRows={numOfRows}&pageNo={pageNo}&type={dataType}&mxtrNm={mxtrNm}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();
                    산지조합정보 result = JsonConvert.DeserializeObject<산지조합정보>(data);
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
        [JsonProperty("mxtrNm")]
        public string MxtrNm { get; set; }

        [JsonProperty("mxtrCode")]
        public string MxtrCode { get; set; }

        [JsonProperty("telNo")]
        public string TelNo { get; set; }

        [JsonProperty("fxNum")]
        public string FxNum { get; set; }
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
    public class 산지조합정보
    {
        [JsonProperty("responseJson")]
        public ResponseJson ResponseJson { get; set; }
    }
}

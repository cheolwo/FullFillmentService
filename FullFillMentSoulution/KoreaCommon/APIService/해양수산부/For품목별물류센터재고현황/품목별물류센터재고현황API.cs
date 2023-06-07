using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KoreaCommon.Fish.해양수산부.For품목별물류센터재고현황
{
    public class 품목별물류센터재고현황API
    {
        private string baseUrl = "http://apis.data.go.kr/1192000/select0170List/getselect0170List";
        private string serviceKey;
        private readonly IConfiguration _configuration;

        public 품목별물류센터재고현황API(IConfiguration configuration)
        {
            _configuration = configuration;
            serviceKey = _configuration.GetSection("APIConnection")["해양수산부_수협"]
                                ?? throw new Exception("해양수산부_수협 service key is missing or empty.");
        }

        public async Task<품목별물류센터재고현황정보> Get품목별물류센터재고현황정보(string baseDt = "20230520", string lgistCnterCode="", string lgistCnterNm = "", string mprcStdCode = "", string mprcStdCodeNm = "", int numOfRows = 10, int pageNo = 1, string dataType = "json")
        {
            string url = $"{baseUrl}?ServiceKey={serviceKey}&numOfRows={numOfRows}&pageNo={pageNo}&type={dataType}&baseDt={baseDt}&lgistCnterCode={lgistCnterCode}&lgistCnterNm={lgistCnterNm}&mprcStdCode={mprcStdCode}&mprcStdCodeNm={mprcStdCodeNm}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();
                    품목별물류센터재고현황정보 result = JsonConvert.DeserializeObject<품목별물류센터재고현황정보>(data);
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
        [JsonProperty("mprcStdCodeNm")]
        public string MprcStdCodeNm { get; set; }

        [JsonProperty("kdfshSttusCode")]
        public string KdfshSttusCode { get; set; }

        [JsonProperty("kdfshSttusNm")]
        public string KdfshSttusNm { get; set; }

        [JsonProperty("invntryQy")]
        public string InvntryQy { get; set; }

        [JsonProperty("kgCnvrsnInvntryQy")]
        public string KgCnvrsnInvntryQy { get; set; }

        [JsonProperty("stdrDe")]
        public string StdrDe { get; set; }

        [JsonProperty("lgistCnterCode")]
        public string LgistCnterCode { get; set; }

        [JsonProperty("lgistCnterNm")]
        public string LgistCnterNm { get; set; }

        [JsonProperty("mprcStdCode")]
        public string MprcStdCode { get; set; }
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

    public class 품목별물류센터재고현황정보
    {
        [JsonProperty("responseJson")]
        public ResponseJson ResponseJson { get; set; }
    }

    public class ResponseJson
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }
}

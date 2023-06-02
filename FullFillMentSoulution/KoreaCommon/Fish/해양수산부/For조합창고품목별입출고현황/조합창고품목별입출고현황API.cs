using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KoreaCommon.Fish.해양수산부.For조합창고품목별입출고현황
{
    public class 조합창고품목별입출고현황API
    {
        private string serviceKey;
        private readonly IConfiguration _configuration;

        public 조합창고품목별입출고현황API(IConfiguration configuration)
        {
            _configuration = configuration;
            serviceKey = _configuration.GetSection("APIConnection")["해양수산부_수협"]
                                ?? throw new Exception("해양수산부_수협 service key is missing or empty.");
        }

        public async Task<조합창고품목별입출고현황정보> Get조합창고품목별입출고현황정보(int numOfRows = 100, int pageNo = 1, string dataType = "json", string baseDt = "20220101",
            string mxtrNm = "", string wrhousNm = "", string mprcStdCodeNm = "", string wrhsdlvrSeName = "")
        {
            string url = "http://apis.data.go.kr/1192000/select0140List/getselect0140List"; // URL
            url += "?ServiceKey=" + serviceKey; // Service Key
            url += $"&numOfRows={numOfRows}&pageNo={pageNo}&type={dataType}&baseDt={baseDt}&mxtrNm={mxtrNm}&wrhousNm={wrhousNm}&mprcStdCodeNm={mprcStdCodeNm}&wrhsdlvrSeName={wrhsdlvrSeName}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();
                    조합창고품목별입출고현황정보 result = JsonConvert.DeserializeObject<조합창고품목별입출고현황정보>(data);
                    return result;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error occurred during the request: {e.Message}");
                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error occurred: {e.Message}");
                    return null;
                }
            }
        }
    }
    public class Item
    {
        [JsonProperty("stdrDe")]
        public string StdrDe { get; set; }

        [JsonProperty("mprcStdCode")]
        public string MprcStdCode { get; set; }

        [JsonProperty("mprcStdCodeNm")]
        public string MprcStdCodeNm { get; set; }

        [JsonProperty("mxtrCode")]
        public string MxtrCode { get; set; }

        [JsonProperty("mxtrNm")]
        public string MxtrNm { get; set; }

        [JsonProperty("wrhousCode")]
        public string WrhousCode { get; set; }

        [JsonProperty("wrhousNm")]
        public string WrhousNm { get; set; }

        [JsonProperty("wrhsdlvrSeCode")]
        public string WrhsdlvrSeCode { get; set; }

        [JsonProperty("wrhsdlvrSeName")]
        public string WrhsdlvrSeName { get; set; }

        [JsonProperty("wrhsdlvrQy")]
        public string WrhsdlvrQy { get; set; }
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
    public class 조합창고품목별입출고현황정보
    {
        [JsonProperty("responseJson")]
        public ResponseJson ResponseJson { get; set; }
    }
}

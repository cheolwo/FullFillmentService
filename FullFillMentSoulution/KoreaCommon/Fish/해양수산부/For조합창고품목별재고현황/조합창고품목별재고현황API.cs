using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KoreaCommon.Fish.해양수산부.For조합창고품목별재고현황
{
    public class 조합창고품목별재고현황API
    {
        private string baseUrl = "http://apis.data.go.kr/1192000/select0150List/getselect0150List";
        private string serviceKey;
        private readonly IConfiguration _configuration;

        public 조합창고품목별재고현황API(IConfiguration configuration)
        {
            _configuration = configuration;
            serviceKey = _configuration.GetSection("APIConnection")["해양수산부_수협"]
                                ?? throw new Exception("해양수산부_수협 service key is missing or empty.");
        }

        public async Task<조합창고품목별재고현황정보> Get조합창고품목별재고현황정보(string baseDt="20230520", int numOfRows = 100, int pageNo = 1, string dataType = "json")
        {
            string url = $"{baseUrl}?ServiceKey={serviceKey}&numOfRows={numOfRows}&pageNo={pageNo}&type={dataType}&baseDt={baseDt}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();
                    조합창고품목별재고현황정보 result = JsonConvert.DeserializeObject<조합창고품목별재고현황정보>(data);
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
        /// <summary>
        /// 기준일자
        /// </summary>
        [JsonProperty("stdrDe")] 
        public string StdrDe { get; set; }

        /// <summary>
        /// 조합코드
        /// </summary>

        [JsonProperty("mxtrCode")] 
        public string MxtrCode { get; set; }

        /// <summary>
        /// 조합명
        /// </summary>

        [JsonProperty("mxtrNm")] 
        public string MxtrNm { get; set; }

        /// <summary>
        /// 창고코드
        /// </summary>

        [JsonProperty("wrhousCode")] 
        public string WrhousCode { get; set; }

        /// <summary>
        /// 창고명
        /// </summary>

        [JsonProperty("wrhousNm")] 
        public string WrhousNm { get; set; }

        /// <summary>
        /// 수산물표준코드
        /// </summary>

        [JsonProperty("mprcStdCode")] 
        public string MprcStdCode { get; set; }

        /// <summary>
        /// 수산물표준코드명
        /// </summary>

        [JsonProperty("mprcStdCodeNm")] 
        public string MprcStdCodeNm { get; set; }

        /// <summary>
        /// 재고량
        /// </summary>

        [JsonProperty("invntryQy")] 
        public string InvntryQy { get; set; }
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

    public class 조합창고품목별재고현황정보
    {
        [JsonProperty("responseJson")]
        public ResponseJson ResponseJson { get; set; }
    }
}

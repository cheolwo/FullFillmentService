using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KoreaCommon.Fish.해양수산부.For위판장별위탁판매현황
{
    public class 위판장별위탁판매현황API
    {
        private string baseUrl = "http://apis.data.go.kr/1192000/select0040List/getselect0040List";
        private string serviceKey;
        private readonly IConfiguration _configuration;

        public 위판장별위탁판매현황API(IConfiguration configuration)
        {
            _configuration = configuration;
            serviceKey = _configuration.GetSection("APIConnection")["해양수산부_수협"]
                                ?? throw new Exception("해양수산부_수협 service key is missing or empty.");
        }

        public async Task<위판장별위탁판매현황정보> Get위판장별위탁판매현황정보(string baseDt = "20220101", string mxtrNm="", string csmtmktNm = "", string mprcStdCode = "", string mprcStdCodeNm = "", int numOfRows = 10, int pageNo = 1, string dataType = "json")
        {
            string url = $"{baseUrl}?ServiceKey={serviceKey}&numOfRows={numOfRows}&pageNo={pageNo}&type={dataType}&baseDt={baseDt}&mxtrNm={mxtrNm}&csmtmktNm={csmtmktNm}&mprcStdCode={mprcStdCode}&mprcStdCodeNm={mprcStdCodeNm}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();
                    위판장별위탁판매현황정보 result = JsonConvert.DeserializeObject<위판장별위탁판매현황정보>(data);
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

        [JsonProperty("fshrCode")]
        public string FshrCode { get; set; }

        [JsonProperty("fshrNm")]
        public string FshrNm { get; set; }

        [JsonProperty("prchasNo")]
        public string PrchasNo { get; set; }

        [JsonProperty("prchasSn")]
        public string PrchasSn { get; set; }

        [JsonProperty("mprcStdCode")]
        public string MprcStdCode { get; set; }

        [JsonProperty("mprcStdCodeNm")]
        public string MprcStdCodeNm { get; set; }

        [JsonProperty("csmtQy")]
        public string CsmtQy { get; set; }

        [JsonProperty("csmtWt")]
        public string CsmtWt { get; set; }

        [JsonProperty("csmtUnqt")]
        public string CsmtUnqt { get; set; }

        [JsonProperty("csmtUntpc")]
        public string CsmtUntpc { get; set; }

        [JsonProperty("csmtAmount")]
        public string CsmtAmount { get; set; }

        [JsonProperty("kdfshSttusCode")]
        public string KdfshSttusCode { get; set; }

        [JsonProperty("kdfshSttusNm")]
        public string KdfshSttusNm { get; set; }

        [JsonProperty("goodsStndrdCode")]
        public string GoodsStndrdCode { get; set; }

        [JsonProperty("goodsStndrdNm")]
        public string GoodsStndrdNm { get; set; }

        [JsonProperty("goodsUnitCode")]
        public string GoodsUnitCode { get; set; }

        [JsonProperty("goodsUnitNm")]
        public string GoodsUnitNm { get; set; }

        [JsonProperty("orgplceSeCode")]
        public string OrgplceSeCode { get; set; }

        [JsonProperty("orgplceSeNm")]
        public string OrgplceSeNm { get; set; }
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

    public class 위판장별위탁판매현황정보
    {
        [JsonProperty("responseJson")]
        public ResponseJson ResponseJson { get; set; }
    }
}

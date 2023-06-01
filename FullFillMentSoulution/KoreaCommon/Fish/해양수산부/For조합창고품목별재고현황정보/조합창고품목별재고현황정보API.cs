using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreaCommon.Fish.해양수산부.For조합창고품목별재고현황정보
{
    public class 조합창고품목별재고현황정보API
    {
        private string baseUrl = "http://apis.data.go.kr/1192000/select0150List/getselect0150List";
        private string serviceKey;

        public 조합창고품목별재고현황정보API(string serviceKey)
        {
            this.serviceKey = serviceKey;
        }

        public async Task<조합창고품목별재고현황정보> Get조합창고품목별재고현황정보(string baseDt, int numOfRows = 10, int pageNo = 1, string dataType = "json")
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
        [JsonProperty("stdrDe")]
        public string StdrDe { get; set; }

        [JsonProperty("mxtrCode")]
        public string MxtrCode { get; set; }

        [JsonProperty("mxtrNm")]
        public string MxtrNm { get; set; }

        [JsonProperty("wrhousCode")]
        public string WrhousCode { get; set; }

        [JsonProperty("wrhousNm")]
        public string WrhousNm { get; set; }

        [JsonProperty("mprcStdCode")]
        public string MprcStdCode { get; set; }

        [JsonProperty("mprcStdCodeNm")]
        public string MprcStdCodeNm { get; set; }

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

using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using 수협Common.Model;

namespace 해양수산부.API.For산지조합
{
    public class 산지조합API
    {
        private string baseUrl = "http://apis.data.go.kr/1192000/select0010List/getselect0010List";
        private string? serviceKey;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public 산지조합API(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            serviceKey = _configuration.GetSection("APIConnection")["해양수산부_수협"]
                                ?? throw new Exception("해양수산부_수협 service key is missing or empty.");
            _mapper = mapper;
        }
        public async Task<List<수산협동조합>> Get산지조합List(string mxtrNm = "", int numOfRows = 10, int pageNo = 1, string dataType = "json")
        {
            var 산지조합List = new List<수산협동조합>();

            var 산지조합정보 = await Get산지조합정보(mxtrNm, numOfRows, pageNo, dataType);

            if (산지조합정보?.ResponseJson?.Body?.Item != null)
            {
                foreach (var item in 산지조합정보.ResponseJson.Body.Item)
                {
                    var 수산협동조합 = MapItemTo수산협동조합(item);
                    산지조합List.Add(수산협동조합);
                }
            }

            return 산지조합List;
        }
        public async Task<List<수산협동조합>> LoadAll수산협동조합정보()
        {
            List<수산협동조합> 수산협동조합들 = new List<수산협동조합>();

            // 처음 요청하여 TotalCount 가져오기
            산지조합정보 첫번째응답 = await Get산지조합정보();
            int totalCount = 첫번째응답.ResponseJson.Header.TotalCount;
            int numOfPages = (totalCount / 100) + 1;

            // 페이지별로 요청하여 수산협동조합 정보 로드 및 매핑
            for (int pageNo = 1; pageNo <= numOfPages; pageNo++)
            {
                산지조합정보 response = await Get산지조합정보("", 100, pageNo);
                수산협동조합들.AddRange(Map산지조합정보To수산협동조합(response));
            }

            return 수산협동조합들;
        }
        private List<수산협동조합> Map산지조합정보To수산협동조합(산지조합정보 response)
        {
            List<수산협동조합> 수산협동조합들 = new List<수산협동조합>();

            foreach (var item in response.ResponseJson.Body.Item)
            {
                수산협동조합 수산협동조합 = new 수산협동조합
                {
                    Code = item.MxtrCode,
                    Name = item.MxtrNm,
                    PhoneNumber = item.TelNo,
                    FaxNumber = item.FxNum,
                    // 추가적인 매핑 작업이 필요할 경우 여기에 작성
                };

                수산협동조합들.Add(수산협동조합);
            }

            return 수산협동조합들;
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
        private 수산협동조합 MapItemTo수산협동조합(Item item)
        {
            return _mapper.Map<Item, 수산협동조합>(item);
        }
    }
    /// <summary>
    /// 산지조합정보
    /// </summary>
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

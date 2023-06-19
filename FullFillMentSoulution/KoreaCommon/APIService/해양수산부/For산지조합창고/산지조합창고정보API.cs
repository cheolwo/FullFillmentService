using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using 수협Common.Model;

namespace 해양수산부.API.For산지조합창고
{
    public class 산지조합창고API
    {
        private string baseUrl = "http://apis.data.go.kr/1192000/select0120List/getselect0120List";
        private readonly IConfiguration _configuration;
        private string serviceKey;
        private IMapper _mapper;
        private MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<해양수산부.API.For산지조합창고.Item, 수산창고>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.WrhousCode))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.WrhousNm))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.TelNo))
                .ForMember(dest => dest.FaxNumber, opt => opt.MapFrom(src => src.FxNum))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Zip))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.WrhousBassAdres} {src.WrhousDetailAdres}"))
                .ForMember(dest => dest.수협Id, opt => opt.Ignore())
                .ForMember(dest => dest.수협, opt => opt.Ignore())
                .ForMember(dest => dest.수산품들, opt => opt.Ignore())
                .ForMember(dest => dest.수산품별재고현황들, opt => opt.Ignore());
        });
        public 산지조합창고API(IConfiguration configuration, IMapper mapper)
        {

            _configuration = configuration;
            _mapper = mapper;
            _mapper = config.CreateMapper();
           
            serviceKey = _configuration.GetSection("APIConnection")["해양수산부_수협"]
                                ?? throw new Exception("해양수산부_수협 service key is missing or empty.");
        }
        public async Task<List<수산창고>> Get산지조합창고List()
        {
            var 산지조합창고List = new List<수산창고>();

            var 산지조합정보 = await Get산지조합창고정보();

            if (산지조합정보?.ResponseJson?.Body?.Item != null)
            {
                foreach (var item in 산지조합정보.ResponseJson.Body.Item)
                {
                    var 수산창고 = MapItemTo수산창고(item);
                    산지조합창고List.Add(수산창고);
                }
            }

            return 산지조합창고List;
        }
        public async Task<List<수산창고>> LoadAll수산창고정보()
        {
            List<수산창고> 수산창고들 = new List<수산창고>();

            // 처음 요청하여 TotalCount 가져오기
            산지조합창고정보 첫번째응답 = await Get산지조합창고정보(1, 1);
            int totalCount = 첫번째응답.ResponseJson.Header.TotalCount;
            int numOfPages = (totalCount / 100) + 1;

            // 페이지별로 요청하여 산지조합창고 정보 로드 및 매핑
            for (int pageNo = 1; pageNo <= numOfPages; pageNo++)
            {
                산지조합창고정보 response = await Get산지조합창고정보(100, pageNo);
                ItemsTo수산창고(response.ResponseJson.Body.Item, 수산창고들);
            }
            return 수산창고들;
        }
        private void ItemsTo수산창고(List<Item> items, List<수산창고> 수산창고들)
        {
            foreach(var item in items)
            {
                수산창고들.Add(MapItemTo수산창고(item));
            }
        }
        private 수산창고 MapItemTo수산창고(Item item)
        {
            return _mapper.Map<Item, 수산창고>(item);
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
        public string? MxtrCode { get; set; }

        [JsonProperty("mxtrNm")]
        public string? MxtrNm { get; set; }

        [JsonProperty("wrhousCode")]
        public string? WrhousCode { get; set; }

        [JsonProperty("wrhousNm")]
        public string? WrhousNm { get; set; }

        [JsonProperty("telNo")]
        public string? TelNo { get; set; }

        [JsonProperty("fxNum")]
        public string? FxNum { get; set; }

        [JsonProperty("zip")]
        public string? Zip { get; set; }

        [JsonProperty("wrhousBassAdres")]
        public string? WrhousBassAdres { get; set; }

        [JsonProperty("wrhousDetailAdres")]
        public string? WrhousDetailAdres { get; set; }

        [JsonProperty("bldar")]
        public string? Bldar { get; set; }
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

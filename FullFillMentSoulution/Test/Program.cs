using KoreaCommon.Fish.해양수산부.For위탁장별위탁판매현황;
using KoreaCommon.Fish.해양수산부.For조합창고품목별재고현황정보;

public class Program
{
    public static async Task Main()
    {
        string serviceKey = ""; // 서비스 키를 설정해주세요

        위탁장별위탁판매현황API api = new(serviceKey);

        var data = await api.Get위탁장별위탁판매현황();
        if(data != null)
        {
            foreach (var item in data.ResponseJson.Body.Item)
            {
                Console.WriteLine("FshrNm : {0}", item.FshrNm);
                Console.WriteLine("FshrCode : {0}", item.FshrCode);
                Console.WriteLine();
            }
        }
    }
}

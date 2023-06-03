using KoreaCommon.Fish.해양수산부.For조합창고품목별재고현황;

public class Program
{
    static int Count = 1;
    public static async Task Main()
    {
        // 사용 예시:
        await PrintAllItems();
    }
    public static void PrintItemsByPage(조합창고품목별재고현황정보 정보, int page)
    {
        int numOfRowsPerPage = 정보.ResponseJson.Header.NumOfRows;
        List<Item> items = 정보.ResponseJson.Body.Item;

        int startIndex = (page - 1) * numOfRowsPerPage;
        int endIndex = Math.Min(startIndex + numOfRowsPerPage, items.Count);

        for (int i = startIndex; i < endIndex; i++)
        {
            Item item = items[i];
            // 아이템 정보 출력 또는 처리
            Console.WriteLine($"Item: {item.MxtrNm}, Inventory: {item.InvntryQy}");
            Console.WriteLine(Count);
            Count++;
        }
    }
    public static async Task PrintAllItems()
    {
        try
        {
            int currentPage = 1;
            조합창고품목별재고현황API api = new 조합창고품목별재고현황API();
            조합창고품목별재고현황정보 정보 = await api.Get조합창고품목별재고현황정보();

            int totalPages = (정보.ResponseJson.Header.TotalCount + 정보.ResponseJson.Header.NumOfRows - 1) / 정보.ResponseJson.Header.NumOfRows;

            for (currentPage = 1; currentPage <= totalPages; currentPage++)
            {
                PrintItemsByPage(정보, currentPage);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
}

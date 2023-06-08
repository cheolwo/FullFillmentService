using NaverCommon;
using NaverCommon.Diriection;

namespace ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            네이버좌표변환ApiClient geocodeApiClient = new("qnmcxa3j8i", "VyFooPIUNRzFrcm0eFwXzX6Kdlf5V9SoDoYUVz8e");

            var response1 = await geocodeApiClient.GetGeocodeAsync("인천광역시 강화군 내가면 해안서로 850 경인북부수협 판매사업팀");
            Console.WriteLine("Status: " + response1.status);
            Console.WriteLine("Meta Total Count: " + response1.meta.totalCount);
            Console.WriteLine("Road x: " + response1.addresses[0].x);
            Console.WriteLine("Road x: " + response1.addresses[0].y);

            var response2 = await geocodeApiClient.GetGeocodeAsync("인천광역시 옹진군 영흥면 외리 247-53 영흥수협김건조장");
            Console.WriteLine("Status: " + response2.status);
            Console.WriteLine("Meta Total Count: " + response1.meta.totalCount);
            Console.WriteLine("Road x: " + response2.addresses[0].x);
            Console.WriteLine("Road x: " + response2.addresses[0].y);

            네이버길찾기ApiClient directionApiClient = new("qnmcxa3j8i", "VyFooPIUNRzFrcm0eFwXzX6Kdlf5V9SoDoYUVz8e");
            await directionApiClient.TestGetDrivingDirectionsAsync($"{response1.addresses[0].x},{response1.addresses[0].y}", $"{response2.addresses[0].x}.{response2.addresses[0].y}");
            
        }
    }
}

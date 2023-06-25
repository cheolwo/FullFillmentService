using Newtonsoft.Json;
using System.Text;

namespace Common.Extensions
{
    public static class ByteArrayExtensions
    {
        public static byte[] ToSerializedBytes<T>(this T obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(jsonString);
        }
    }
}

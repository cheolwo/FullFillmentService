using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class CacheKeyExtensions
    {
        /// <summary>
        /// Cache Key Related Center Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="userId"></param>
        /// <param name="centerId"></param>
        /// <returns></returns>
        public static string GenerateCacheKey<T>(this string userId, string centerId)
        {
            return $"{userId}_{typeof(T).Name}_{centerId}";
        }
    }
}

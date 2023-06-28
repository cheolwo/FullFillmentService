using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class QueueExtensions
    {
        public static string CreateQueueName<T>(this string enqueServer, string dequeServer)
        {
            return $"{enqueServer}:{dequeServer}:{typeof(T).Name}";
        }
    }
}

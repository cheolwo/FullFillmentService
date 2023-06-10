using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 계정Common.Models
{
    public class DistributedUserId
    {
        public string UserId { get; set; }
        public Dictionary<string, string> Roles { get;set; }
    }
}

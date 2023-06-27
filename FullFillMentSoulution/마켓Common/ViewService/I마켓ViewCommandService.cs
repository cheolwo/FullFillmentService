using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 마켓Common.ViewService
{
    public interface I마켓ViewCommandService
    {
    }
    public interface I마켓ViewQueryService
    {
    }
    public class 마켓ViewService : I마켓ViewCommandService, I마켓ViewQueryService
    {
        public 마켓ViewService()
        {

        }
    }
}

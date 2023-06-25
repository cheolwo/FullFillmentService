using Common.DTO;
using Common.ForCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class CommandMappingManager
    {
        public static CudCommand<T> Mapping<T>(this T t, CommandOption options) where T : CudDTO
        {
            return new CudCommand<T>
            {
                t = t,
                commandOption = options
            };
        }
    }
}

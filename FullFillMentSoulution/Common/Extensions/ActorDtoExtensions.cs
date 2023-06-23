using Azure.Storage.Blobs.Models;
using Common.DTO;
using FrontCommon.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class ActorDtoExtensions
    {
        public static async Task Post<T>(this T t, ActorCommandContext context) where T : CudDTO
        {
            await context.Set<T>().PostAsync(t);
        }
    }
}

using Common.ForCommand;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    //public static class JwtTokenExtensions
    //{
    //    public static string GetUserIdFromToken(this string token)
    //    {
    //        // 토큰을 해석하여 사용자 ID 추출 로직 구현
    //        // 필요에 따라 JWT 토큰을 검증하고 사용자 ID를 추출하는 작업을 수행

    //        // 예시: JWT 토큰을 검증하고 사용자 ID를 추출하는 작업
    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

    //        if (jwtToken != null && jwtToken.ValidTo > DateTime.UtcNow)
    //        {
    //            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    //            return userId;
    //        }

    //        return null; // 토큰이 유효하지 않은 경우에 대한 처리
    //    }
    //}
    //public static class ConvertToCommand<T> where T : CudDTO
    //{
    //    public static T Convert(this T t, CommandOption option)
    //    {

    //    }
    //}
    public class CudDTO 
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CenterId { get; set; }
    }
    public class CenterCudDTO : CudDTO
    {
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
    public class CommodityCudDTO : CudDTO
    {
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public string? CategoryId { get; set; }
    }
    public class StatusCudDTO : CudDTO
    {

    }
 
    public class CreateDTO : CudDTO
    {

    }
    public class UpdateDTO : CudDTO
    {

    }
    public class DeleteDTO : CudDTO
    {

    }
}

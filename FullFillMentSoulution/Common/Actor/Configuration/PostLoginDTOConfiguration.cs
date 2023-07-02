using Common.Actor.Builder;
using Common.Actor.Configuration.Validator;
using Common.DTO;
using FrontCommon.Actor;

namespace Common.Actor.Configuration
{
    public class PostLoginDTOConfiguration : IDtoTypeCommandConfiguration<LoginModel>
    {
        public void Configure(DtoTypeCommandBuilder<LoginModel> builder)
        {
            // 기본 주소와 경로 설정
            builder.SetRoute("api/login") // 경로 설정
                   .SetServerBaseAddress("http://example.com")
                   .SetValidator(new LoginValidator());
        }
    }
    public class PostLogOutDTOConfiguration : IDtoTypeCommandConfiguration<LogoutModel>
    {
        public void Configure(DtoTypeCommandBuilder<LogoutModel> builder)
        {
            // 기본 주소와 경로 설정
            builder.SetRoute("api/login") // 경로 설정
                   .SetServerBaseAddress("http://example.com");
        }
    }
    public class PostRegisterDTOConfiguartion : IDtoTypeCommandConfiguration<RegisterModel>
    {
        public void Configure(DtoTypeCommandBuilder<RegisterModel> builder)
        {
            builder.SetRoute("api/login") // 경로 설정
                   .SetServerBaseAddress("http://example.com")
                   .SetValidator(new RegisterValidator());
        }
    }
}

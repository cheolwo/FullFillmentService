using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 주문Common.DTO.For주문;
using 주문FrontCommon.Actor;

namespace 주문Common.Actor.Config
{
    public class Create주문DtoConfiguration : IDtoTypeCommandConfiguration<Create주문DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create주문DTO> builder)
        {
            builder
                .SetValidator(new Create주문DtoValidator())
                .SetServerBaseRouteInfo(new ServerBaseRouteInfo
                {
                    Route = "create/order",
                    BaseAddress = "https://api-gateway.example.com",
                    UseApiGateway = true
                })
                .SetServerBaseRouteInfo(new ServerBaseRouteInfo
                {
                    Route = "create/order",
                    BaseAddress = "https://order-server.example.com",
                    UseApiGateway = true
                });
        }
    }
    public class Delete주문DtoConfiguration : IDtoTypeCommandConfiguration<Delete주문DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete주문DTO> builder)
        {
            builder
                .SetServerBaseRouteInfo(new ServerBaseRouteInfo
                {
                    Route = "delete/order",
                    BaseAddress = "https://business-server.example.com",
                    UseApiGateway = false
                });
        }
    }
    public class Update주문DtoConfiguration : IDtoTypeCommandConfiguration<Update주문DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update주문DTO> builder)
        {
            builder
                .SetValidator(new Update주문DtoValidator())
                .SetServerBaseRouteInfo(new ServerBaseRouteInfo
                {
                    Route = "update/order",
                    BaseAddress = "https://business-server.example.com",
                    UseApiGateway = false
                });
        }
    }

    public class Create주문DtoValidator : IValidator<Create주문DTO>
    {
        public bool CanValidateInstancesOfType(Type type)
        {
            return type == typeof(Create주문DTO);
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            // 필요한 경우 IValidatorDescriptor 구현을 반환
            return null;
        }

        public ValidationResult Validate(Create주문DTO instance)
        {
            // 필요한 경우 동기적인 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.주문명))
            {
                validationResult.Errors.Add(new ValidationFailure("주문명", "주문명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public ValidationResult Validate(IValidationContext context)
        {
            if (context.InstanceToValidate is Create주문DTO instance)
            {
                return Validate(instance);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateAsync(Create주문DTO instance, CancellationToken cancellation = default)
        {
            // 필요한 경우 비동기 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.주문명))
            {
                validationResult.Errors.Add(new ValidationFailure("주문명", "주문명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            if (context.InstanceToValidate is Create주문DTO instance)
            {
                return ValidateAsync(instance, cancellation);
            }

            return Task.FromResult(new ValidationResult());
        }
    }
    public class Update주문DtoValidator : IValidator<Update주문DTO>
    {
        public bool CanValidateInstancesOfType(Type type)
        {
            return type == typeof(Update주문DTO);
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            // 필요한 경우 IValidatorDescriptor 구현을 반환
            return null;
        }

        public ValidationResult Validate(Update주문DTO instance)
        {
            // 필요한 경우 동기적인 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.주문명))
            {
                validationResult.Errors.Add(new ValidationFailure("주문명", "주문명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public ValidationResult Validate(IValidationContext context)
        {
            if (context.InstanceToValidate is Update주문DTO instance)
            {
                return Validate(instance);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateAsync(Update주문DTO instance, CancellationToken cancellation = default)
        {
            // 필요한 경우 비동기 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.주문명))
            {
                validationResult.Errors.Add(new ValidationFailure("주문명", "주문명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            if (context.InstanceToValidate is Update주문DTO instance)
            {
                return ValidateAsync(instance, cancellation);
            }

            return Task.FromResult(new ValidationResult());
        }
    }
}

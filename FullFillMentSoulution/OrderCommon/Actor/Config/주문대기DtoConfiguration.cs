using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 주문Common.DTO.주문대기;

namespace 주문Common.Actor.Config
{
    public class Create주문대기DtoConfiguration : IDtoTypeCommandConfiguration<Create주문대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create주문대기DTO> builder)
        {
            builder
                .SetValidator(new Create주문대기DtoValidator())
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
    public class Delete주문대기DtoConfiguration : IDtoTypeCommandConfiguration<Delete주문대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete주문대기DTO> builder)
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
    public class Update주문대기DtoConfiguration : IDtoTypeCommandConfiguration<Update주문대기DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update주문대기DTO> builder)
        {
            builder
                .SetValidator(new Update주문대기DtoValidator())
                .SetServerBaseRouteInfo(new ServerBaseRouteInfo
                {
                    Route = "update/order",
                    BaseAddress = "https://business-server.example.com",
                    UseApiGateway = false
                });
        }
    }

    public class Create주문대기DtoValidator : IValidator<Create주문대기DTO>
    {
        public bool CanValidateInstancesOfType(Type type)
        {
            return type == typeof(Create주문대기DTO);
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            // 필요한 경우 IValidatorDescriptor 구현을 반환
            return null;
        }

        public ValidationResult Validate(Create주문대기DTO instance)
        {
            // 필요한 경우 동기적인 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new FluentValidation.Results.ValidationResult();

            // 예시: 주문대기 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.Name))
            {
                validationResult.Errors.Add(new ValidationFailure("주문대기명", "주문대기명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public ValidationResult Validate(IValidationContext context)
        {
            if (context.InstanceToValidate is Create주문대기DTO instance)
            {
                return Validate(instance);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateAsync(Create주문대기DTO instance, CancellationToken cancellation = default)
        {
            // 필요한 경우 비동기 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문대기 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.Name))
            {
                validationResult.Errors.Add(new ValidationFailure("주문대기명", "주문대기명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            if (context.InstanceToValidate is Create주문대기DTO instance)
            {
                return ValidateAsync(instance, cancellation);
            }

            return Task.FromResult(new ValidationResult());
        }
    }
    public class Update주문대기DtoValidator : IValidator<Update주문대기DTO>
    {
        public bool CanValidateInstancesOfType(Type type)
        {
            return type == typeof(Update주문대기DTO);
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            // 필요한 경우 IValidatorDescriptor 구현을 반환
            return null;
        }

        public ValidationResult Validate(Update주문대기DTO instance)
        {
            // 필요한 경우 동기적인 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문대기 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.Name))
            {
                validationResult.Errors.Add(new ValidationFailure("주문대기명", "주문대기명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public ValidationResult Validate(IValidationContext context)
        {
            if (context.InstanceToValidate is Update주문대기DTO instance)
            {
                return Validate(instance);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateAsync(Update주문대기DTO instance, CancellationToken cancellation = default)
        {
            // 필요한 경우 비동기 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문대기 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.Name))
            {
                validationResult.Errors.Add(new ValidationFailure("주문대기명", "주문대기명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            if (context.InstanceToValidate is Update주문대기DTO instance)
            {
                return ValidateAsync(instance, cancellation);
            }

            return Task.FromResult(new ValidationResult());
        }
    }
    public class Delete주문대기DtoValidator : IValidator<Delete주문대기DTO>
    {
        public bool CanValidateInstancesOfType(Type type)
        {
            return type == typeof(Delete주문대기DTO);
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            // 필요한 경우 IValidatorDescriptor 구현을 반환
            return null;
        }

        public ValidationResult Validate(Delete주문대기DTO instance)
        {
            // 필요한 경우 동기적인 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문대기 DTO의 필드 검증
            if (instance.Name != null)
            {
                validationResult.Errors.Add(new ValidationFailure("주문대기Id", "유효한 주문대기Id가 필요합니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public ValidationResult Validate(IValidationContext context)
        {
            if (context.InstanceToValidate is Delete주문대기DTO instance)
            {
                return Validate(instance);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateAsync(Delete주문대기DTO instance, CancellationToken cancellation = default)
        {
            // 필요한 경우 비동기 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            //// 예시: 주문대기 DTO의 필드 검증
            //if (instance.Id <= 0)
            //{
            //    validationResult.Errors.Add(new ValidationFailure("주문대기Id", "유효한 주문대기Id가 필요합니다."));
            //}

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            if (context.InstanceToValidate is Delete주문대기DTO instance)
            {
                return ValidateAsync(instance, cancellation);
            }

            return Task.FromResult(new ValidationResult());
        }
    }
}

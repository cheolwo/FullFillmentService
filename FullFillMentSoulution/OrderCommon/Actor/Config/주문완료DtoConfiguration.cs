using Common.Actor.Builder;
using FluentValidation;
using FluentValidation.Results;
using FrontCommon.Actor;
using 주문Common.DTO.주문완료;

namespace 주문Common.Actor.Config
{
    public class Create주문완료DtoConfiguration : IDtoTypeCommandConfiguration<Create주문완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Create주문완료DTO> builder)
        {
            builder
                .SetValidator(new Create주문완료DtoValidator())
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
    public class Delete주문완료DtoConfiguration : IDtoTypeCommandConfiguration<Delete주문완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Delete주문완료DTO> builder)
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
    public class Update주문완료DtoConfiguration : IDtoTypeCommandConfiguration<Update주문완료DTO>
    {
        public void Configure(DtoTypeCommandBuilder<Update주문완료DTO> builder)
        {
            builder
                .SetValidator(new Update주문완료DtoValidator())
                .SetServerBaseRouteInfo(new ServerBaseRouteInfo
                {
                    Route = "update/order",
                    BaseAddress = "https://business-server.example.com",
                    UseApiGateway = false
                });
        }
    }

    public class Create주문완료DtoValidator : IValidator<Create주문완료DTO>
    {
        public bool CanValidateInstancesOfType(Type type)
        {
            return type == typeof(Create주문완료DTO);
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            // 필요한 경우 IValidatorDescriptor 구현을 반환
            return null;
        }

        public ValidationResult Validate(Create주문완료DTO instance)
        {
            // 필요한 경우 동기적인 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new FluentValidation.Results.ValidationResult();

            // 예시: 주문완료 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.Name))
            {
                validationResult.Errors.Add(new ValidationFailure("주문완료명", "주문완료명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public ValidationResult Validate(IValidationContext context)
        {
            if (context.InstanceToValidate is Create주문완료DTO instance)
            {
                return Validate(instance);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateAsync(Create주문완료DTO instance, CancellationToken cancellation = default)
        {
            // 필요한 경우 비동기 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문완료 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.Name))
            {
                validationResult.Errors.Add(new ValidationFailure("주문완료명", "주문완료명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            if (context.InstanceToValidate is Create주문완료DTO instance)
            {
                return ValidateAsync(instance, cancellation);
            }

            return Task.FromResult(new ValidationResult());
        }
    }
    public class Update주문완료DtoValidator : IValidator<Update주문완료DTO>
    {
        public bool CanValidateInstancesOfType(Type type)
        {
            return type == typeof(Update주문완료DTO);
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            // 필요한 경우 IValidatorDescriptor 구현을 반환
            return null;
        }

        public ValidationResult Validate(Update주문완료DTO instance)
        {
            // 필요한 경우 동기적인 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문완료 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.Name))
            {
                validationResult.Errors.Add(new ValidationFailure("주문완료명", "주문완료명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public ValidationResult Validate(IValidationContext context)
        {
            if (context.InstanceToValidate is Update주문완료DTO instance)
            {
                return Validate(instance);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateAsync(Update주문완료DTO instance, CancellationToken cancellation = default)
        {
            // 필요한 경우 비동기 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문완료 DTO의 필드 검증
            if (string.IsNullOrWhiteSpace(instance.Name))
            {
                validationResult.Errors.Add(new ValidationFailure("주문완료명", "주문완료명은 필수입니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            if (context.InstanceToValidate is Update주문완료DTO instance)
            {
                return ValidateAsync(instance, cancellation);
            }

            return Task.FromResult(new ValidationResult());
        }
    }
    public class Delete주문완료DtoValidator : IValidator<Delete주문완료DTO>
    {
        public bool CanValidateInstancesOfType(Type type)
        {
            return type == typeof(Delete주문완료DTO);
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            // 필요한 경우 IValidatorDescriptor 구현을 반환
            return null;
        }

        public ValidationResult Validate(Delete주문완료DTO instance)
        {
            // 필요한 경우 동기적인 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            // 예시: 주문완료 DTO의 필드 검증
            if (instance.Name != null)
            {
                validationResult.Errors.Add(new ValidationFailure("주문완료Id", "유효한 주문완료Id가 필요합니다."));
            }

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public ValidationResult Validate(IValidationContext context)
        {
            if (context.InstanceToValidate is Delete주문완료DTO instance)
            {
                return Validate(instance);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateAsync(Delete주문완료DTO instance, CancellationToken cancellation = default)
        {
            // 필요한 경우 비동기 유효성 검증 로직을 구현
            // 유효성 검증에 실패할 경우 ValidationResult 객체에 오류 정보를 추가
            var validationResult = new ValidationResult();

            //// 예시: 주문완료 DTO의 필드 검증
            //if (instance.Id <= 0)
            //{
            //    validationResult.Errors.Add(new ValidationFailure("주문완료Id", "유효한 주문완료Id가 필요합니다."));
            //}

            // 추가적인 유효성 검증 로직 추가

            return validationResult;
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            if (context.InstanceToValidate is Delete주문완료DTO instance)
            {
                return ValidateAsync(instance, cancellation);
            }

            return Task.FromResult(new ValidationResult());
        }
    }
}

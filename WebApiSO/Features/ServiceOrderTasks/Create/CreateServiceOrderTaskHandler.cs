using FluentValidation;
using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Features.Requests;
using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.ServiceOrders.Models;
using WebApiSO.Data.Dtos;
using WebApiSO.Models;

namespace WebApiSO.Features.ServiceOrderTasks.Create
{
    public class CreateServiceOrderTasksRequestValidator : AbstractValidator<CreateServiceOrderTasksRequest>
    {
        public CreateServiceOrderTasksRequestValidator()
        {
            RuleFor(x => x.Observations)
                    .NotNull().WithMessage("Please enter a correct Observations");
            RuleFor(x => x.ExecutionDate)
                    .NotNull().WithMessage("Please enter a correct ExecutionDate");
            RuleFor(x => x.ServiceOrderTaskStateId)
                    .GreaterThan(0).WithMessage("Please enter a correct ServiceOrderTaskStateId");
            RuleFor(x => x.ServiceOrderId)
                    .GreaterThan(0).WithMessage("Please enter a correct ServiceOrderId");
            RuleFor(x => x.CustomFieldSOTask)
                    .NotNull().WithMessage("Please enter a correct CustomFieldSOTask");
        }
    }
    public class CreateServiceOrderTaskHandler : IServiceHandler<CreateServiceOrderTasksRequest, ServiceOrderTaskDto>
    {
        private readonly IRepository repository;
        private readonly IValidator<CreateServiceOrderTasksRequest> validator;

        public CreateServiceOrderTaskHandler([FromKeyedServices("SO_Repository")] IRepository repository, 
                                             IValidator<CreateServiceOrderTasksRequest> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<Result<ServiceOrderTaskDto>> Handle(CreateServiceOrderTasksRequest request)
        {
            var model = validator.Validate(request);
            if (!model.IsValid)
                return Result<ServiceOrderTaskDto>.Failure(model.Errors.Select(e => e.ErrorMessage), CustomStatusCode.StatusBadRequest);

            List<string> errors = [];
            if (!repository.Exist<ServiceOrderTaskState>(request.ServiceOrderTaskStateId))
                errors.Add($"{typeof(ServiceOrderTaskState).Name} not found");

            if (!repository.Exist<ServiceOrder>(request.ServiceOrderId))
                errors.Add($"{typeof(ServiceOrder).Name} not found");

            if (errors.Count > 0)
                return Result<ServiceOrderTaskDto>.Failure(errors, CustomStatusCode.StatusBadRequest);

            var entity = CustomServiceOrderTask.Create
                (request.Observations, request.ExecutionDate, request.ServiceOrderTaskStateId, 
                 request.ServiceOrderId, request.CustomFieldSOTask);

            repository.Add(entity);
            await repository.SaveChangesAsync();

            var result = ServiceOrderTaskDto.ToDto(entity);

            return Result<ServiceOrderTaskDto>.SuccessWith(result, CustomStatusCode.StatusCreated);
        }
    }
}

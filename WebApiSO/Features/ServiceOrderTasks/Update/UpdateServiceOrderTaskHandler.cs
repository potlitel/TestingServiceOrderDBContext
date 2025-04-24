using FluentValidation;
using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Interfaces;
using WebApiSO.Models;

namespace WebApiSO.Features.ServiceOrderTasks.Update
{
    public class UpdateServiceOrderTasksRequestValidator : AbstractValidator<UpdateServiceOrderTasksRequest>
    {
        public UpdateServiceOrderTasksRequestValidator()
        {
            RuleFor(x => x.Id)
                    .GreaterThan(0).WithMessage("Please enter a correct Id");
            RuleFor(x => x.Observations)
                    .NotNull().WithMessage("Please enter a correct Observations");
            RuleFor(x => x.ExecutionDate)
                    .NotNull().WithMessage("Please enter a correct ExecutionDate");
            RuleFor(x => x.ServiceOrderTaskStateId)
                    .GreaterThan(0).WithMessage("Please enter a correct ServiceOrderId");
            RuleFor(x => x.CustomFieldSOTask)
                    .NotNull().WithMessage("Please enter a correct CustomFieldSOTask");
            RuleFor(x => x.IsActive)
                    .NotNull().WithMessage("Please enter a valid value");
        }
    }
    public class UpdateServiceOrderTaskHandler : IServiceHandlerWithoutResponse<UpdateServiceOrderTasksRequest>
    {
        private readonly IRepository repository;
        private readonly IValidator<UpdateServiceOrderTasksRequest> validator;

        public UpdateServiceOrderTaskHandler([FromKeyedServices("SO_Repository")] IRepository repository, 
                                             IValidator<UpdateServiceOrderTasksRequest> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<Result> Handle(UpdateServiceOrderTasksRequest request)
        {
            var model = validator.Validate(request);
            if (!model.IsValid)
                return Result.Failure(model.Errors.Select(e => e.ErrorMessage), CustomStatusCode.StatusBadRequest);

            var entity = repository.GetById<CustomServiceOrderTask>(request.Id);
            if (entity is null)
                return Result.Failure([$"{typeof(CustomServiceOrderTask).Name} Not Found"], CustomStatusCode.StatusNotFound);

            entity.Update(request.Observations, request.ExecutionDate, request.ServiceOrderTaskStateId, request.CustomFieldSOTask, request.IsActive);

            repository.Update(entity);
            await repository.SaveChangesAsync();

            return Result.Success(CustomStatusCode.StatusUpdated);
        }
    }
}

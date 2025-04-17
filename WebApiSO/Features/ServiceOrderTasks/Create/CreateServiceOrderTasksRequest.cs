using FSA.Core.ServiceOrders.Models.Masters;

namespace WebApiSO.Features.ServiceOrderTasks.Create
{
    public record CreateServiceOrderTasksRequest(string? Observations, DateTime ExecutionDate ,long ServiceOrderTaskStateId,
                                                 long ServiceOrderId, string CustomFieldSOTask);
}

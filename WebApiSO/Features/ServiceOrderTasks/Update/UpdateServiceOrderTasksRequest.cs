namespace WebApiSO.Features.ServiceOrderTasks.Update
{
    public record UpdateServiceOrderTasksRequest(int Id, string? Observations, DateTime ExecutionDate, long ServiceOrderTaskStateId,
                                                 string CustomFieldSOTask, bool IsActive);
}

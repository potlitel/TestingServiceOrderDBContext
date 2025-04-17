using FSA.Core.ServiceOrders.Models;

namespace WebApiSO.Models
{
    public class CustomServiceOrderTask : ServiceOrderTask
    {
        public string CustomFieldSOTask { get; set; } = string.Empty;

        public static CustomServiceOrderTask Create(string? Observations, DateTime ExecutionDate, long ServiceOrderTaskStateId,
                                                    long ServiceOrderId, string CustomFieldSOTask)
        {
            return new CustomServiceOrderTask
            {
                Observations = Observations,
                ExecutionDate = ExecutionDate,
                ServiceOrderTaskStateId = ServiceOrderTaskStateId,
                ServiceOrderId = ServiceOrderId,
                CustomFieldSOTask = CustomFieldSOTask
            };
        }
    }
}

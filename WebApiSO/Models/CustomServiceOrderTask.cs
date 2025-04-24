using FSA.Core.ServiceOrders.Models;

namespace WebApiSO.Models
{
    public class CustomServiceOrderTask : ServiceOrderTask
    {
        public string CustomFieldSOTask { get; set; } = string.Empty;

        /// <summary>
        /// <see cref="Create"/>
        /// </summary>
        /// <param name="Observations"></param>
        /// <param name="ExecutionDate"></param>
        /// <param name="ServiceOrderTaskStateId"></param>
        /// <param name="ServiceOrderId"></param>
        /// <param name="CustomFieldSOTask"></param>
        /// <returns></returns>
        public static CustomServiceOrderTask Create(string? Observations, DateTime ExecutionDate, long ServiceOrderTaskStateId,
                                                    long ServiceOrderId, string? CustomFieldSOTask)
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

        /// <summary>
        /// <see cref="Update"/>: Actualiza los datos de una entidad tipo <see cref="CustomServiceOrderTask"/>.
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="executionDate"></param>
        /// <param name="serviceOrderTaskStateId"></param>
        /// <param name="customFieldSOTask"></param>
        /// <param name="isActive"></param>
        public virtual void Update(string? observations, DateTime executionDate, long serviceOrderTaskStateId,
                                   string? customFieldSOTask, bool isActive)
        {
            Observations = observations;
            ExecutionDate = executionDate;
            ServiceOrderTaskStateId = serviceOrderTaskStateId;
            CustomFieldSOTask = customFieldSOTask; 
            base.Update(isActive);
        }
    }
}

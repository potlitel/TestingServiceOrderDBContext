using FSA.Core.ServiceOrders.Models;

namespace WebApiSO.Models
{
    public class CustomServiceOrderTask : ServiceOrderTask
    {
        public string CustomFieldSOTask { get; set; } = string.Empty;
    }
}

using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSO.Models
{
    public class CustomServiceOrderRegister : ServiceOrderRegister
    {
        //https://stackoverflow.com/questions/58734118/to-resolve-this-configure-the-foreign-key-properties-explicitly-on-at-least-one
        [ForeignKey("SOId")]
        public virtual ServiceOrderDto? ServiceOrder { get; set; }
    }
}

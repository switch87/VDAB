using System.ComponentModel.DataAnnotations;

namespace MVC_Tuincentrum.Models
{
    public class PlantenProperties
    {
    [Range(0,1000,ErrorMessageResourceType = typeof(Resources.Teksten),ErrorMessageResourceName = "RangePrijs")]
        public decimal VerkoopPrijs { get; set; }
    }
}
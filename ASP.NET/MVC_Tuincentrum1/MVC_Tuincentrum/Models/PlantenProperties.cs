using System.ComponentModel.DataAnnotations;
using MVC_Tuincentrum.App_GlobalResources;

namespace MVC_Tuincentrum.Models
{
    public class PlantenProperties
    {
        [Display(ResourceType = typeof (Teksten), Name = "LabelPrijs")]
        [Range(0, 1000, ErrorMessageResourceType = typeof (Teksten), ErrorMessageResourceName = "RangePrijs")]
        public decimal VerkoopPrijs { get; set; }
    }
}
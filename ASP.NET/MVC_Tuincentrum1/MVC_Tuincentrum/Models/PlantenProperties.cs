using System.ComponentModel.DataAnnotations;

namespace MVC_Tuincentrum.Models
{
    public class PlantenProperties
    {
        [Display( ResourceType = typeof( App_GlobalResources.Teksten ), Name = "LabelPrijs" )]
        [Range( 0, 1000, ErrorMessageResourceType = typeof( App_GlobalResources.Teksten ), ErrorMessageResourceName = "RangePrijs" )]
        public decimal VerkoopPrijs { get; set; }
    }
}
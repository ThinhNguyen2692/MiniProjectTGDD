using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public string OrderId { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public DateTime? SetupTime { get; set; }
        public int TotalMoney { get; set; }
        public int TotalPromotionalPrice { get; set; }
        public int IntoMoney { get; set; }
        public string ProvinceCity { get; set; } = null!;
        public string District { get; set; } = null!;
        public string CommuneWard { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
        public string BillingInformation { get; set; } = null!;
        public int? OrderStatus { get; set; }

        public virtual Customer CustomerPhoneNavigation { get; set; } = null!;
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}

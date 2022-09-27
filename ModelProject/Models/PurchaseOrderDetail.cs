using System;
using System.Collections.Generic;

namespace ModelProject.Models
{
    public partial class PurchaseOrderDetail
    {
        public PurchaseOrderDetail()
        {
            GiftDetails = new HashSet<GiftDetail>();
        }

        public int OrderDetail { get; set; }
        public string OrderId { get; set; } = null!;
        public string OrderProduct { get; set; } = null!;
        public string OrderProudctName { get; set; } = null!;
        public string OrderProductPhoto { get; set; } = null!;
        public int OrderPrice { get; set; }
        public int OrderPromotion { get; set; }
        public string? EventName { get; set; }
        public int OrderQuantity { get; set; }
        public int MoneyReduced { get; set; }
        public int Total { get; set; }
        public int MoneyProduct { get; set; }
        public int? ColorId { get; set; }

        public virtual PurchaseOrder Order { get; set; } = null!;
        public virtual ICollection<GiftDetail> GiftDetails { get; set; }
    }
}

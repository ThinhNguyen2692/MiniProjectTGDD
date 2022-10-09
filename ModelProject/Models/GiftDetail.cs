using System;
using System.Collections.Generic;

namespace ModelProject.Models
{
    public partial class GiftDetail
    {
        public int Id { get; set; }
        public int OrderDetail { get; set; }
        public string? GiftProduct { get; set; }
        public string ProuctName { get; set; } = null!;
        public int ProductPrice { get; set; }
        public string ProductPhoto { get; set; } = null!;
        public int? GiftQuantiy { get; set; }

        public virtual PurchaseOrderDetail OrderDetailNavigation { get; set; } = null!;
    }
}

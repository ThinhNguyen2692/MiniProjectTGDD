using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class Customer
    {
        public Customer()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string CustomerPhone { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string? ProvinceCity { get; set; }
        public string? District { get; set; }
        public string? CommuneWard { get; set; }
        public string? CustomerAddress { get; set; }
        public DateTime? RegistrationTime { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}

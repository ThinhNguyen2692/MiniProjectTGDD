using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class VersionQuantity
    {
        public int Id { get; set; }
        public string VersionId { get; set; } = null!;
        public int ColorId { get; set; }
        public int? Quantity { get; set; }

        public VersionQuantity() { }

        public VersionQuantity(int Id, string VersionId, string ColorName, int? Quantity)
        {
            this.Id = Id;
            this.VersionId = VersionId;
            this.Quantity = Quantity;
            Color = new ProductColor();
            Color.ColorDescription = ColorName;
        }

        public virtual ProductColor Color { get; set; } = null!;
        public virtual ProductVersion Version { get; set; } = null!;
    }
}

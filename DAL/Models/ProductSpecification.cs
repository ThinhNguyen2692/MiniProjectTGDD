using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProductSpecification
    {
        public ProductSpecification()
        {
            InformationProperties = new HashSet<InformationProperty>();
        }

        public int SpecificationsId { get; set; }
        public string TypeId { get; set; } = null!;
        public string SpecificationsName { get; set; } = null!;
        public string? SpecificationsDescription { get; set; }

        public ProductSpecification( string typeId, string specificationsName, string? specificationsDescription)
        {
            TypeId = typeId;
            SpecificationsName = specificationsName;
            SpecificationsDescription = specificationsDescription;
        }

        public virtual ProductType Type { get; set; } = null!;
        public virtual ICollection<InformationProperty> InformationProperties { get; set; }
    }
}

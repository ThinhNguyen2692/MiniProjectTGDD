using System;
using System.Collections.Generic;

namespace ModelProject.Models
{
    public partial class InformationProperty
    {
        public InformationProperty()
        {
            PropertiesValues = new HashSet<PropertiesValue>();
        }

        public int PropertiesId { get; set; }
        public int SpecificationsId { get; set; }
        public string PropertiesName { get; set; } = null!;
        public string? PropertiesDescription { get; set; }

        public InformationProperty(int SpecificationsId, string PropertiesName, string? PropertiesDescription)
        {
            this.SpecificationsId = SpecificationsId;
            this.PropertiesName = PropertiesName;
            this.PropertiesDescription = PropertiesDescription;
        }

        public virtual ProductSpecification Specifications { get; set; } = null!;
        public virtual ICollection<PropertiesValue> PropertiesValues { get; set; }
    }
}

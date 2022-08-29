using System;
using System.Collections.Generic;

namespace DAL.Models
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

        public InformationProperty( int specificationsId, string propertiesName, string? propertiesDescription)
        {
          
            SpecificationsId = specificationsId;
            PropertiesName = propertiesName;
            PropertiesDescription = propertiesDescription;
          
        }
        public InformationProperty(int PropertiesId, int specificationsId, string propertiesName, string? propertiesDescription)
        {

            this.PropertiesId = PropertiesId;
            SpecificationsId = specificationsId;
            PropertiesName = propertiesName;
            PropertiesDescription = propertiesDescription;

        }
        public virtual ProductSpecification Specifications { get; set; } = null!;
        public virtual ICollection<PropertiesValue> PropertiesValues { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ModelProject.Models
{
    public partial class PropertiesValue
    {
        public int ValueId { get; set; }
        public string VersionId { get; set; } = null!;
        public int PropertiesId { get; set; }
        public string? Value { get; set; }

        public PropertiesValue() { }

      public PropertiesValue(int valueId, string versionId, int propertiesId, string? value)
        {
            ValueId = valueId;
            VersionId = versionId;
            PropertiesId = propertiesId;
            Value = value;
           
        }

        public virtual InformationProperty Properties { get; set; } = null!;
        public virtual ProductVersion Version { get; set; } = null!;
    }
}

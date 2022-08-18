using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class PropertiesValue
    {
        public int ValueId { get; set; }
        public string VersionId { get; set; } = null!;
        public int PropertiesId { get; set; }
        public string? Value { get; set; }

        public virtual InformationProperty Properties { get; set; } = null!;
        public virtual ProductVersion Version { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.Models
{
    public class ProductVerSionDetailInformation
    {
        public ProductVerSionDetailInformation() { }

        public int vauleId { get; set; }
        public string SpecificationName { get; set; }
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
    public class ProductVerSionInformation{
        public ProductVerSionInformation() { }
        public List<ProductVerSionDetailInformation> productVerSionDetailInformation { get; set; } = new List<ProductVerSionDetailInformation>();
        }
}

using System.Collections.Generic;

namespace RJR.Core
{
    public class Product
    {
        public int ItemNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string BrandGroup { get; set; }
        public string BrandStyle { get; set; }
        public List<Packing> Packings { get; set; } = new List<Packing>();
    }
}
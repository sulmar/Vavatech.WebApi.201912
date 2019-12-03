using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.WebApi.Models
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsRemoved { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class GoodEntity : BaseEntity
    {
        public string Name { get; set; }
        public int ManufacturId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}

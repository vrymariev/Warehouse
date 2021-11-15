using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class ManufacturEntity : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}

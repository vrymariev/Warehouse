using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class GoodEntity : BaseEntity
    {
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        public virtual ManufacturerEntity Manufacturer { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        public string Category { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Count { get; set; }
    }
}

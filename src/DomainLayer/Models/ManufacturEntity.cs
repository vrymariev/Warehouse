
namespace DomainLayer.Models
{
    public class ManufacturerEntity : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual CountryEntity Country { get; set; }
    }
}

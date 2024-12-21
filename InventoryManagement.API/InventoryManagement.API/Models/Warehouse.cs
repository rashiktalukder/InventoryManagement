using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.API.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Location { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

namespace InventoryManagement.API.Models
{
    public class Warehouse
    {
        public int Id { get; set; } // Primary Key
        public int CompanyId { get; set; } // Foreign Key referencing Company(Id)
        public int ProductId { get; set; } // Foreign Key referencing Product(Id)
        public int Quantity { get; set; } = 0; 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false; // Soft delete flag

        // Navigation properties
        /*public Company Company { get; set; }*/
        public Product Product { get; set; }
    }
}

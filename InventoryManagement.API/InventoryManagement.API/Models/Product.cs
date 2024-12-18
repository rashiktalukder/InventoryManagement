namespace InventoryManagement.API.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key
        public int CompanyId { get; set; } // Foreign Key referencing Company(Id)

        public string Name { get; set; } // Product Name
        public int Quantity { get; set; } // Quantity in stock
        public decimal Price { get; set; } // Price of the Product
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Automatically set at creation

        // Navigation property for the related Company
        public Company Company { get; set; }
    }

}

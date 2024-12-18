namespace InventoryManagement.API.Models
{
    public class Users
    {
        public int Id { get; set; }
        public int CompanyId { get; set; } // Foreign Key referencing Company(Id)
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "Marketing Manager"; // Default role
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Default value

        // Navigation property for the Company
        public Company Company { get; set; }
    }
}

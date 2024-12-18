namespace InventoryManagement.API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property for related Users
        public ICollection<Users> Users { get; set; }
    }
}

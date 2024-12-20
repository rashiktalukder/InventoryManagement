namespace InventoryManagement.API.Models.DTOs
{
    public class CompanyResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

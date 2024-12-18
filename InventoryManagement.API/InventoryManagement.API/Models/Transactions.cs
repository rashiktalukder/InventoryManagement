namespace InventoryManagement.API.Models
{
    public class Transactions
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }

        //Navigation Properties
        /*public Users Users { get; set; }*/
        public Product Products { get; set; }
    }
}

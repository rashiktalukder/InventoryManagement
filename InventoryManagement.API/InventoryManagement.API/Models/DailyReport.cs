namespace InventoryManagement.API.Models
{
    public class DailyReport
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public DateTime ReportDate { get; set; }

        public double TotalSales { get; set; }
        public double TotalProfit { get; set; }
        public int RemainingInventory { get; set; }
        public DateTime CreatedAt { get; set; }

        //navigation Property
        public Company Company { get; set; }
    }
}

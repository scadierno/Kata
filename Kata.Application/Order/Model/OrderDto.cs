namespace Kata.Application.Order.Model
{
    public class OrderDto
    {
        public int Id { get; set; }
        public char Priority { get; set; }
        public DateOnly Date { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string ItemType { get; set; }
        public string SalesChannel { get; set; }
        public DateOnly ShipDate { get; set; }
        public int UnitsSold { get; set; }
        public float UnitPrice { get; set; }
        public float UnitCost { get; set; }
        public float TotalRevenue { get; set; }
        public float TotalCost { get; set; }
        public float TotalProfit { get; set; }
    }
}

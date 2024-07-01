using System.Text.Json.Serialization;

namespace Kata.Application.Order.Model
{
    public class OrderResponseDto
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("content")]
        public IEnumerable<OrderApi> Content { get; set; }
        [JsonPropertyName("links")]
        public Link Links { get; set; }
    }

    public class OrderApi
    {
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("region")]
        public string Region { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("item_type")]
        public string ItemType { get; set; }
        [JsonPropertyName("sales_channel")]
        public string SalesChannel { get; set; }
        [JsonPropertyName("priority")]
        public string Priority { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("ship_date")]
        public string ShipDate { get; set; }
        [JsonPropertyName("units_sold")]
        public int UnitsSold { get; set; }
        [JsonPropertyName("unit_price")]
        public float UnitPrice { get; set; }
        [JsonPropertyName("unit_cost")]
        public float UnitCost { get; set; }
        [JsonPropertyName("total_revenue")]
        public float TotalRevenue { get; set; }
        [JsonPropertyName("total_cost")]
        public float TotalCost { get; set; }
        [JsonPropertyName("total_profit")]
        public float TotalProfit { get; set; }
        [JsonPropertyName("links")]
        public BaseLink Links { get; set; }
    }

    public class Link : BaseLink
    {
        [JsonPropertyName("next")]
        public string Next { get; set; }
    }

    public class BaseLink
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}

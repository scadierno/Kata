namespace Kata.Application.Order.Model
{
    public class OrderSummaryDto
    {
        public IEnumerable<CategoryDto> Regions { get; set; }
        public IEnumerable<CategoryDto> Countries { get; set; }
        public IEnumerable<CategoryDto> ItemTypes { get; set; }
        public IEnumerable<CategoryDto> SalesChannels { get; set; }
        public IEnumerable<CategoryDto> OrderPriorities { get; set; }
    }

    public class CategoryDto
    {
        public string Name { get; set; }
        public int Total { get; set; }
    }
}

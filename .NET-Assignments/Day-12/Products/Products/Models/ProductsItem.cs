namespace Products.Models
{
    public class ProductsItem
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public int StockQuantity { get; set; }
    }
}

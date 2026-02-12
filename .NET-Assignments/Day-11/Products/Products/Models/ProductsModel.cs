namespace Products.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string? Category { get; set; }

        public bool IsAvailable => StockQuantity > 0;

        public bool IsExpensive => Price >= 1000m;
    }
}

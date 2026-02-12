namespace Products.DTOs
{
    public class ProductUpdateDTO
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Category { get; set; }
    }
}

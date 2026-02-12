namespace Products.DTOs
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Category { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsExpensive { get; set; }
    }
}

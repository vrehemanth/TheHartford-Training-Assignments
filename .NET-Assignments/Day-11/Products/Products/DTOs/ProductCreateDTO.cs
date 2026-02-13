using System.ComponentModel.DataAnnotations;

namespace Products.DTOs
{
    public class ProductCreateDTO
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string? Category { get; set; }
    }
}

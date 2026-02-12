using Products.Models;
namespace Products.Services
{
    public class ProductService : IProductService
    {
        private static List<ProductsModel> productList = new()
        {
            new ProductsModel
            {
                Id = 1,
                Name = "Laptop",
                Price = 65000m,
                StockQuantity = 10,
                Category = "Electronics"
            },
            new ProductsModel
            {
                Id = 2,
                Name = "Smartphone",
                Price = 28000m,
                StockQuantity = 25,
                Category = "Electronics"
            },
            new ProductsModel
            {
                Id = 3,
                Name = "Chair",
                Price = 7500m,
                StockQuantity = 5,
                Category = "Furniture"
            }
        };

        public List<ProductsModel> GetAll() => productList;

        public ProductsModel? GetById(int id) =>
            productList.FirstOrDefault(p => p.Id == id);

        public ProductsModel Create(ProductsModel product)
        {
            product.Id = productList.Any() ? productList.Max(p => p.Id) + 1 : 1;
            productList.Add(product);
            return product;
        }

        public bool Update(int id, ProductsModel updatedProduct)
        {
            var product = GetById(id);
            if (product == null) return false;

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.StockQuantity = updatedProduct.StockQuantity;
            product.Category = updatedProduct.Category;

            return true;
        }
        public bool UpdatePrice(int id, decimal price)
        {
            var product = GetById(id);
            if (product == null || price <= 0) return false;

            product.Price = price;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;

            productList.Remove(product);
            return true;
        }
    }
}

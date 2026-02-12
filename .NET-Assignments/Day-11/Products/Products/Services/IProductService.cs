using Products.Models;

namespace Products.Services
{
    public interface IProductService
    {
        List<ProductsModel> GetAll();
        ProductsModel? GetById(int id);
        ProductsModel Create(ProductsModel product);
        bool Update(int id, ProductsModel updatedProduct);
        bool UpdatePrice(int id, decimal price);
        bool Delete(int id);
    }
}

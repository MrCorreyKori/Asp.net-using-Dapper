using Products.Models;

namespace Products.Repository
{
    public interface IProductRepository
    {
        Product Find(int id);

        List<Product> GetAll();

        Product Add(Product product);

        Product Update(Product product);

        void Remove(int id);
    }
}

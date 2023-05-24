using Microsoft.EntityFrameworkCore;

using Products.Data;

using Products.Models;


namespace Products.Repository
{
    public class ProductRepositoryEF : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepositoryEF(ApplicationDbContext db)
        {
            _db = db;
        }
        public Product Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public Product Find(int id)
        {
          return  _db.Products.FirstOrDefault(u=>u.Id==id);                            // used lambda
                                                                                       //firstOrDefault =if find object return or return object do not throw error
        }

        public List<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public void Remove(int id)
        {
            Product product = _db.Products.FirstOrDefault(p=>p.Id==id);
            _db.Products.Remove(product);
                _db.SaveChanges();
            return;
        }

        public Product Update(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
            return product;
        }
    }
}

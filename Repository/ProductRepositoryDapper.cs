using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Products.Data;

using Products.Models;
using System.Data;

namespace Products.Repository
{
    public class ProductRepositoryDapper : IProductRepository
    {
        private IDbConnection db;
        public ProductRepositoryDapper(IConfiguration configuration)
        {
            //new sql connection for dapper
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Product Add(Product product)
        {
            var sql = "INSERT INTO Products (Products , Price) VALUES(@Products , @Price); "
                        + "SELECT CAST(SCOPE_IDENTITY() as int);";     //This line is used to retrieve the last inserted identity value 
            var id =db.Query<int>(sql, product).Single();

            product.Id = id;
            return product;
        }
         
        //------------------This is another way to write Add query----------------//
        /*public Product Add(Product product)
        {
            var sql = "INSERT INTO Products (Products , Price) VALUES(@Products , @Price); "
                        + "SELECT CAST(SCOPE_IDENTITY() as int);";     //This line is used to retrieve the last inserted identity value 
            var id = db.Query<int>(sql, new
            {
                product.Products,
                product.Price
            }).Single();

            product.Id = id;
            return product;
        }*/ 
        //------------------------------------------------------------------------//

        public Product Find(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id =@id";
            return db.Query<Product>(sql,new {@Id=id}).Single();   //Single is used as it return list
        }

        public List<Product> GetAll()
        {
            var sql = "SELECT * FROM Products";
            return db.Query<Product>(sql).ToList();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Products WHERE id=@Id";
            db.Execute(sql, new {@Id=id});  
        }

        public Product Update(Product product)
        {
            var sql = "UPDATE Products SET Products = @Products , Price = @Price WHERE id=@Id";
            db.Execute(sql, product);
            return product;
        }
    }
}

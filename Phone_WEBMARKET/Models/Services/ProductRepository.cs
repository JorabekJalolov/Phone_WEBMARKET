using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Models.Services
{
    public class ProductRepository:IProductRepository
    {
        private readonly InavationContext _db;

        public ProductRepository(InavationContext db)
        {
            _db = db;
        }
        public void addProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void deleteProduct(Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChanges();
        }



        //public string GetCategoryName(int id)
        //{

        //}

        public Product GetProduct(int id)
        {
            return _db.Products.FirstOrDefault(x => x.ID.Equals(id));
        }

        public IEnumerable<Product> GetProductCategory(int id)
        {
            var s = from product in _db.Products
                    where product.CategoryId == id
                    select product;
            return s;
        }

        public void updateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }
    }
}

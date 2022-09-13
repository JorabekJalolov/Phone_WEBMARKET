using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Models.Services
{
   public interface IProductRepository
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProductCategory(int id);
        //IEnumerable<Product> GetAllProduct(int id);
       // string GetCategoryName(int id);
        void addProduct(Product product);
        void deleteProduct(Product product);
        void updateProduct(Product product);
    }
}

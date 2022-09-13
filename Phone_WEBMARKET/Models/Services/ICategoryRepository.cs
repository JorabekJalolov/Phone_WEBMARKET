using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Models.Services
{
   public interface ICategoryRepository
    {
        Category GetCategory(int id);
        IEnumerable<Category> Searching(string searchstring);
        IEnumerable<Category> GetAllCategory();
        IEnumerable<Category> GetAll();
        void addCategory(Category category);
        void deleteCategory(Category category);
        void updateCategory(Category category);
        List<string> CategoryName();
    }
}

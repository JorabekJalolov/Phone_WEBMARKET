using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Models.Services
{
    public class CompanyRepository:ICategoryRepository
    {
        private readonly InavationContext _db;

        public CompanyRepository(InavationContext db)
        {
            _db = db;
        }

        public void addCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public List<string> CategoryName()
        {
            var result = from s in _db.Categories
                         select s.Name;
            return result.ToList();

        }

        public void deleteCategory(Category category)
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
           
                return _db.Categories.ToList();
            
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _db.Categories;
        }

        public Category GetCategory(int id)
        {
            return _db.Categories.FirstOrDefault(x => x.ID.Equals(id));
        }

        public IEnumerable<Category> Searching(string searchstring)
        {


            IEnumerable<Category> query = from x in _db.Categories select x;

                if (!string.IsNullOrEmpty(searchstring))
                {
                query= query.Where(e => e.Name.Contains(searchstring));
                                
                }
                   return  query;
            
        
       }

        public void updateCategory(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
    }
}


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Models.Services
{
    public class InavationContext:DbContext
    {
        public static InavationContext db { get; set; }
        public InavationContext(DbContextOptions<InavationContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
      
    }
}

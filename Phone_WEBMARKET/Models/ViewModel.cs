using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Models
{
    public class ViewModel
    {
        public static int CategoryID { get; set; }
        public static  IEnumerable<Product> GetProducts { get; set; }
        public static Category GetCategory { get; set; }
    }
}

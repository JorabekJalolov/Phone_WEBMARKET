using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
        [NotMapped]
        [Required]
        public IFormFile Image { get; set; }      

    }
}

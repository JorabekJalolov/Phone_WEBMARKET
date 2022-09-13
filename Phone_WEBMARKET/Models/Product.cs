 using Microsoft.AspNetCore.Http;
using Phone_WEBMARKET.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public int Inventar { get; set; }

        [Required(ErrorMessage ="Jihoz modeli ko'rsatilmagan!")]
        [Display(Name = "Jihoz Modeli")]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required(ErrorMessage ="Joylashgan xona ko'rsatilmagan!")]
        [Display(Name = "Joylashgan Xona")]
        public int Room { get; set; }
        [Required(ErrorMessage = "Javobgar shaxsni ko'rsating!")]
        [Display(Name = "Javobgar shaxs")]
        public string Responsible { get; set; }
        [Display(Name = "Qo'shimcha malumotlar")]
        public string MoreInformation { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public byte[] QRcode { get; set; }


    }
}

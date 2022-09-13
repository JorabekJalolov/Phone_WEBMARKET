
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phone_WEBMARKET.Models;
using Phone_WEBMARKET.Models.Services;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;


namespace Phone_WEBMARKET.Controllers
{
   
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;
        private readonly InavationContext _db;
        

        public ProductController(InavationContext db, IProductRepository productRepository, ICategoryRepository categoryRepository, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            _product = productRepository;
            _category = categoryRepository;
          
        }
         [HttpGet]
        public IActionResult Index(int id)
        {
            if (id != 0)
            {
                ViewModel.CategoryID = id;
                IEnumerable<Product> products = _db.Products.Include(l => l.Category).Where(l => l.CategoryId == id);
                ViewBag.count = products.Count();
                ViewBag.name = _category.GetCategory(id).Name;
                ViewBag.image = _category.GetCategory(id).Image;
                return View(products);

            }
            else
            {
                IEnumerable<Product> products = _db.Products.Include(l => l.Category).Where(l => l.CategoryId == ViewModel.CategoryID);
                ViewBag.count = products.Count();
                ViewBag.name = _category.GetCategory(ViewModel.CategoryID).Name;
                ViewBag.image = _category.GetCategory(ViewModel.CategoryID).Image;
                return View(products);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewData["CategoryName"] = new SelectList(_category.GetAllCategory(),"ID","Name");
            return View();
        }
        
        [HttpPost]
        
        public IActionResult Create(Product product)
        {
            product.CategoryId = ViewModel.CategoryID;
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode("Javobgar shaxs:"+product.Responsible, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(60);
            byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            product.QRcode = BitmapArray;
            if (ModelState.IsValid)
            {
            _product.addProduct(product);
            return RedirectToAction(nameof(Index),product.CategoryId);
            }
            else
            {
                ViewBag.company = _category.CategoryName();
                return View();
            }
         
            
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpGet]
        public  ActionResult Search(string searchstring)
        {
            ViewData["GetCategoryDetails"]=searchstring;
           IEnumerable<Category> empquery = _category.Searching(searchstring);
            return View(empquery);
            
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product product = _product.GetProduct(id);
           
            if (product == null)
            {
                return NotFound();
            }
            _product.deleteProduct(product);
            return RedirectToAction(nameof(Index));
        }
        public IEnumerable<Category> CategoryList()
        {
            return _category.GetAll();
        }
        public ActionResult Details(int id)
        {
            Product product = _product.GetProduct(id);
            return View(product);
        }

        // POST: CompanyController/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Product product = _product.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index",product.CategoryId);
        }
    }
    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
              using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phone_WEBMARKET.Models;
using Phone_WEBMARKET.Models.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _category;
        public HomeController(ICategoryRepository category)
        {
            _category = category;
        }
        //GET: CompanyController
        public ActionResult Index()
        {
            IEnumerable<Category> company = _category.GetAllCategory();
            return View(company);
        }
        [HttpGet]
        //public async Task<ActionResult> Index(string searchstring)
        //{
        //    ViewData["GetCategoryDetails"] = searchstring;
        //    IEnumerable<Category> empquery = _category.Searching(searchstring);
        //    return View(await empquery.AsNoTracking().ToListAsync());

        //}

        
        public IActionResult Index(string searchstring = null)
        {
            ViewData["GetCategoryDetails"] = searchstring;
            IEnumerable<Category> categories;
            if (!string.IsNullOrEmpty(searchstring)) {
                categories = _category.GetAllCategory().Where(s => s.Name.ToLower().Contains(searchstring.ToLower()));
            }
            else
            {
                categories = _category.GetAllCategory();
            }

            return View("Index", categories);
        }

            // GET: CompanyController/Details/5
            public ActionResult Details()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles ="admin")]
        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View();
        }
        
        

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create(Category company)
        {
            
                if (ModelState.IsValid)
                {
                    if (company.Image != null)
                    {
                        byte[] imageData = null;
                        
                        using (var binaryReader = new BinaryReader(company.Image.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)company.Image.Length); 
                        }
                        
                        company.Picture = imageData;
                    }

                    _category.addCategory(company);
                return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            
            
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

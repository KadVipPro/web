using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASG.Models;
using ASG.Context;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static ASG.Models.Product;
using ASG.Services;


namespace ASG.Controlleres

{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly DatabaseContext Context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private DatabaseContext db = new DatabaseContext();

        public ProductController(ILogger<ProductController> logger, DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            Context = context;
            this.webHostEnvironment = webHostEnvironment;
        }


        public IActionResult List()
        {
            var item = Context.Products.ToList();
            return View(item);

        }
        [HttpGet]
        public IActionResult Create()
        {
            var listHang = new SelectList(db.Categories.Select(c => c.TenHang).ToList(), "TenHang");
            ViewBag.TenHang = listHang;
            return View();

        }
        //[HttpPost]
        /*public async Task<IActionResult> Create(Product product, List<IFormFile> Anh)
        {
            foreach(var item in Anh)
            {
                if (item.Length > 0)
                {
                    using(var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        product.Anh = stream.ToArray();
                        
                    }
                }
            }
            db.Products.Add(product);
            db.SaveChanges();

            return View();

        }*/

        [HttpPost]
        public IActionResult Create(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Index()
        {

            var item = Context.Products.ToList();
            return View(item);

        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var listHang = new SelectList(db.Categories.Select(c => c.TenHang).ToList(), "TenHang");
            ViewBag.TenHang = listHang;

            return View("Edit", db.Products.Find(id));

        }

        [HttpPost]
        public IActionResult Edit(string id, Product product)
        {

            db.Products.Update(product);
            db.SaveChanges();
            return RedirectToAction("List");


        }
        public IActionResult Delete()
        {

            return View();

        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return RedirectToAction("List");
        }
     
        public IActionResult Home()
        {
            var listHang = new SelectList(db.Categories.Select(c => c.TenHang).ToList(), "TenHang");
            ViewBag.TenHang = listHang;
            var lstProduct = db.Products.ToList();
            return View(lstProduct);
         
        }
        

        [HttpPost]
        public async Task<IActionResult> Home(string searchString)
        {
            var movies = from m in db.Products
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.TenSp.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        public IActionResult HienThi(string id)
        {
            return View(db.Products.Find(id));

        }







    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASG.Context;
using ASG.Controlleres;
using ASG.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASG.Models;
using ASG.Services;

namespace ASG.Controllers
{
    public class CartController : Controller
    {
        ServiceProduct ser = new ServiceProduct();
        private readonly ILogger<ProductController> _logger;
        private readonly DatabaseContext Context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly DatabaseContext _databaseContext;

        public CartController(ILogger<ProductController> logger, DatabaseContext context, IWebHostEnvironment webHostEnvironment,DatabaseContext databaseContext)
        {
            _logger = logger;
            Context = context;
            this.webHostEnvironment = webHostEnvironment;
            _databaseContext = databaseContext;
        }

        
        public IActionResult Index(string id)
        {
           
           
            return View(_databaseContext.Products.Find(id));
        }

        //private int isExist(string id)
        //{
            
        //    List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        //    for (int i = 0; i < cart.Count; i++)
        //    {
        //        if (cart[i].Product.TenSp.Equals(id))
        //        {
        //            return i;
        //        }
        //    }

        //    return -1;
        //}
        //[HttpPost]
        public IActionResult Buy(int id)
        {
            /*var item = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = ser.FindProduct(id), Quantity = 1 });
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = ser.FindProduct(id), Quantity = 1 });
                }
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Home");*/
            return View(_databaseContext.Carts.Find(id));
        } 
        
        //public IActionResult Remove(string id)
        //{

        //    List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        //    int index = isExist(id);
        //    cart.RemoveAt(index);
        //    SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
        //    return RedirectToAction("Home");
        //}
    }
}

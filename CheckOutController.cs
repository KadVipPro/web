using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASG.Models;
using ASG.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ASG.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(c => c.Quantity * c.Product.GiaSp);
            return View();
        }
    }
}

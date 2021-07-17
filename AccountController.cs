using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASG.Models;
using ASG.Context;
using Microsoft.AspNetCore.Http;

namespace ASG.Controllers
{
   
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Customer a)
        {
            DatabaseContext db = new DatabaseContext();
            var findAcount = db.Customers.Where(x => x.TaiKhoan == a.TaiKhoan && x.MatKhau == a.MatKhau).FirstOrDefault();
            if (findAcount == null)
            {

                return View();

            }
            else if (findAcount.TaiKhoan == a.TaiKhoan || findAcount.MatKhau == a.MatKhau)
            {

                HttpContext.Session.SetString("TaiKhoan", a.TaiKhoan);
                return RedirectToAction("Home", "Product");
            }
            else
            {
                ViewBag.error = "Login failed";


                return View();

            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Customer customer)
        {
            DatabaseContext db = new DatabaseContext();
            var findAcount = db.Customers.Where(x => x.TaiKhoan == customer.TaiKhoan && x.MatKhau == customer.MatKhau).FirstOrDefault();
            if (findAcount == null)
            {
               
                return View();

            }
            else if (findAcount.TaiKhoan == customer.TaiKhoan || findAcount.MatKhau == customer.MatKhau)
            {
               
                HttpContext.Session.SetString("Email", customer.TaiKhoan);
                return RedirectToAction("Home", "Product");
            }
            else
            {
               // ViewBag.error = "Login failed";


                return View();
                
            }
        }
        [HttpGet]
        /*public IActionResult Logout()
        {
            HttpContext.Session.Remove("Email");
            return RedirectToAction("login", "Accounts");
        }*/

        [HttpGet]
        public IActionResult registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult registration(Customer customer)
        {
            DatabaseContext db = new DatabaseContext();
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

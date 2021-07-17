using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASG.Context;
using ASG.Models;

namespace ASG.Controllers
{
    public class CategoryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public IActionResult List()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();

        }


        [HttpGet]
        public IActionResult add()
        {
            return View("add");
        }
        [HttpPost]
        public IActionResult add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("List");

        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            return View("Edit", db.Categories.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(string id, Category category)
        {
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

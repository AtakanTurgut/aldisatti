using aldiSatti.Entity;
using aldiSatti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aldiSatti.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        public PartialViewResult _FeaturedProductList()
        {
            return PartialView(db.Products.Where(i => i.isApproved && i.isFeatured).Take(5).ToList());
        }

        public ActionResult Address()
        {
            return View();
        }

        public PartialViewResult Slider()
        {
            return PartialView(db.Products.Where(i => i.isApproved && i.slider).Take(5).ToList());
        }

        public ActionResult Search(string search)
        {
            var s = db.Products.Where(i => i.isApproved == true);

            if (!string.IsNullOrEmpty(search))
            {
                s = s.Where(n => n.name.Contains(search) || n.description.Contains(search));
            }

            return View(s.ToList());
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.Where(i => i.isHome && i.isApproved).ToList());
        }

        public ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i => i.id == id).FirstOrDefault());
        }

        public ActionResult Product()
        {
            return View(db.Products.ToList());
        }

        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(i => i.categoryId == id).ToList());
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}
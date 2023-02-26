using aldiSatti.Entity;
using aldiSatti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aldiSatti.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();

        // GET: Admin
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            StatsModel model = new StatsModel();
            model.numberOfProducts = db.Products.Count();
            model.numberOfOrders = db.Orders.Count();

            model.numberOfPendingOrders = db.Orders.Where(i => i.orderState == OrderState.Bekleniyor).ToList().Count;
            model.numberOfPackedOrders= db.Orders.Where(i => i.orderState == OrderState.Paketlendi).ToList().Count;
            model.numberOfShippingOrders = db.Orders.Where(i => i.orderState == OrderState.Kargolandi).ToList().Count;
            model.numberOfCompletedOrders = db.Orders.Where(i => i.orderState == OrderState.Tamamlandi).ToList().Count;

            return View(model);
        }

        public PartialViewResult NotificationMenu()
        {
            var notification = db.Orders.Where(i => i.orderState == OrderState.Bekleniyor).ToList();

            return PartialView(notification);
        }
    }
}
using aldiSatti.Entity;
using aldiSatti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aldiSatti.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();

        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrder
            {
                id = i.id,
                orderNumber = i.orderNumber,
                total = i.total,
                orderDate = i.orderDate,
                orderState = i.orderState,
                count = i.OrderLines.Count,
            }).OrderByDescending(i => i.orderDate).ToList();

            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i => i.id == id).Select(i => new OrderDetails()
            {
                orderId = i.id,
                orderNumber = i.orderNumber,
                total = i.total,
                userName = i.userName,
                orderDate = i.orderDate,
                orderState = i.orderState,
                address = i.address,
                city = i.city,
                district = i.district,
                quarter = i.quarter,
                postCode = i.postCode,

                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    productId = x.productId,
                    productName = x.Product.name,
                    quantity = x.quantity,
                    price = x.price,
                    image = x.Product.image,
                }).ToList()
            }).FirstOrDefault();

            return View(model); 
        }

        public ActionResult UpdateOrderState(int orderId, OrderState orderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.id == orderId);

            if (order != null)
            {
                order.orderState = orderState;
                db.SaveChanges();
                TempData["message"] = "Bilgiler Güncellendi!";

                return RedirectToAction("Details", new { id = orderId });
            }

            return RedirectToAction("Index"); 
        }

        public ActionResult PendingOrders()
        {
            var model = db.Orders.Where(i => i.orderState == OrderState.Bekleniyor).ToList();

            return View(model);
        }
        public ActionResult PackagedOrders()
        {
            var model = db.Orders.Where(i => i.orderState == OrderState.Paketlendi).ToList();

            return View(model);
        }

        public ActionResult ShippingOrders()
        {
            var model = db.Orders.Where(i => i.orderState == OrderState.Kargolandi).ToList();

            return View(model);
        }

        public ActionResult CompletedOrders()
        {
            var model = db.Orders.Where(i => i.orderState == OrderState.Tamamlandi).ToList();

            return View(model);
        }       
    }
}
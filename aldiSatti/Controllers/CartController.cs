using aldiSatti.Entity;
using aldiSatti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aldiSatti.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        private void SaveOrder(Cart cart, ShippingDetails model)
        {
            var order = new Order();
            order.orderNumber = "A" + (new Random().Next(1111, 9999).ToString());
            order.total = cart.Total();
            order.orderDate = DateTime.Now;
            order.orderState = OrderState.Bekleniyor;
            order.userName = User.Identity.Name;
            order.address = model.address;
            order.city = model.city;
            order.district = model.district;
            order.quarter = model.quarter;
            order.postCode = model.postCode;
            order.OrderLines = new List<OrderLine>();

            foreach (var item in cart.CartLines)
            {
                var orderLine = new OrderLine();

                orderLine.quantity = item.quantity;
                orderLine.price = item.quantity * item.product.price;
                orderLine.productId = item.product.id;
                order.OrderLines.Add(orderLine);
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("NoProduct", "Sepetinizde Ürün Bulunmamaktadır!");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, model);

                cart.ClearCart();
                return View("OrderComplete");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult AddToCart(int id)
        {
            var product = db.Products.FirstOrDefault(i => i.id == id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var product = db.Products.FirstOrDefault(i => i.id == id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public PartialViewResult Summary1()
        {
            return PartialView(GetCart());
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}
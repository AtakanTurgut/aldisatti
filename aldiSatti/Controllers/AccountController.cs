using aldiSatti.Entity;
using aldiSatti.Identity;
using aldiSatti.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Login = aldiSatti.Models.Login;

namespace aldiSatti.Controllers
{
    public class AccountController : Controller
    {
        DataContext db = new DataContext();

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        public PartialViewResult UserCount()
        {
            var users = UserManager.Users;

            return PartialView(users);
        }

        public ActionResult UserList()
        {
            var users = UserManager.Users;

            return View(users);
        }

        public ActionResult UserProfile()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);

            var data = new UserProfile()
            {
                id = user.Id,
                name = user.name,
                surname = user.surname,
                email = user.Email,
                userName = user.UserName,
            };

            return View(data);
        }

        [HttpPost]
        public ActionResult UserProfile(UserProfile model)
        {
            var user = UserManager.FindById(model.id);
            user.name = model.name;
            user.surname = model.surname;
            user.Email = model.email;
            user.UserName = model.userName;

            UserManager.Update(user);

            return View("Update");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.name = model.name;
                user.surname = model.surname;
                user.Email = model.email;
                user.UserName = model.userName;

                var result = UserManager.Create(user, model.password);

                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı Oluşturma Hatası!");
                }
            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.userName, model.password);

                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.rememberMe;
                    authManager.SignIn(authProperties, identityClaims);

                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle Bir Kullanıcı Bulunmuyor!");
                }
            }

            return View(model);
        }

        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = UserManager.ChangePassword(User.Identity.GetUserId(), model.oldPassword, model.newPassword);
                return View("Update");
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i => i.id == id).Select(i => new OrderDetails
            {
                orderId = i.id,
                orderNumber = i.orderNumber,
                total = i.total,
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

        // GET: Account
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            var orders = db.Orders.Where(i => i.userName == userName).Select(i => new UserOrder
            {
                id = i.id,
                orderNumber = i.orderNumber,
                orderState = i.orderState,
                orderDate = i.orderDate,
                total = i.total,
            }).OrderByDescending(i => i.orderDate).ToList();

            return View(orders);
        }
    }
}
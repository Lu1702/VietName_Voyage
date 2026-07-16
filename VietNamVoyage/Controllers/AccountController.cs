using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using VietNamVoyage.Models;

namespace VietNamVoyage.Controllers
{
    public class AccountController : Controller
    {
        TravelDBEntities db = new TravelDBEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            var admin = db.Admins.FirstOrDefault(a => a.Username == Username && a.Password == Password);
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.Username, false);
                Session["Role"] = "Admin";
                Session["Username"] = admin.Username;

                return RedirectToAction("Index", "Home");
            }

            var user = db.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["Role"] = "User";
                Session["Username"] = user.Username;

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không chính xác.";
            return View();
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Username, string Password, string ConfirmPassword)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["Role"] = "User";
                Session["Username"] = user.Username;
                var newUser = new User
                {
                    Username = Username,
                    Password = Password
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            if (ConfirmPassword != null && ConfirmPassword != Password)
            {
                ViewBag.ErrorMessage("Password phải giống với ConfirmPassword");
            }
                return RedirectToAction("Index", "Home");
        }
    }
}
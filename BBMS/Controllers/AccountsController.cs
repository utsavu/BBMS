using BBMS.Models;
using BBMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBMS.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel lg)
        {
            using (BBMSContext db = new BBMSContext())
            {
                var users = db.UserMasters.Where(x => x.UserId == lg.UserId && x.Password == lg.Password);
                if (users.Count() > 0)
                {
                    TempData["msg"] = "1";
                    var user = users.FirstOrDefault();

                    HttpContext.Session.SetInt32("Role", user.RoleId);
                    HttpContext.Session.SetString("Name", user.Name);
                    if (user.RoleId == 101)
                    {
                        return RedirectToAction("Index1", "Dashboard");
                    }
                    if (user.RoleId == 102)
                    {
                        return RedirectToAction("Index", "User");
                    }


                }
                else
                {
                    TempData["msg"] = "0";
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Accounts");
        }
        public IActionResult Signup()
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public IActionResult Signup(UserMaster um)
        {
            um.RoleId = 102;
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            using (BBMSContext db = new BBMSContext())
            {
                db.UserMasters.Add(um);
                if (db.SaveChanges() > 0)
                {
                    TempData["status"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["status"] = "0";
                }
            }

            return View();
        }
        public IActionResult Logoutt()
        {
            return View();
        }

    }
}

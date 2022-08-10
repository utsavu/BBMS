using BBMS.Models;
using BBMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBMS.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index1()
        {
            
            return View();
        }
        public IActionResult ViewReq()
        {
            using (BBMSContext db = new BBMSContext())
            {
                TempData["BloodReq"] = db.BloodReqs.ToList();

            }

            return View();
        }
        public IActionResult Index()
        {
            using (BBMSContext db = new BBMSContext())
            {
                TempData["Donor"] = db.Donors.ToList();

            }
            
            return View();
        }
        public IActionResult Add()
        {

            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Donor st)
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;

            using (BBMSContext db = new BBMSContext())
            {
                db.Donors.Add(st);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["AddMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["AddMsg"] = "0";
                }
            }

            return View();
        }
        public IActionResult Edit(string id)
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;

            Donor? ss = new Donor();
            using (BBMSContext db = new BBMSContext())
            {
                ss = db.Donors.Where(x => x.DonorId == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Edit(Donor s)
        {
            var list = new List<string>() { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            ViewBag.list = list;
            using (BBMSContext db = new BBMSContext())
            {
                var Result = db.Donors.Find(s.DonorId);
                Result.Name = s.Name;
                Result.BloodGroup = s.BloodGroup;
                Result.Age = s.Age;
                Result.PhoneNo = s.PhoneNo;
                Result.City = s.City;
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["EditMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["EditMsg"] = "0";
                }

            }
            return RedirectToAction("Index", "Dashboard");
        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            Donor ss = new Donor();
            using (BBMSContext db = new BBMSContext())
            {
                ss = db.Donors.Where(x => x.DonorId == id).FirstOrDefault();
                db.Donors.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Index", "Dashboard");
        }


    }
}

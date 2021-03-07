using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        Context c = new Context();
        public ActionResult Index(int id)
        {
            var bl = c.Admins.Find(id);
            return View("Index", bl);
        }
        public ActionResult updateUser(Admin u)
        {
            var usrs = c.Admins.Find(u.ID);
            usrs.Kullanici = u.Kullanici;
            usrs.Sifre = u.Sifre;
            usrs.Mail = u.Mail;
            c.SaveChanges();
            ViewBag.UpdateInfo = "Bilgileriniz Güncellendi...";
            return View("Index", usrs);
        }
        
    }
}
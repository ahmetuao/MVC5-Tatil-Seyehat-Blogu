using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Siniflar;


namespace TravelTripProje.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        Context c = new Context();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin ad)
        {
            var bilgiler = c.Admins.FirstOrDefault(x=>x.role == ad.role && x.Mail==ad.Mail);
            var bilgiler2 = c.Admins.FirstOrDefault(x=>x.role == ad.role && x.Kullanici==ad.Kullanici);
            if (bilgiler == null && bilgiler2 == null)
            {
                c.Admins.Add(ad);
                c.SaveChanges();
                return RedirectToAction("Login", "GirisYap");
            }
            else if (bilgiler2 != null && bilgiler != null)
            {
                ViewBag.RegisterError3 = "Zaten Kayıtlısınız, Lütfen Giriş Yapınız...";
                return View();
            }
            
            else if (bilgiler != null)
            {
                ViewBag.RegisterError2 = "Bu Mail Zaten Kayıtlı! Lütfen Giriş Yapınız...";
                return View();
            }
            else
            {
                ViewBag.RegisterError = "Bu Kullanıcı Adı Kullanılıyor! Lütfen Farklı Bir Kullanıcı Adı Belirleyiniz...";
                return View();
            }
            
        }
    }
}
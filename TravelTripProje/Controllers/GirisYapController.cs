using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        Context c = new Context();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre && x.role == ad.role);
            var bilgiler2 = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre && x.role != ad.role);

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else if (bilgiler2 != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler2.Kullanici, false);
                Session["Kullanici"] = bilgiler2.Kullanici.ToString();
                Session["ID"] = bilgiler2.ID.ToString();
                return RedirectToAction("Index2", "Default");
            }
            else
            {
                ViewBag.LoginError = "Hatalı kullanıcı adı veya şifre ";
                
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
      
        
    }
}
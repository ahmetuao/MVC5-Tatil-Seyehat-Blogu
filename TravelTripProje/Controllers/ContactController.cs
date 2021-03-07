using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context c = new Context();
        [HttpGet]
        [Authorize]

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(iletisim i)
        {
            c.iletisims.Add(i);
            c.SaveChanges();
            ViewBag.ContactInfo = "Mesajınız Başarıyla Gönderildi...";
            ModelState.Clear();
            return View("Index");
        }
    }
}
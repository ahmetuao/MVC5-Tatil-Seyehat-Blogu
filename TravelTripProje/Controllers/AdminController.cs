using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult IletisimListesi()
        {
            var iletisimler = c.iletisims.ToList();
            return View(iletisimler);
        }
        public ActionResult IletisimSil(int id)
        {
            var b = c.iletisims.Find(id);
            c.iletisims.Remove(b);
            c.SaveChanges();
            return RedirectToAction("IletisimListesi");
        }
        public ActionResult Hakkimizda(int id)
        {
            var yr = c.Hakkimizdas.Find(id);
            return View("Hakkimizda", yr);
        }
        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hd = c.Hakkimizdas.Find(h.ID);
            hd.FotoUrl = h.FotoUrl;
            hd.Aciklama = h.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Hakkimizda/1");
        }
        public ActionResult BlogDetayGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogDetayGetir", bl);
        }

        public ActionResult KullaniciListesi()
        {
            var kullanicilar = c.Admins.ToList();
            return View(kullanicilar);
        }
        public ActionResult KullaniciSil(int id)
        {
            var b = c.Admins.Find(id);
            c.Admins.Remove(b);
            c.SaveChanges();
            return RedirectToAction("KullaniciListesi");
        }
        public ActionResult KullaniciGetir(int id)
        {
            var usr = c.Admins.Find(id);
            return View("KullaniciGetir", usr);
        }
        public ActionResult KullaniciGuncelle(Admin u)
        {
            var usrs = c.Admins.Find(u.ID);
            usrs.Kullanici = u.Kullanici;
            usrs.Sifre = u.Sifre;
            usrs.Mail = u.Mail;
            c.SaveChanges();
            return RedirectToAction("KullaniciListesi");
        }
        
    }
}
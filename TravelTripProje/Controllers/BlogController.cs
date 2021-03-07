using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        [Authorize]
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList();
            by.Deger4 = c.Yorumlars.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
        [Authorize]
        public ActionResult BlogDetay(int id)
        {
            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            by.Deger4 = c.Yorumlars.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        [Authorize]

        public PartialViewResult YorumYap(Yorumlar y, int id)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            //var b = c.Blogs.Find(id);
            //Response.Redirect("/Blog/BlogDetay/b/");
            Response.Redirect("/Blog/Index/");
            return PartialView();
        }
    }
}
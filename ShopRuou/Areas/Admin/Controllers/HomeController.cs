using ShopRuou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopRuou.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ShopRuouEntities db = new ShopRuouEntities();
        public ActionResult Index()
        {
            List<SanPham> sanPham = db.SanPham.ToList();
            return View(sanPham);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
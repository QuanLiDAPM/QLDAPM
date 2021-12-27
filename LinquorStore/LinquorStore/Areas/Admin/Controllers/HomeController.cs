using LinquorStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using LinquorStore.Data;
using LinquorStore.Library;

namespace LinquorStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        const string SessionMand = "_Id";
        const string SessionHoten = "_Hoten";
        const string SessionTenDN = "_TenDN";
        const string SessionChucVu = "_Chucvu";
        const string SessionHinhAnh = "_HinhAnh";
        private readonly ILogger<HomeController> _logger;
        private LiquorStoresContext db = new LiquorStoresContext();
        private readonly LiquorStoresContext _context;
        public HomeController(ILogger<HomeController> logger, LiquorStoresContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult Logout()
        {
            // Xóa SESSION
            HttpContext.Session.Remove("_Id");
            HttpContext.Session.Remove("_Hoten");
            HttpContext.Session.Remove("_TenDN");
            HttpContext.Session.Remove("_Chucvu");
            HttpContext.Session.Remove("_HinhAnh");
            // Quy về trang chủ
            return RedirectToAction("Index", "Home");
        }



        // GET: Home/Login
        public ActionResult Login()
        {
            ModelState.AddModelError("LoginError", "");
            return View();
        }
        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TaiKhoanLogin taiKhoan)
        {
            if (ModelState.IsValid)
            {
                string mahoamatkhau = SHA1.ComputeHash(taiKhoan.MatKhau);
                var account = db.TaiKhoans.Where(r => r.TenDangNhap == taiKhoan.TenDangNhap && r.MatKhau == mahoamatkhau).SingleOrDefault();

                if (account == null)
                {
                    ModelState.AddModelError("LoginError", "Tên đăng nhập hoặc mật khẩu không chính xác!");
                    return View(taiKhoan);
                }
                else
                {
                    // Đăng ký SESSION

                    HttpContext.Session.SetInt32(SessionMand, account.Id);
                    HttpContext.Session.SetString(SessionHoten, account.HoTen);
                    HttpContext.Session.SetString(SessionTenDN, account.TenDangNhap);
                    HttpContext.Session.SetInt32(SessionChucVu, account.ChucVu);
                    HttpContext.Session.SetString(SessionHinhAnh, account.HinhAnhBia);

                    // Quay về trang chủ
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(taiKhoan);
        }



    }
}

using ShopRuou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopRuou.Library;

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
        public ActionResult Logout()
        {
            // Xóa SESSION
            Session.RemoveAll();

            // Quay về trang chủ
            return RedirectToAction("Index", "Home");
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
        public ActionResult Login()
        {
            ModelState.AddModelError("LoginError", "");
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(NhanVienLogin nhanVien)
        {
            if (ModelState.IsValid)
            {
                string matKhauMaHoa = SHA1.ComputeHash(nhanVien.MatKhau);
                var nhanvien = db.TaiKhoan.Where(r => r.TenDangNhap == nhanVien.TenDangNhap && r.MatKhau == matKhauMaHoa).SingleOrDefault();

                if (nhanvien == null)
                {
                    ModelState.AddModelError("LoginError", "Tên đăng nhập hoặc mật khẩu không chính xác!");
                    return View(nhanVien);
                }
                else
                {
                    // Đăng ký SESSION
                    Session["ID"] = nhanvien.ID;
                    Session["HoTen"] = nhanvien.HoTen;
                    Session["ChucVu"] = nhanvien.ChucVu;
                    Session["TenDangNhap"] = nhanvien.TenDangNhap;


                    // Quay về trang chủ
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(nhanVien);
        }
       


    }
}
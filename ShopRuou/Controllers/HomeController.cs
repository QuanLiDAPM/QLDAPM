using ShopRuou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopRuou.Library;
using System.Data.Entity;

namespace ShopRuou.Controllers
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
            Session.Remove("MaKhachHang");
            Session.Remove("HoTenKhachHang");
            Session.Remove("TenDangNhap");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Login()
        {
            ModelState.AddModelError("LoginError", "");
            return View();
        }
		// POST: Home/Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(KhachHangLogin khachHang)
		{
			if (ModelState.IsValid)
			{
				string matKhauMaHoa = SHA1.ComputeHash(khachHang.MatKhau);
				var taiKhoan = db.KhachHang.Where(r => r.TenDangNhap == khachHang.TenDangNhap && r.MatKhau == matKhauMaHoa).SingleOrDefault();

				if (taiKhoan == null)
				{
					ModelState.AddModelError("LoginError", "Tên đăng nhập hoặc mật khẩu không chính xác!");
					return View(khachHang);
				}
				else
				{
					// Đăng ký SESSION
					Session["MaKhachHang"] = taiKhoan.ID;
					Session["HoTenKhachHang"] = taiKhoan.HoTen;
					Session["TenDangNhap"] = taiKhoan.TenDangNhap;
					// Quay về trang chủ
					return RedirectToAction("Index", "Home");
				}
			}

			return View(khachHang);
		}
		
			public ActionResult ChangePassword()
		{
			ModelState.AddModelError("ChangePassword", "");
			return View();
		}
		// POST: Home/ChangePassword
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ChangePassword(ChangePassword khachHang)
		{

			if (ModelState.IsValid)
			{

				string matKhauCu = SHA1.ComputeHash(khachHang.MatKhauCu);
				string matKhauMoi = SHA1.ComputeHash(khachHang.MatKhauMoi);
				string xacnhanmatkhau = SHA1.ComputeHash(khachHang.XacNhanMatKhau);
				string tendangnhap = Session["TenDangNhap"].ToString();
				var taiKhoan = db.KhachHang.Where(r => r.TenDangNhap == tendangnhap && r.MatKhau == matKhauCu).SingleOrDefault();

				if (taiKhoan == null)
				{
					ModelState.AddModelError("ChangePassword", "Tên đăng nhập hoặc mật khẩu không chính xác!");
					return View(khachHang);
				}
				else
				{
					if (matKhauMoi == xacnhanmatkhau)
					{
						taiKhoan.MatKhau = matKhauMoi;
						taiKhoan.XacNhanMatKhau = matKhauMoi;
						db.Entry(taiKhoan).State = EntityState.Modified;
						db.SaveChanges();
						ModelState.AddModelError("ChangePasswordSucess", "Đổi mật khẩu thành công");
						return View(khachHang);
					}
				}
			}
			return View(khachHang);
		}
		public ActionResult DonHangCuaToi()
		{
			int makh = Convert.ToInt32(Session["MaKhachHang"]);
			var DonHangCuaToi = (from sp in db.SanPham
								 join chitiet in db.DatHang_ChiTiet on sp.ID equals chitiet.SanPham_ID
								 join dhang in db.DatHang on chitiet.DatHang_ID equals dhang.ID
								 join kh in db.KhachHang on dhang.KhachHang_ID equals kh.ID
								 where (kh.ID == makh)

								 select new DonHangCuaToi()
								 {
									 TenSanPham = sp.TenSanPham,
									 HinhAnhBia = sp.HinhAnhBia,
									 DonGia = chitiet.DonGia,
									 ID = kh.ID,
									 SoLuong = chitiet.SoLuong,
									 NgayDatHang = dhang.NgayDatHang

								 }).OrderByDescending(dhang => dhang.NgayDatHang).ToList();

			return View(DonHangCuaToi);
		}
		public ActionResult KhachHangSignUp()
		{
			ModelState.AddModelError("SignUpError", "");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult KhachHangSignUp([Bind(Include = "ID,HoTen,SoDienThoai,DiaChi,TenDangNhap,MatKhau,XacNhanMatKhau")] KhachHang khachHang)
		{
			if (ModelState.IsValid)
			{
				khachHang.MatKhau = SHA1.ComputeHash(khachHang.MatKhau);
				khachHang.XacNhanMatKhau = SHA1.ComputeHash(khachHang.XacNhanMatKhau);
				db.KhachHang.Add(khachHang);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(khachHang);
		}



	}
}
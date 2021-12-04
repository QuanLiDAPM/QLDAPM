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


namespace LinquorStore.Controllers
{
    public class HomeController : Controller
    {
        const string SessionMand = "_Id";
        const string SessionHoten = "_Hoten";
        const string SessionTenDN = "_TenDN";
        private readonly ILogger<HomeController> _logger;
        private LiquorStoresContext db = new LiquorStoresContext();
        private readonly LiquorStoresContext _context;
        public HomeController(ILogger<HomeController> logger, LiquorStoresContext context)
        {
            _logger = logger;
            _context = context;
        }

        //public IActionResult BaBy()
        //{
        //    List<SanPham> sanPham = db.SanPhams.ToList();
        //    return View();
        //}


        public IActionResult Index()
        {
            List<SanPham> sanPham = db.SanPhams.ToList();
            return View(sanPham);
        }

        public IActionResult Privacy()
        {
            return View();
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
        public ActionResult Login(KhachHangLogin khachHang)
        {
            if (ModelState.IsValid)
            {
                string mahoamatkhau = SHA1.ComputeHash(khachHang.MatKhau);
                var taiKhoan = db.KhachHangs.Where(r => r.TenDangNhap == khachHang.TenDangNhap && r.MatKhau == mahoamatkhau).SingleOrDefault();

                if (taiKhoan == null)
                {
                    ModelState.AddModelError("LoginError", "Tên đăng nhập hoặc mật khẩu không chính xác!");
                    return View(khachHang);
                }
                else
                {
                    // Đăng ký SESSION

                    HttpContext.Session.SetInt32(SessionMand, taiKhoan.Id);
                    HttpContext.Session.SetString(SessionHoten, taiKhoan.HoTen);
                    HttpContext.Session.SetString(SessionTenDN, taiKhoan.TenDangNhap);


                    // Quay về trang chủ
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(khachHang);
        }

        public ActionResult Logout()
        {
            // Xóa SESSION
            HttpContext.Session.Remove("_Id");
            HttpContext.Session.Remove("_Hoten");
            HttpContext.Session.Remove("_TenDN");

            // Quy về trang chủ
            return RedirectToAction("Index", "Home");
        }

        // đọc danh sách mat hang trong giỏ từ session
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        //Lưu danh sach CartItem trong gio hang vao session
        void SaveCartSession(List<CartItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString("shopcart", jsoncart);
        }
        //Đọc danh sách CartItem từ session
        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString("shopcart");
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        //Ch hang vao gio
        public async Task<IActionResult> AddToCart(int id)
        {


            var product = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound("Sản phẩm không tồn tại");
            }
            var cart = GetCartItems();
            var item = cart.Find(p => p.Product.Id == id);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem() { Product = product, Quantity = 1 });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }

        //Chuyển đến xem giỏ hàng
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

        //Xóa một mặt hàng khỏi giỏ
        public IActionResult RemoveItem(int id)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.Product.Id == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
        //Cập nhật số lượng một mặt hàng khỏi giỏ
        public IActionResult UpdateItem(int id, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.Product.Id == id);
            if (item != null)
            {
                item.Quantity = quantity;
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }





        public ActionResult DangKy()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var check = db.KhachHangs.FirstOrDefault(r => r.TenDangNhap == kh.TenDangNhap);
                if (check == null)
                {
                    kh.MatKhau = SHA1.ComputeHash(kh.MatKhau);
                    //kh.XacNhanMatKhau = SHA1.ComputeHash(kh.XacNhanMatKhau);
                    //db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Tên đăng nhập đã tồn tại !!!";
                    return View();
                }
            }
            return View();
        }

        public ActionResult ChangePass()
        {
            ModelState.AddModelError("LoginError", "");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePass(ChangePassword model)
        {
            //if (ModelState.IsValid)
            {
                int id = (int)HttpContext.Session.GetInt32("_Id");

                string matKhauMaHoa = SHA1.ComputeHash(model.MatKhauCu);
                string matkhaumoi;
                var taiKhoan = _context.KhachHangs.Where(r => r.Id == id && r.MatKhau == matKhauMaHoa).SingleOrDefault();
                if (taiKhoan == null)
                {
                    ModelState.AddModelError("LoginError", "Mật khẩu cũ không chính xác!");
                    return View(model);
                }
                else
                {
                    matkhaumoi = SHA1.ComputeHash(model.MatKhauMoi);
                    KhachHang n = _context.KhachHangs.Find(id);
                    n.MatKhau = matkhaumoi;

                    _context.Entry(n).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Login");

                    // return RedirectToAction("Index","Home");
                }
            }

        }

        public IActionResult CheckOut()
        {
            return View(GetCartItems());
        }
        public IActionResult CheckOut_Details()
        {
            return View(GetCartItems());
        }
        //public string ThankYou(string t)
        //{
        //    return t = "Cảm ơn bạn đã mua hàng";
        //}
    }
}

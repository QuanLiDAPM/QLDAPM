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
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using LinquorStore.Services;

namespace LinquorStore.Controllers
{
    public class HomeController : Controller
    {
        public INotyfService _notifyService { get; }
        public const string CARTKEY = "shopcart";
        const string SessionMand = "_IdKhachHang";
        const string SessionHoten = "_HotenKhachHang";
        const string SessionTenDN = "_TenDN";
        const string SessionDiaChi = "_DiaChi";
        const string SessionSoDT = "_SoDT";
        private readonly ILogger<HomeController> _logger;
        private LiquorStoresContext db = new LiquorStoresContext();
        private readonly LiquorStoresContext _context;
        private readonly IProduct _product;
        public HomeController(ILogger<HomeController> logger, LiquorStoresContext context, INotyfService notifyService, IProduct product)
        {
            _logger = logger;
            _context = context;
            _notifyService = notifyService;
            _product = product;
        }

        //public IActionResult BaBy()
        //{
        //    List<SanPham> sanPham = db.SanPhams.ToList();
        //    return View();
        //}


        public IActionResult Index(string currentFilter, string searchString, string movieGenre, string sortOrder, int? page = 0)
        {
            //ViewData["CurrentSort"] = sortOrder;

            //ViewData["PriceGiam"] = String.IsNullOrEmpty(sortOrder) ? "giam_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            //ViewData["PriceTang"] = String.IsNullOrEmpty(sortOrder) ? "tang_desc" : "";

            var GenreLst = new List<string>();

            var GenreQry = from d in db.Loais

                           select d.TenLoai;
            ViewBag.thao = GenreQry;
            ViewBag.loai = movieGenre;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);

            int limit = 8;
            int start;
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            start = (int)(page - 1) * limit;

            ViewBag.pageCurrent = page;
            ViewBag.sp = searchString;
            int totalProduct = _product.totalProduct();

            ViewBag.totalProduct = totalProduct;

            ViewBag.numberPage = _product.numberPage(totalProduct, limit);
            var sanpham = _context.SanPhams.Skip((int)((page - 1) * limit)).Take(limit);
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                sanpham = sanpham.Where(s => s.TenSanPham.Contains(searchString)
                                       || s.Loai.TenLoai.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre) && movieGenre != "All")
            {
                sanpham = sanpham.Where(x => x.Loai.TenLoai == movieGenre);

            }

            //switch (sortOrder)
            //{
            //    case "giam_desc":
            //        sanpham = sanpham.OrderByDescending(s => s.DonGia);
            //        break;
            //    default:
            //        break;

            //    case "Date":
            //        sanpham = sanpham.OrderBy(s => s.NgayNhap);
            //        break;
            //    //  Mặc định thì sẽ sắp xếp giảm
            //    case "date_desc":
            //        sanpham = sanpham.OrderByDescending(s => s.NgayNhap);
            //        break;
            //    //  Mặc định thì sẽ sắp xếp tăng
            //    case "tang_desc":
            //        sanpham = sanpham.OrderBy(s => s.DonGia);
            //        break;
            //}



            return View(sanpham);

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
                    _notifyService.Error("Tên đăng nhập hoặc mật khẩu không chính xác!");
                    return View(khachHang);
                }
                else
                {
                    // Đăng ký SESSION

                    HttpContext.Session.SetInt32(SessionMand, taiKhoan.Id);
                    HttpContext.Session.SetString(SessionHoten, taiKhoan.HoTen);
                    HttpContext.Session.SetString(SessionTenDN, taiKhoan.TenDangNhap);
                    HttpContext.Session.SetString(SessionDiaChi, taiKhoan.DiaChi);
                    HttpContext.Session.SetString(SessionSoDT, taiKhoan.SoDienThoai);

                    _notifyService.Success("Đăng nhập thành công");
                    // Quay về trang chủ
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(khachHang);
        }

        public ActionResult Logout()
        {
            // Xóa SESSION
            HttpContext.Session.Remove("_IdKhachHang");
            HttpContext.Session.Remove("_HotenKhachHang");
            HttpContext.Session.Remove("_TenDN");
            HttpContext.Session.Remove("_DiaChi");
            HttpContext.Session.Remove("_SoDT");

            HttpContext.Session.Remove(CARTKEY);

            _notifyService.Warning("Đăng xuất thành công");
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


        //Đọc danh sách CartItem từ session
        public List<CartItem> GetCartItems()
        {
            //var session = HttpContext.Session;
            //string jsoncart = session.GetString("shopcart");
            var jsoncart = HttpContext.Request.Cookies[HttpContext.Session.GetInt32("_IdKhachHang").ToString()];
            if (!string.IsNullOrEmpty(jsoncart))
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
                
            }
            return new List<CartItem>();
        }
        // lưu danh sách mặt hàng trong giỏ vào session 
        void SaveCartSession(List<CartItem> lst)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(lst);
            //session.SetString("shopcart", jsoncart);
            HttpContext.Response.Cookies.Append(HttpContext.Session.GetInt32(SessionMand).ToString(), jsoncart);
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
            _notifyService.Success("Xoá thành công");
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
            _notifyService.Success("Cập nhật thành công");
            return RedirectToAction(nameof(Cart));
        }


        public ActionResult MyCheckOut()
        {
            int makh = (int)HttpContext.Session.GetInt32("_IdKhachHang");
            var MyCheckOut = (from sp in db.SanPhams
                                 join chitiet in db.DatHangChiTiets on sp.Id equals chitiet.SanPhamId
                                 join dhang in db.DatHangs on chitiet.DatHangId equals dhang.Id
                                 join kh in db.KhachHangs on dhang.KhachHangId equals kh.Id
                                 where (kh.Id == makh)

                                 select new MyCheckOut()
                                 {
                                     TenSanPham = sp.TenSanPham,
                                     HinhAnhBia = sp.HinhAnhBia,
                                     DonGia = chitiet.DonGia,
                                     ID = kh.Id,
                                     SoLuong = chitiet.SoLuong,
                                     NgayDatHang = dhang.NgayDatHang,
                                     TinhTrang = dhang.TinhTrang,
                                     DuKienNgayNhan = dhang.DuKienNgayNhan

                                 }).OrderByDescending(dhang => dhang.NgayDatHang).ToList();

            return View(MyCheckOut);
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
                    _notifyService.Success("Đăng ký thành công");
                    return RedirectToAction("Login");
                }
                else
                {
                    _notifyService.Error("Tài khoản đã tồn tại!");
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
                int id = (int)HttpContext.Session.GetInt32("_IdKhachHang");

                string matKhauMaHoa = SHA1.ComputeHash(model.MatKhauCu);
                string matkhaumoi;
                var taiKhoan = _context.KhachHangs.Where(r => r.Id == id && r.MatKhau == matKhauMaHoa).SingleOrDefault();
                if (taiKhoan == null)
                {
                    _notifyService.Error("Mật khẩu cũ không chính xác!");
                    return View(model);
                }
                else
                {
                    matkhaumoi = SHA1.ComputeHash(model.MatKhauMoi);
                    KhachHang n = _context.KhachHangs.Find(id);
                    n.MatKhau = matkhaumoi;

                    _context.Entry(n).State = EntityState.Modified;
                    _context.SaveChanges();
                    _notifyService.Success("Đổi mật khẩu thành công");
                    return RedirectToAction("Login");

                    //return RedirectToAction("Index", "Home");
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateBill(int cusname, string cusphone, string cusadd)
        {

            var session = HttpContext.Session;
            var b = new DatHang();
            b.NgayDatHang = DateTime.Now;
            b.KhachHangId = HttpContext.Session.GetInt32(SessionMand);
            if (b.KhachHangId == null)
            {
                return Redirect("/Home/Login");
            }
            b.DienThoaiGiaoHang = cusphone;
            b.DiaChiGiaoHang = cusadd;

            _context.Add(b);
            await _context.SaveChangesAsync();
            //them billdetails
            var cart = GetCartItems();
            int amount = 0;
            int total = 0;

            foreach (var i in cart)
            {
                var d = new DatHangChiTiet();
                d.DatHangId = b.Id;
                d.SanPhamId = i.Product.Id;
                var sanpham = _context.SanPhams.FirstOrDefault(t => t.Id == d.SanPhamId);
                sanpham.SoLuong -= i.Quantity;
                await _context.SaveChangesAsync();
                d.DonGia = i.Product.DonGia;
                d.SoLuong = Convert.ToInt16(i.Quantity);

                amount = i.Product.DonGia * i.Quantity;
                total += amount;
                _context.Add(d);
            }
            await _context.SaveChangesAsync();

            HttpContext.Response.Cookies.Append(HttpContext.Session.GetInt32(SessionMand).ToString(), "");

            _notifyService.Custom("Cám ơn bạn đã mua hàng, quý khách vui lòng chờ xác nhận và theo dõi đơn hàng!", 5, "#ffa600", "fa fa-heart");
            //chuyển hướng 
            return RedirectToAction("Index", "Home");

        }
        public IActionResult CheckOut_Details()
        {
            return View(GetCartItems());
        }

        
        public IActionResult ErrorLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseConfirmation(DatHang DatHang)
        {
            if (ModelState.IsValid)
            {
                var session = HttpContext.Session;
                // Lưu vào bảng dathang
                DatHang dh = new DatHang();
                dh.TinhTrang = 0;
                dh.DiaChiGiaoHang = DatHang.DiaChiGiaoHang;
                dh.DienThoaiGiaoHang = DatHang.DienThoaiGiaoHang;
                dh.NgayDatHang = DateTime.Now;

                dh.KhachHangId = Convert.ToInt32(session.GetInt32("_IdKhachHang"));
                
                db.DatHangs.Add(dh);
                db.SaveChanges();

                ///* Lưu vào bảng */DatHang_ChiTiet
                var cart = GetCartItems();
                foreach (var item in cart)
                {
                    DatHangChiTiet chitiet = new DatHangChiTiet();
                    chitiet.DatHangId = dh.Id;
                    chitiet.SanPhamId = item.Product.Id;
                    chitiet.SoLuong = Convert.ToInt16(item.Quantity);
                    chitiet.DonGia = item.Product.DonGia;
                    db.DatHangChiTiets.Add(chitiet);
                    db.SaveChanges();
                }

                // Xóa giỏ hàng
                cart.Clear();

                // Quay về trang chủ
                return RedirectToAction("Index", "Home");
            }

            return View(DatHang);
        }
        public ActionResult Abouts()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LinquorStore.Data;
using LinquorStore.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LinquorStore.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        public INotyfService _notifyService { get; }
        private LiquorStoresContext db = new LiquorStoresContext();
        private readonly LiquorStoresContext _context;

        public SanPhamController(LiquorStoresContext context)
        {
            _context = context;
        }

        // GET: SanPham
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["Loai_ID"] = new SelectList(_context.Loais, "Id", "TenLoai");
            ViewData["CurrentFilter"] = searchString;

            var LiquorStoresContext = _context.SanPhams.Include(s => s.Hang).Include(s => s.Loai).Include(s => s.NoiSanXuat);
            List<SanPham> sanPham = db.SanPhams.ToList();
            var models = from s in _context.SanPhams
                          .Include(s => s.Hang)
                           .Include(s => s.NoiSanXuat)
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                models = models.Where(s => s.TenSanPham.Contains(searchString)
                                       || s.Loai.TenLoai.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    models = models.OrderByDescending(s => s.TenSanPham);
                    break;
                case "Date":
                    models = models.OrderBy(s => s.NgayNhap);
                    break;
                case "date_desc":
                    models = models.OrderByDescending(s => s.NgayNhap);
                    break;
                default:
                    models = models.OrderBy(s => s.TenSanPham);
                    break;

            }
            return View(await models.ToListAsync());
        }
        public IActionResult Filtter(int ID = 0)
        {
            var url = $"/Admin/SanPham?ID={ID}";
            if (ID == 0)
            {
                url = $"/Admin/SanPham";
            }
            return Json(new { status = "success", redirectUrl = url });
        }

        // GET: SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.Hang)
                .Include(s => s.Loai)
                .Include(s => s.NoiSanXuat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPham/Create
        public IActionResult Create()
        {
            ViewData["HangId"] = new SelectList(_context.Hangs, "Id", "TenHang");
            ViewData["LoaiId"] = new SelectList(_context.Loais, "Id", "TenLoai");
            ViewData["NoiSanXuatId"] = new SelectList(_context.NoiSanXuats, "Id", "XuatXu");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("Id,LoaiId,HangId,NoiSanXuatId,TenSanPham,NongDoCon,TheTich,NgayNhap,DonGia,SoLuong,MoTa")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.HinhAnhBia = Upload(file);
                _context.SanPhams.Add(sanPham);
                await _context.SaveChangesAsync();
                //_notifyService.Success("Thêm sản phẩm thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["HangId"] = new SelectList(_context.Hangs, "Id", "TenHang", sanPham.HangId);
            ViewData["LoaiId"] = new SelectList(_context.Loais, "Id", "TenLoai", sanPham.LoaiId);
            ViewData["NoiSanXuatId"] = new SelectList(_context.NoiSanXuats, "Id", "XuatXu", sanPham.NoiSanXuatId);
            return View(sanPham);
        }

        // GET: SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["HangId"] = new SelectList(_context.Hangs, "Id", "TenHang", sanPham.HangId);
            ViewData["LoaiId"] = new SelectList(_context.Loais, "Id", "TenLoai", sanPham.LoaiId);
            ViewData["NoiSanXuatId"] = new SelectList(_context.NoiSanXuats, "Id", "XuatXu", sanPham.NoiSanXuatId);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file,int id, [Bind("Id,LoaiId,HangId,NoiSanXuatId,TenSanPham,NongDoCon,TheTich,NgayNhap,DonGia,SoLuong,MoTa,HinhAnhBia")] SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sanPham.HinhAnhBia = Upload(file);
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
                    {
                        _notifyService.Success("Có lỗi xảy ra");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HangId"] = new SelectList(_context.Hangs, "Id", "TenHang", sanPham.HangId);
            ViewData["LoaiId"] = new SelectList(_context.Loais, "Id", "TenLoai", sanPham.LoaiId);
            ViewData["NoiSanXuatId"] = new SelectList(_context.NoiSanXuats, "Id", "XuatXu", sanPham.NoiSanXuatId);
            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.Hang)
                .Include(s => s.Loai)
                .Include(s => s.NoiSanXuat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
        public string Upload(IFormFile file)
        {
            var path = "";
            string UploadFileName = null;
            if (file != null)
            {
                UploadFileName = $"Images\\{Guid.NewGuid()}_{file.FileName}";
                path = $"wwwroot\\{UploadFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return UploadFileName;
        }
    }
}

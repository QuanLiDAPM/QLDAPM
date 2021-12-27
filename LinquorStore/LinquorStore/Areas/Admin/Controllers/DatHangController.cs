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

namespace LinquorStore.Controllers
{
    [Area("Admin")]
    public class DatHangController : Controller
    {
        private readonly LiquorStoresContext _context;
        public INotyfService _notifyService { get; }
        public DatHangController(LiquorStoresContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: DatHang
        public async Task<IActionResult> Index()
        {
            var liquorStoresContext = _context.DatHangs.Include(d => d.KhachHang).Include(d => d.TaiKhoan);
            return View(await liquorStoresContext.ToListAsync());
        }

        // GET: DatHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datHang = await _context.DatHangs
                .Include(d => d.KhachHang)
                .Include(d => d.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datHang == null)
            {
                return NotFound();
            }

            return View(datHang);
        }

        // GET: DatHang/Create
        public IActionResult Create()
        {
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "Id", "DiaChi");
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "HoTen");
            return View();
        }

        // POST: DatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaiKhoanId,KhachHangId,DienThoaiGiaoHang,DiaChiGiaoHang,NgayDatHang,TinhTrang")] DatHang datHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datHang);
                await _context.SaveChangesAsync();
                _notifyService.Success("Thêm đơn hàng thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "Id", "DiaChi", datHang.KhachHangId);
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "HoTen", datHang.TaiKhoanId);
            return View(datHang);
        }

        // GET: DatHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datHang = await _context.DatHangs.FindAsync(id);
            if (datHang == null)
            {
                return NotFound();
            }
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "Id", "DiaChi", datHang.KhachHangId);
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "HoTen", datHang.TaiKhoanId);
            return View(datHang);
        }

        // POST: DatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaiKhoanId,KhachHangId,DienThoaiGiaoHang,DiaChiGiaoHang,NgayDatHang,TinhTrang")] DatHang datHang)
        {
            if (id != datHang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datHang);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Cập nhật thông tin thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatHangExists(datHang.Id))
                    {
                        _notifyService.Error("Có lỗi xảy ra");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachHangId"] = new SelectList(_context.KhachHangs, "Id", "DiaChi", datHang.KhachHangId);
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "HoTen", datHang.TaiKhoanId);
            return View(datHang);
        }

        // GET: DatHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datHang = await _context.DatHangs
                .Include(d => d.KhachHang)
                .Include(d => d.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datHang == null)
            {
                return NotFound();
            }

            return View(datHang);
        }

        // POST: DatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datHang = await _context.DatHangs.FindAsync(id);
            _context.DatHangs.Remove(datHang);
            await _context.SaveChangesAsync();
            _notifyService.Success("Xoá đơn hàng thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool DatHangExists(int id)
        {
            return _context.DatHangs.Any(e => e.Id == id);
        }
    }
}

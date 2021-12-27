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
    public class HangController : Controller
    {
        private readonly LiquorStoresContext _context;
        public INotyfService _notifyService { get; }
        public HangController(LiquorStoresContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: Hang
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hangs.ToListAsync());
        }

        // GET: Hang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hang = await _context.Hangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hang == null)
            {
                return NotFound();
            }

            return View(hang);
        }

        // GET: Hang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenHang")] Hang hang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hang);
                await _context.SaveChangesAsync();
                _notifyService.Success("Thêm hãng thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(hang);
        }

        // GET: Hang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hang = await _context.Hangs.FindAsync(id);
            if (hang == null)
            {
                return NotFound();
            }
            return View(hang);
        }

        // POST: Hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenHang")] Hang hang)
        {
            if (id != hang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hang);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Cập nhật thông tin thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangExists(hang.Id))
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
            return View(hang);
        }

        // GET: Hang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hang = await _context.Hangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hang == null)
            {
                return NotFound();
            }

            return View(hang);
        }

        // POST: Hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hang = await _context.Hangs.FindAsync(id);
            _context.Hangs.Remove(hang);
            await _context.SaveChangesAsync();
            _notifyService.Success("Xoá hãng thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool HangExists(int id)
        {
            return _context.Hangs.Any(e => e.Id == id);
        }
    }
}

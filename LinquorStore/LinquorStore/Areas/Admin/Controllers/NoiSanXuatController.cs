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
    public class NoiSanXuatController : Controller
    {
        private readonly LiquorStoresContext _context;
        public INotyfService _notifyService { get; }
        public NoiSanXuatController(LiquorStoresContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: NoiSanXuat
        public async Task<IActionResult> Index()
        {
            return View(await _context.NoiSanXuats.ToListAsync());
        }

        // GET: NoiSanXuat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noiSanXuat = await _context.NoiSanXuats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noiSanXuat == null)
            {
                return NotFound();
            }

            return View(noiSanXuat);
        }

        // GET: NoiSanXuat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NoiSanXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,XuatXu")] NoiSanXuat noiSanXuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noiSanXuat);
                await _context.SaveChangesAsync();
                _notifyService.Success("Thêm nơi sản xuất thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(noiSanXuat);
        }

        // GET: NoiSanXuat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noiSanXuat = await _context.NoiSanXuats.FindAsync(id);
            if (noiSanXuat == null)
            {
                return NotFound();
            }
            return View(noiSanXuat);
        }

        // POST: NoiSanXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,XuatXu")] NoiSanXuat noiSanXuat)
        {
            if (id != noiSanXuat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noiSanXuat);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Cập nhật thông tin thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoiSanXuatExists(noiSanXuat.Id))
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
            return View(noiSanXuat);
        }

        // GET: NoiSanXuat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noiSanXuat = await _context.NoiSanXuats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noiSanXuat == null)
            {
                return NotFound();
            }

            return View(noiSanXuat);
        }

        // POST: NoiSanXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noiSanXuat = await _context.NoiSanXuats.FindAsync(id);
            _context.NoiSanXuats.Remove(noiSanXuat);
            await _context.SaveChangesAsync();
            _notifyService.Success("Xoá nơi sản xuất thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool NoiSanXuatExists(int id)
        {
            return _context.NoiSanXuats.Any(e => e.Id == id);
        }
    }
}

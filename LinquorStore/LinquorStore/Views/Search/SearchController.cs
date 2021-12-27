using LinquorStore.Models;
using LinquorStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinquorStore.Views.Search
{
    public class SearchController : Controller
    {
       
        private readonly LiquorStoresContext _context;

        public SearchController(LiquorStoresContext context)
        {
            
            _context = context;
         
        }
        public async Task<ActionResult> Search (string currentFilter, string searchString, int? pageNumber)

        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var sanpham = from s in _context.SanPhams
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sanpham = sanpham.Where(s => s.TenSanPham.Contains(searchString)
                                       || s.Loai.TenLoai.Contains(searchString));
            }
            ViewBag.thongbao = sanpham.Count();
            int pageSize = 8;
            return View(await PaginatedList<SanPham>.CreateAsync(sanpham.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}

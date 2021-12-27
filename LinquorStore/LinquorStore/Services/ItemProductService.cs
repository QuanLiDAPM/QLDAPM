using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinquorStore.Data;
using LinquorStore.Models;
namespace LinquorStore.Services
{
    public class ItemProductService : IProduct
    {
        private readonly LiquorStoresContext _db;
        private List<SanPham> products = new List<SanPham>();
        public ItemProductService(LiquorStoresContext db)
        {
            _db = db;
            this.products = _db.SanPhams.ToList();
        }
        public IEnumerable<SanPham> getProductAll()
        {
            return products;
        }
        public int totalProduct()
        {
            return products.Count + 1;
        }
        public int numberPage(int totalProduct, int limit)
        {
            float numberpage = ((float)totalProduct) / ((float)limit);
            return (int)Math.Ceiling(numberpage);
        }
        public IEnumerable<SanPham> paginationProduct(int start, int limit)
        {
            var sanpham = (from s in _db.SanPhams select s);
            var dataProduct = sanpham.OrderByDescending(x => x.Id).Skip(start).Take(limit);
            return dataProduct.ToList();
        }
    }
}

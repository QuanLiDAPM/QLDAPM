using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinquorStore.Models;

namespace LinquorStore.Services
{
    public interface IProduct
    {
        IEnumerable<SanPham> getProductAll();
        int totalProduct();
        int numberPage(int totalProduct, int limit);
        IEnumerable<SanPham> paginationProduct(int start, int limit);

    }
}
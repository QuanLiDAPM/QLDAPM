using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinquorStore.Models
{
    public class CartItem
    {
        public SanPham Product { get; set; }
        public int Quantity { get; set; }
    }
    public class MyCheckOut
    {
        public int ID { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnhBia { get; set; }
        public Nullable<int> DonGia { get; set; }
        public Nullable<short> SoLuong { get; set; }
        public Nullable<System.DateTime> NgayDatHang { get; set; }
        public Nullable<short> TinhTrang { get; set; }
        public Nullable<System.DateTime> DuKienNgayNhan { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinquorStore.Models
{
    [Table("DatHang_ChiTiet")]
    public partial class DatHangChiTiet
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "Đơn đặt hàng")]
        [Column("DatHang_ID")]
        public int? DatHangId { get; set; }

        [Display(Name = "Sản phẩm")]
        [Column("SanPham_ID")]
        public int? SanPhamId { get; set; }

        [Display(Name = "Số lượng")]
        public short SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int DonGia { get; set; }

        [ForeignKey(nameof(DatHangId))]
        [InverseProperty("DatHangChiTiets")]
        public virtual DatHang DatHang { get; set; }
        [ForeignKey(nameof(SanPhamId))]
        [InverseProperty("DatHangChiTiets")]
        public virtual SanPham SanPham { get; set; }
    }
}

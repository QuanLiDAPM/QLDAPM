using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinquorStore.Models
{
    [Table("DatHang")]
    public partial class DatHang
    {
        public DatHang()
        {
            DatHangChiTiets = new HashSet<DatHangChiTiet>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TaiKhoan_ID")]
        public int? TaiKhoanId { get; set; }
        [Column("KhachHang_ID")]
        public int? KhachHangId { get; set; }

        [Display(Name = "Điện thoại giao hàng")]
        [StringLength(255)]
        public string DienThoaiGiaoHang { get; set; }

        [Display(Name = "Địa chỉ giao hàng")]
        [StringLength(255)]
        public string DiaChiGiaoHang { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        [Column(TypeName = "datetime")]
        public DateTime? NgayDatHang { get; set; }

        [Display(Name = "Tình trạng")]
        public short? TinhTrang { get; set; }

        [Display(Name = "Ngày Xác Nhận")]
        [Column(TypeName = "datetime")]
        public DateTime? NgayXacNhan { get; set; }

        [Display(Name = "Dự kiến ngày nhận")]
        [Column(TypeName = "datetime")]
        public DateTime? DuKienNgayNhan { get; set; }

        [Display(Name = "Tên khách hàng")]
        [ForeignKey(nameof(KhachHangId))]
        [InverseProperty("DatHangs")]
        public virtual KhachHang KhachHang { get; set; }

        [Display(Name = "Tài khoản")]
        [ForeignKey(nameof(TaiKhoanId))]
        [InverseProperty("DatHangs")]
        public virtual TaiKhoan TaiKhoan { get; set; }

        
        [InverseProperty(nameof(DatHangChiTiet.DatHang))]
        public virtual ICollection<DatHangChiTiet> DatHangChiTiets { get; set; }
    }
}

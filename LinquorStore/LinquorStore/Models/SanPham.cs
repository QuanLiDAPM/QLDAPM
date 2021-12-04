using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinquorStore.Models
{
    [Table("SanPham")]
    public partial class SanPham
    {
        public SanPham()
        {
            DatHangChiTiets = new HashSet<DatHangChiTiet>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Loai_ID")]
        public int? LoaiId { get; set; }
        [Column("Hang_ID")]
        public int? HangId { get; set; }
        [Column("NoiSanXuat_ID")]
        public int? NoiSanXuatId { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [StringLength(255)]
        public string TenSanPham { get; set; }

        [Display(Name = "Nồng Độ Cồn")]
        [Column(TypeName = "text")]
        public string NongDoCon { get; set; }

        [Display(Name = "Thể Tích")]
        [Column(TypeName = "text")]
        public string TheTich { get; set; }

        [Display(Name = "Ngày Nhập")]
        [Column(TypeName = "datetime")]
        public DateTime? NgayNhap { get; set; }

        [Display(Name = "Đơn Giá")]
        public int DonGia { get; set; }

        [Display(Name = "Số Lượng")]
        public int? SoLuong { get; set; }

        [Display(Name = "Mô Tả")]
        [StringLength(255)]
        public string MoTa { get; set; }

        [Display(Name = "Hình Ảnh Bìa")]
        [StringLength(255)]
        public string HinhAnhBia { get; set; }

        [Display(Name = "Hàng")]
        [ForeignKey(nameof(HangId))]
        [InverseProperty("SanPhams")]
        public virtual Hang Hang { get; set; }

        [Display(Name = "Loại")]
        [ForeignKey(nameof(LoaiId))]
        [InverseProperty("SanPhams")]
        public virtual Loai Loai { get; set; }

        [Display(Name = "Nơi Sản Xuât")]
        [ForeignKey(nameof(NoiSanXuatId))]
        [InverseProperty("SanPhams")]
        public virtual NoiSanXuat NoiSanXuat { get; set; }
        [InverseProperty(nameof(DatHangChiTiet.SanPham))]
        public virtual ICollection<DatHangChiTiet> DatHangChiTiets { get; set; }
    }
}

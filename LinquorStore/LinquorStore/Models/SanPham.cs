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
        [StringLength(255)]
        public string TenSanPham { get; set; }
        [Column(TypeName = "text")]
        public string NongDoCon { get; set; }
        [Column(TypeName = "text")]
        public string TheTich { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayNhap { get; set; }
        public int? DonGia { get; set; }
        public int? SoLuong { get; set; }
        [StringLength(255)]
        public string MoTa { get; set; }
        [StringLength(255)]
        public string HinhAnhBia { get; set; }

        [ForeignKey(nameof(HangId))]
        [InverseProperty("SanPhams")]
        public virtual Hang Hang { get; set; }
        [ForeignKey(nameof(LoaiId))]
        [InverseProperty("SanPhams")]
        public virtual Loai Loai { get; set; }
        [ForeignKey(nameof(NoiSanXuatId))]
        [InverseProperty("SanPhams")]
        public virtual NoiSanXuat NoiSanXuat { get; set; }
        [InverseProperty(nameof(DatHangChiTiet.SanPham))]
        public virtual ICollection<DatHangChiTiet> DatHangChiTiets { get; set; }
    }
}

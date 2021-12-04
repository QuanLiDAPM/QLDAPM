using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinquorStore.Models
{
    [Table("KhachHang")]
    public partial class KhachHang
    {
        public KhachHang()
        {
            DatHangs = new HashSet<DatHang>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }
        [Required]
        [StringLength(255)]
        public string SoDienThoai { get; set; }
        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }
        [Required]
        [StringLength(255)]
        public string TenDangNhap { get; set; }
        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }
        [StringLength(255)]
        public string Mail { get; set; }

        [InverseProperty(nameof(DatHang.KhachHang))]
        public virtual ICollection<DatHang> DatHangs { get; set; }
    }
}

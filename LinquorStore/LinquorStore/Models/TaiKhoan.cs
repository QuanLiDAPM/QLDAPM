using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinquorStore.Models
{
    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            DatHangs = new HashSet<DatHang>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int ChucVu { get; set; }
        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }
        [Required]
        [StringLength(255)]
        public string TenDangNhap { get; set; }
        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }
        [Required]
        [StringLength(255)]
        public string SoDienThoai { get; set; }
        [StringLength(255)]
        public string HinhAnhBia { get; set; }

        [InverseProperty(nameof(DatHang.TaiKhoan))]
        public virtual ICollection<DatHang> DatHangs { get; set; }
    }
}

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
        [Display(Name = "Chức vụ")]
        public int ChucVu { get; set; }

        [Display(Name = "Họ tên")]
        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required]
        [StringLength(255)]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required]
        [StringLength(255)]
        public string SoDienThoai { get; set; }

        [Display(Name = "Hình Ảnh Bìa")]
        [StringLength(255)]
        public string HinhAnhBia { get; set; }


        [InverseProperty(nameof(DatHang.TaiKhoan))]
        public virtual ICollection<DatHang> DatHangs { get; set; }
    }
}

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

        [Display(Name = "Họ tên")]
        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [Display(Name = "Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required]
        [StringLength(255)]
        public string SoDienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required]
        [StringLength(255)]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }

        [Display(Name = "Gmail")]
        [Required]
        [StringLength(255)]
        public string Mail { get; set; }

        [InverseProperty(nameof(DatHang.KhachHang))]
        public virtual ICollection<DatHang> DatHangs { get; set; }
    }
}

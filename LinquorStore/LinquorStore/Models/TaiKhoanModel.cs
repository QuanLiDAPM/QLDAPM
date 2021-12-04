
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LinquorStore.Models
{
    public class TaiKhoanEdit
    {
        public TaiKhoanEdit()
        {
        }
        public TaiKhoanEdit(TaiKhoanEdit kh)
        {
            ID = kh.ID;
            HoTen = kh.HoTen;
            SoDienThoai = kh.SoDienThoai;
            DiaChi = kh.DiaChi;
            TenDangNhap = kh.TenDangNhap;
            MatKhau = kh.MatKhau;
            XacNhanMatKhaU = kh.XacNhanMatKhaU;
        }
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string XacNhanMatKhaU { get; set; }
    }
    public class TaiKhoanSignUp
    {
        public int ID { get; set; }
        [Display(Name = "Họ tên khách hàng")]
        [Required(ErrorMessage = "Họ tên không được bỏ trống!")]
        public string HoTen { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống!")]
        public string SoDienThoai { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống!")]
        public string DiaChi { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
        public string TenDangNhap { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        public string MatKhau { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Xác nhận mật khẩu không được bỏ trống!")]
        public string XacNhanMatKhau { get; set; }
        [Display(Name = "Hình Ảnh Bìa")]
        [StringLength(255)]
        public string HinhAnhBia { get; set; }
    }
    public class TaiKhoanLogin
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }



        internal static Task SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }

    //public class ChangePassword
    //{
    //    [Display(Name = "Mật khẩu cũ")]
    //    [DataType(DataType.Password)]
    //    public string MatKhauCu { get; set; }

    //    [Display(Name = "Mật khẩu mới")]
    //    [DataType(DataType.Password)]
    //    public string MatKhauMoi { get; set; }

    //    [Display(Name = "Xác nhận mật khẩu")]
    //    [DataType(DataType.Password)]
    //    public string XacNhanMatKhau { get; set; }
    //}

}
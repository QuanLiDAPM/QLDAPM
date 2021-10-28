﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopRuou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.DatHang_ChiTiet = new HashSet<DatHang_ChiTiet>();
        }

        public int ID { get; set; }
        public Nullable<int> Loai_ID { get; set; }
        public Nullable<int> Hang_ID { get; set; }
        public Nullable<int> NoiSanXuat_ID { get; set; }
        public string TenSanPham { get; set; }
        public string TheTich { get; set; }
        public string NongDo { get; set; }

        [Display(Name = "Ngày nhập")]
        [Required(ErrorMessage = "Ngày nhập không được bỏ trống!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<int> DonGia { get; set; }
        public Nullable<int> SoLuong { get; set; }
        [Display(Name = "Mô tả")]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }
        public string HinhAnhBia { get; set; }
        [Display(Name = "Hình ảnh bìa")]
        public HttpPostedFileBase DuLieuHinhAnhBia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatHang_ChiTiet> DatHang_ChiTiet { get; set; }
        public virtual Hang Hang { get; set; }
        public virtual Loai Loai { get; set; }
        public virtual NoiSanXuat NoiSanXuat { get; set; }
    }
}
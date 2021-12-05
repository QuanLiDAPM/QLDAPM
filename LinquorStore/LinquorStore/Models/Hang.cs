using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinquorStore.Models
{
    [Table("Hang")]
    public partial class Hang
    {
        public Hang()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Display(Name = "Tên hàng(hiệu)")]
        [Required]
        [StringLength(255)]
        public string TenHang { get; set; }

        [InverseProperty(nameof(SanPham.Hang))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}

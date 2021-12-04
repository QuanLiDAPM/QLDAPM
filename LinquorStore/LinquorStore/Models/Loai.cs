using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinquorStore.Models
{
    [Table("Loai")]
    public partial class Loai
    {
        public Loai()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "Tên Loại")]
        [Required]
        [StringLength(255)]
        public string TenLoai { get; set; }

        [InverseProperty(nameof(SanPham.Loai))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}

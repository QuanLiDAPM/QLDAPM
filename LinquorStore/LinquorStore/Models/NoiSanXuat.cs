using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinquorStore.Models
{
    [Table("NoiSanXuat")]
    public partial class NoiSanXuat
    {
        public NoiSanXuat()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string XuatXu { get; set; }

        [InverseProperty(nameof(SanPham.NoiSanXuat))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}

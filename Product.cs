using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASG.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        [Column("MaSP")]
        public int? MaSp { get; set; }
        [Key]
        [Column("TenSP")]
        [StringLength(50)]
        public string TenSp { get; set; }
        [Column("GiaSP", TypeName = "money")]
        public decimal? GiaSp { get; set; }
        [StringLength(200)]
        public string Anh { get; set; }
        [StringLength(200)]
        public string MoTa { get; set; }
        [StringLength(20)]
        public string TenHang { get; set; }

        [ForeignKey(nameof(TenHang))]
        [InverseProperty(nameof(Category.Products))]
        public virtual Category TenHangNavigation { get; set; }
        [InverseProperty(nameof(Cart.TenSpNavigation))]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}

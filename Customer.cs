using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASG.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
        }

        [Key]
        [Column("MaND")]
        public int MaNd { get; set; }
        [Column("TenND")]
        [StringLength(50)]
        public string TenNd { get; set; }
        [StringLength(100)]
        public string TaiKhoan { get; set; }
        [StringLength(100)]
        public string MatKhau { get; set; }
        [StringLength(20)]
        public string Quyen { get; set; }

        [InverseProperty(nameof(Cart.MaNdNavigation))]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}

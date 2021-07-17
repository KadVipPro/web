using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASG.Models
{
    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        [Column("MaDH")]
        public int MaDh { get; set; }
        [Column("MaND")]
        public int? MaNd { get; set; }
        [Column("TenSP")]
        [StringLength(50)]
        public string TenSp { get; set; }

       

        [ForeignKey(nameof(MaNd))]
        [InverseProperty(nameof(Customer.Carts))]
        public virtual Customer MaNdNavigation { get; set; }
        [ForeignKey(nameof(TenSp))]
        [InverseProperty(nameof(Product.Carts))]
        public virtual Product TenSpNavigation { get; set; }
    }
}

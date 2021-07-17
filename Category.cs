using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ASG.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int? MaHang { get; set; }
        [Key]
        [StringLength(20)]
        public string TenHang { get; set; }

        [InverseProperty(nameof(Product.TenHangNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}

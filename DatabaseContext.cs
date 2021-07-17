using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ASG.Models;

#nullable disable

namespace ASG.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public  DbSet<Cart> Carts { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Customer> Customers { get; set; }
        public  DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DCFD2LU\\KAD;Initial Catalog=ASGC#4;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.MaDh).ValueGeneratedNever();

                entity.HasOne(d => d.MaNdNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.MaNd)
                    .HasConstraintName("FK_Cart_Customers");

                entity.HasOne(d => d.TenSpNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.TenSp)
                    .HasConstraintName("FK_Cart_Products");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.MaNd).ValueGeneratedNever();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.TenHangNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TenHang)
                    .HasConstraintName("FK_Products_Categories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

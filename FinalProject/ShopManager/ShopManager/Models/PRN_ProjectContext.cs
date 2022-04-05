using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ShopManager.Models
{
    public partial class PRN_ProjectContext : DbContext
    {
        public PRN_ProjectContext()
        {
        }

        public PRN_ProjectContext(DbContextOptions<PRN_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("APDBConnectionStr"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Account__DE508E2E43E39903");

                entity.ToTable("Account");

                entity.Property(e => e.Aid).HasColumnName("aid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Role).HasColumnName("role");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK__Orders__C2FFCF13EAB5D406");

                entity.Property(e => e.Oid).HasColumnName("oid");

                entity.Property(e => e.Aid).HasColumnName("aid");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.HasOne(d => d.AidNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Aid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__totalPri__2B3F6F97");
            });

            modelBuilder.Entity<OrdersDetail>(entity =>
            {
                entity.HasKey(e => e.Odid)
                    .HasName("PK__OrdersDe__8D153E0963D41E2E");

                entity.ToTable("OrdersDetail");

                entity.Property(e => e.Odid).HasColumnName("odid");

                entity.Property(e => e.Oid).HasColumnName("oid");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.OidNavigation)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdersDet__price__2E1BDC42");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdersDetai__pid__2F10007B");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Product__DD37D91A3830CF53");

                entity.ToTable("Product");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Pimage)
                    //.IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("pimage");

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pname");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__cid__286302EC");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__ProductC__D837D05F44A4FE4F");

                entity.ToTable("ProductCategory");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("cname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

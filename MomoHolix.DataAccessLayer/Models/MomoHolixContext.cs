using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MomoHolix.DataAccessLayer.Models
{
    public partial class MomoHolixContext : DbContext
    {
        public MomoHolixContext()
        {
        }

        public MomoHolixContext(DbContextOptions<MomoHolixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("MomoHolixDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasColumnName("CartID")
                    .HasColumnType("numeric(4, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.ItemPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ItemQty).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("fk_CustID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("fk_MenuID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("pk_CatID");

                entity.HasIndex(e => e.CatName)
                    .HasName("uk_CatName")
                    .IsUnique();

                entity.Property(e => e.CatId)
                    .HasColumnName("CatID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("pk_CustID");

                entity.HasIndex(e => e.EmailId)
                    .HasName("uk_EmailID")
                    .IsUnique();

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .HasColumnType("numeric(4, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustAddress)
                    .IsRequired()
                    .HasMaxLength(1500);

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(255);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasIndex(e => e.MenuItems)
                    .HasName("uk_MenuItems")
                    .IsUnique();

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CatId)
                    .HasColumnName("CatID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.MenuItems)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.QtyAvailable).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.Spiciness)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("fk_CatID");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.Property(e => e.SalesId)
                    .HasColumnName("SalesID")
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .HasColumnType("numeric(4, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.QtyOrdered).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

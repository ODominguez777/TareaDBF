using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrabajoDBF.Models;

public partial class ExamenFinalFinalContext : DbContext
{
    public ExamenFinalFinalContext()
    {
    }

    public ExamenFinalFinalContext(DbContextOptions<ExamenFinalFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.NameCategory).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.HasIndex(e => e.StatusId, "IX_Order_StatusId");

            entity.HasIndex(e => e.UserId, "IX_Order_UserId");

            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(50)
                .HasColumnName("PostalCOde");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders).HasForeignKey(d => d.StatusId);

            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.ToTable("OrderDetail");

            entity.HasIndex(e => e.ProductId, "IX_OrderDetail_ProductId");

            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.CategoryId, "IX_Product_CategoryId");

            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.ProductDescription).HasMaxLength(300);
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("Rol");

            entity.Property(e => e.RolName).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.RolId, "IX_User_RolId");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Rol).WithMany(p => p.Users).HasForeignKey(d => d.RolId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

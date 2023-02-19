using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoTest.Models;

public partial class ProductContext : DbContext
{
    public ProductContext()
    {
    }

    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Oder> Oders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Oder>(entity =>
        {
            entity.ToTable("Oder");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Orders)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Oder)
                .HasForeignKey<Oder>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Oder_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Qty)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

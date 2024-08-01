using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace testmid.Models.Data;

public partial class CarDealerContext : DbContext
{
    public CarDealerContext()
    {
    }

    public CarDealerContext(DbContextOptions<CarDealerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-RAAS25V;Database=CarDealer;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasMany(d => d.Parts).WithMany(p => p.Cars)
                .UsingEntity<Dictionary<string, object>>(
                    "PartCar",
                    r => r.HasOne<Part>().WithMany()
                        .HasForeignKey("PartId")
                        .HasConstraintName("FK_CarPart_Parts_PartsId"),
                    l => l.HasOne<Car>().WithMany()
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK_CarPart_Cars_CarsId"),
                    j =>
                    {
                        j.HasKey("CarId", "PartId").HasName("PK_CarPart");
                        j.ToTable("PartCars");
                        j.HasIndex(new[] { "PartId" }, "IX_CarPart_PartsId");
                    });
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasIndex(e => e.SupplierId, "IX_Parts_SupplierId");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Parts).HasForeignKey(d => d.SupplierId);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_Sales_CarId");

            entity.HasIndex(e => e.CustomerId, "IX_Sales_CustomerId");

            entity.HasOne(d => d.Car).WithMany(p => p.Sales).HasForeignKey(d => d.CarId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales).HasForeignKey(d => d.CustomerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

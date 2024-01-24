using Microsoft.EntityFrameworkCore;
using System;


public class OrderDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Shipper> Shippers { get; set; }
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Order>()
        .HasMany(e => e.Deliveries)
        .WithOne(e => e.Order)
        .HasForeignKey(e => e.OrderId)
        .OnDelete(DeleteBehavior.Cascade)
        .IsRequired();
        modelBuilder.Entity<Shipper>()
        .HasMany(e => e.Deliveries)
        .WithOne(e => e.Shipper)
        .HasForeignKey(e => e.ShipperId)
        .IsRequired();
        modelBuilder.Entity<Shipper>().HasData(new Shipper()
        {
            ShipperId = 1,
            Code = "EMP001",
            Name = "John"
        });

        modelBuilder.Entity<Shipper>().HasData(new Shipper()
        {
            ShipperId = 2,
            Code = "EMP002",
            Name = "William"
        });
        modelBuilder.Entity<Order>().HasData(new Order()
        {
            OrderId = 1,
            OrderCode = "KM2332",
            Status = "Pending",
            TotalPrice = 12,
            Deliveries = new List<Delivery>()
        });
        

    }
}

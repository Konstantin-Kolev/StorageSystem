using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StorageSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageSystem.Data
{
    public class StorageSystemDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public StorageSystemDbContext()
        {
        }

        public StorageSystemDbContext(DbContextOptions<StorageSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>(order =>
            {
                order.HasOne(o => o.Manager)
                .WithMany(m => m.CreatedOrders)
                .HasForeignKey(o => o.ManagerId)
                .OnDelete(DeleteBehavior.ClientCascade);

                order.HasOne(o => o.Worker)
                .WithMany(w => w.CompletedOrders)
                .HasForeignKey(o => o.WorkerId)
                .OnDelete(DeleteBehavior.ClientCascade);

                order.HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            builder.Entity<Delivery>(delivery =>
            {
                delivery.HasOne(d => d.Worker)
                .WithMany(w => w.AcceptedDeliveries)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            builder.Entity<Manufacturer>(manufacturer =>
            {
                manufacturer.HasMany(m => m.Items)
                .WithOne(i => i.Manufacturer)
                .HasForeignKey(i => i.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Country>(country =>
            {
                country.HasMany(c => c.Clients)
                .WithOne(cl => cl.Country)
                .HasForeignKey(cl => cl.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

                country.HasMany(c => c.Manufacturers)
                .WithOne(m => m.Country)
                .HasForeignKey(m => m.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Item>(item =>
            {
                item.Property(i => i.Description)
                .HasColumnType("Text");

                item.Property(i => i.Price)
                .HasColumnType("Money");
            });

            builder.Entity<OrderItems>(orderItems =>
            {
                orderItems.HasKey(oi => new { oi.OrderId, oi.ItemId });

                orderItems.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.ClientCascade);

                orderItems.HasOne(oi => oi.Item)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(oi => oi.ItemId)
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            builder.Entity<DeliveryItems>(deliveryItems =>
            {
                deliveryItems.HasKey(di => new { di.DeliveryId, di.ItemId });

                deliveryItems.HasOne(di => di.Delivery)
                .WithMany(d => d.DeliveryItems)
                .HasForeignKey(di => di.DeliveryId)
                .OnDelete(DeleteBehavior.ClientCascade);

                deliveryItems.HasOne(di => di.Item)
                .WithMany(i => i.DeliveryItems)
                .HasForeignKey(di => di.ItemId)
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            base.OnModelCreating(builder);
        }

    }
}

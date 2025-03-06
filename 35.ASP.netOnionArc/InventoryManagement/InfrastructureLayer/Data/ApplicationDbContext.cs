using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SupplierItem> SupplierItems { get; set; }
        public DbSet<CustomerItem> CustomerItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserType)
                .WithMany(ut => ut.Users)
                .HasForeignKey(u => u.UserTypeId)
                .IsRequired();

            modelBuilder.Entity<SupplierItem>()
                .HasOne(si => si.Supplier)
                .WithMany(u => u.SupplierItems)
                .HasForeignKey(si => si.SupplierId)
                .IsRequired();

            modelBuilder.Entity<SupplierItem>()
                .HasOne(si => si.Item)
                .WithOne(i => i.SupplierItem)
                .HasForeignKey<SupplierItem>(si => si.ItemId)
                .IsRequired();

            modelBuilder.Entity<CustomerItem>()
                .HasOne(ci => ci.User)
                .WithMany(u => u.CustomerItems)
                .HasForeignKey(ci => ci.UserId)
                .IsRequired();

            modelBuilder.Entity<CustomerItem>()
                .HasOne(ci => ci.Item)
                .WithOne(i => i.CustomerItem)
                .HasForeignKey<CustomerItem>(ci => ci.ItemId)
                .IsRequired();

            modelBuilder.Entity<ItemImage>()
                .HasOne(ii => ii.Item)
                .WithMany(i => i.ItemImages)
                .HasForeignKey(ii => ii.ItemId)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.ItemPrice)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }

    }
}
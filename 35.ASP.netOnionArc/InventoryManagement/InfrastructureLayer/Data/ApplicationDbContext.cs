using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserType)
                .WithMany(ut => ut.Users)
                .HasForeignKey(u => u.UserTypeId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId);

            modelBuilder.Entity<ItemImage>()
                .HasOne(ii => ii.Item)
                .WithMany(i => i.ItemImages)
                .HasForeignKey(ii => ii.ItemId);

            modelBuilder.Entity<SupplierItem>()
                .HasOne(si => si.Supplier)
                .WithMany(u => u.SupplierItems)
                .HasForeignKey(si => si.SupplierId);

            modelBuilder.Entity<SupplierItem>()
                .HasOne(si => si.Item)
                .WithMany(i => i.SupplierItems)
                .HasForeignKey(si => si.ItemId);

            modelBuilder.Entity<CustomerItem>()
                .HasOne(ci => ci.User)
                .WithMany(u => u.CustomerItems)
                .HasForeignKey(ci => ci.UserId);

            modelBuilder.Entity<CustomerItem>()
                .HasOne(ci => ci.Item)
                .WithMany(i => i.CustomerItems)
                .HasForeignKey(ci => ci.ItemId);
        }
    }
}

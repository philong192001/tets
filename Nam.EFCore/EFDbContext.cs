using Microsoft.EntityFrameworkCore;
using Nam.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.EFCore
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> option) : base(option)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<GroupProduct> GroupProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ratting> Evaluates { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
    }
}

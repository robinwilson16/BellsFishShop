using System;
using System.Collections.Generic;
using System.Text;
using BellsFishShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BellsFishShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuCategory> MenuCategory { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<OpeningDay> OpeningDay { get; set; }
        public DbSet<Outlet> Outlet { get; set; }
        public DbSet<OutletOpeningTime> OutletOpeningTime { get; set; }
        public DbSet<OutletFacility> OutletFacility { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Outlet>()
                .HasIndex(o => new { o.OutletRef });
            modelBuilder.Entity<Menu>()
                .HasIndex(m => new { m.MenuRef });
        }

        public DbSet<BellsFishShop.Models.Facility> Facility { get; set; }
    }
}

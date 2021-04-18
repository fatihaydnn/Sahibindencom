using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SahbindenBitirmeProjesi.Data.SeedData;
using SahbindenBitirmeProjesi.Map.Map.Concrete;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahbindenBitirmeProjesi.Data.Context
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Cars> Cars{ get; set; }
        public DbSet<Page> Pages{ get; set; }
        public DbSet<Models> Models{ get; set; }

        //Map işlemlerini implement ettik
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new CarsMap());
            builder.ApplyConfiguration(new PageMap());
            builder.ApplyConfiguration(new ModelsMap());

            builder.ApplyConfiguration(new SeedPage());

            base.OnModelCreating(builder);
        }

        //Lazy loading açmamızı sağladı. Bunun için Manage Nuget Packet tan Microsoft.EntityFrameworkCore.Proxies yükledik.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GoodEntity>().HasData(
                new GoodEntity[]
                {
                    new GoodEntity { Id=1, Name="iPhone X", Category="smartphone", ManufacturId=2, Price=500, Count=5},
                    new GoodEntity { Id=2, Name="iPhone 11", Category="smartphone", ManufacturId=2, Price=600, Count=11},
                    new GoodEntity { Id=3, Name="iPhone 12 Pro", Category="smartphone", ManufacturId=2, Price=1000, Count=18},
                    new GoodEntity { Id=4, Name="galaxy s10", Category="smartphone", ManufacturId=3, Price=650, Count=20},
                    new GoodEntity { Id=5, Name="galaxy s21", Category="smartphone", ManufacturId=3, Price=999, Count=20},
                    new GoodEntity { Id=6, Name="INDESIT XIT8 T2E X", Category="appliances", ManufacturId=4, Price=1200, Count=2},
                    new GoodEntity { Id=7, Name="LG GA-B509SLSM", Category="appliances", ManufacturId=3, Price=1400, Count=3},
                    new GoodEntity { Id=8, Name="SAMSUNG RB38T603FSA", Category="appliances", ManufacturId=3, Price=1200, Count=5},
                    new GoodEntity { Id=9, Name="WHIRLPOOL W7 811I K", Category="appliances", ManufacturId=4, Price=1250, Count=1},
                    new GoodEntity { Id=10, Name="Coat Agneta", Category="clothes", ManufacturId=1, Price=450, Count=38},
                    new GoodEntity { Id=11, Name="Coat Agneta super elite", Category="clothes", ManufacturId=1, Price=800, Count=4},
                    new GoodEntity { Id=12, Name="Coat JulyAndTommy", Category="clothes", ManufacturId=1, Price=799, Count=11},
                    new GoodEntity { Id=13, Name="Jacket men", Category="clothes", ManufacturId=4, Price=200, Count=54},
                    new GoodEntity { Id=14, Name="Jacket men+", Category="clothes", ManufacturId=4, Price=499, Count=15},
                });

            modelBuilder.Entity<CountryEntity>().HasData(
                new CountryEntity[]
                {
                    new CountryEntity { Id=1, Name="Ukraine" },
                    new CountryEntity { Id=2, Name="USA" },
                    new CountryEntity { Id=3, Name="South Korea" },
                    new CountryEntity { Id=4, Name="Chine" },
                    new CountryEntity { Id=5, Name="Japan" }
                });


            modelBuilder.Entity<ManufacturEntity>().HasData(
                new ManufacturEntity[]
                {
                    new ManufacturEntity { Id=1, Name="Happy family", CountryId=1 },
                    new ManufacturEntity { Id=2, Name="Apple", CountryId=2 },
                    new ManufacturEntity { Id=3, Name="SAMSUNG", CountryId=3 },
                    new ManufacturEntity { Id=4, Name="ChinaClothes", CountryId=4 },
                });
        }
    }
}

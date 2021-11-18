using System;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GoodEntity>().HasData(
                new GoodEntity[]
                {
                    new GoodEntity { Id=1, Name="iPhone X", Category="smartphone", ManufacturerId=2, Price=500, Count=5, RegistrationDate=new DateTime(2022, 4, 12)},
                    new GoodEntity { Id=2, Name="iPhone 11", Category="smartphone", ManufacturerId=2, Price=600, Count=11, RegistrationDate=new DateTime(2020, 12, 20)},
                    new GoodEntity { Id=3, Name="iPhone 12 Pro", Category="smartphone", ManufacturerId=2, Price=1000, Count=18, RegistrationDate=new DateTime(2002, 10, 12)},
                    new GoodEntity { Id=4, Name="galaxy s10", Category="smartphone", ManufacturerId=3, Price=650, Count=20, RegistrationDate=new DateTime(2021, 1, 20)},
                    new GoodEntity { Id=5, Name="galaxy s21", Category="smartphone", ManufacturerId=3, Price=999, Count=20, RegistrationDate=new DateTime(2012, 7, 13)},
                    new GoodEntity { Id=6, Name="INDESIT XIT8 T2E X", Category="appliances", ManufacturerId=4, Price=1200, Count=2, RegistrationDate=new DateTime(2017, 4, 4)},
                    new GoodEntity { Id=7, Name="LG GA-B509SLSM", Category="appliances", ManufacturerId=3, Price=1400, Count=3},
                    new GoodEntity { Id=8, Name="SAMSUNG RB38T603FSA", Category="appliances", ManufacturerId=3, Price=1200, Count=5, RegistrationDate=new DateTime(2020, 5, 17)},
                    new GoodEntity { Id=9, Name="WHIRLPOOL W7 811I K", Category="appliances", ManufacturerId=4, Price=1250, Count=1, RegistrationDate=new DateTime(2021, 7, 18)},
                    new GoodEntity { Id=10, Name="Coat Agneta", Category="clothes", ManufacturerId=1, Price=450, Count=38, RegistrationDate=new DateTime(2021, 6, 20)},
                    new GoodEntity { Id=11, Name="Coat Agneta super elite", Category="clothes", ManufacturerId=1, Price=800, Count=4, RegistrationDate=new DateTime(2021, 5, 14)},
                    new GoodEntity { Id=12, Name="Coat JulyAndTommy", Category="clothes", ManufacturerId=1, Price=799, Count=11, RegistrationDate=new DateTime(2021, 7, 19)},
                    new GoodEntity { Id=13, Name="Jacket men", Category="clothes", ManufacturerId=4, Price=200, Count=54, RegistrationDate=new DateTime(2021, 1, 20)},
                    new GoodEntity { Id=14, Name="Jacket men+", Category="clothes", ManufacturerId=4, Price=499, Count=15, RegistrationDate=new DateTime(2021, 7, 20)},
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


            modelBuilder.Entity<ManufacturerEntity>().HasData(
                new ManufacturerEntity[]
                {
                    new ManufacturerEntity { Id=1, Name="Happy family", CountryId=1 },
                    new ManufacturerEntity { Id=2, Name="Apple", CountryId=2 },
                    new ManufacturerEntity { Id=3, Name="SAMSUNG", CountryId=3 },
                    new ManufacturerEntity { Id=4, Name="ChinaClothes", CountryId=4 },
                });
        }
    }
}

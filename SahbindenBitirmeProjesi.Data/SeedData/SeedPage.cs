using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahbindenBitirmeProjesi.Data.SeedData
{
    public class SeedPage : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasData(
                new Page { Id = 1, Title = "Home", Content = "Home Page", Slug = "home-page", Sorting = 100 },
                new Page { Id = 2, Title = "About Us", Content = "About Us Page", Slug = "about-page", Sorting = 100 },
                new Page { Id = 3, Title = "Contact Us", Content = "Conctact Us Page", Slug = "contact-page", Sorting = 100 });
        }
    }
}

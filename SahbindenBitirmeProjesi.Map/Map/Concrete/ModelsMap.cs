using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahbindenBitirmeProjesi.Map.Map.Abstract;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahbindenBitirmeProjesi.Map.Map.Concrete
{
    public class ModelsMap:BaseMap<Models>
    {
        public override void Configure(EntityTypeBuilder<Models> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Year).IsRequired(true);
            builder.Property(x => x.Fuel).IsRequired(true);
            builder.Property(x => x.Gear).IsRequired(true);
            builder.Property(x => x.HorsePower).IsRequired(true);
            builder.Property(x => x.Color).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.UnitPrice).IsRequired(true);
            builder.Property(x => x.Image).IsRequired(true);
            builder.HasOne(x => x.Cars)
                .WithMany(x => x.Models)
                .HasForeignKey(x => x.CarsId);
            base.Configure(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahbindenBitirmeProjesi.Map.Map.Abstract;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahbindenBitirmeProjesi.Map.Map.Concrete
{
    public class CarsMap:BaseMap<Cars>
    {
        public override void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            base.Configure(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahbindenBitirmeProjesi.Map.Map.Abstract;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahbindenBitirmeProjesi.Map.Map.Concrete
{
    public class PageMap:BaseMap<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Slug).IsRequired(false);
            builder.Property(x => x.Sorting).IsRequired(false);
            builder.Property(x => x.Content).IsRequired(true);
            base.Configure(builder);
        }
    }
}

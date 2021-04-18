using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahbindenBitirmeProjesi.Map.Map.Abstract;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahbindenBitirmeProjesi.Map.Map.Concrete
{
    public class AppUserMap:BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            base.Configure(builder);
        }
    }
}

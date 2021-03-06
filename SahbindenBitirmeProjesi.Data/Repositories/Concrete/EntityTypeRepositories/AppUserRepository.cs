using SahbindenBitirmeProjesi.Data.Context;
using SahbindenBitirmeProjesi.Data.Repositories.Concrete.Base;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahbindenBitirmeProjesi.Data.Repositories.Concrete.EntityTypeRepositories
{
    public class AppUserRepository: KernelRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext){}
    }
}

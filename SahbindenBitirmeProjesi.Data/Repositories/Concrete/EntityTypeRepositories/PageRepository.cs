using SahbindenBitirmeProjesi.Data.Context;
using SahbindenBitirmeProjesi.Data.Repositories.Concrete.Base;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahbindenBitirmeProjesi.Data.Repositories.Concrete.EntityTypeRepositories
{
    public class PageRepository: KernelRepository<Page>, IPageRepository
    {
        public PageRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext){}
    }
}

using Microsoft.AspNetCore.Mvc;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using SahibindenBitirmeProjesi.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahibindenBitirmeProjesi.Web.Models.Components
{
    public class MainMenuViewComponent:ViewComponent
    {
        private readonly IPageRepository _pageRepository;
        public MainMenuViewComponent(IPageRepository pageRepository) => _pageRepository = pageRepository;
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pages = await GetPagesAsync();
            return View(pages);
        }

        private async Task<List<Page>> GetPagesAsync() => await _pageRepository.Get(x => x.Status != Status.Passive);

    }
}

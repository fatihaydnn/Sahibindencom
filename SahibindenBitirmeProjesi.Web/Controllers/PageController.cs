using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;

namespace SahibindenBitirmeProjesi.Web.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageRepository _pageRepository;
        public PageController(IPageRepository pageRepository) => _pageRepository = pageRepository;

        public async Task<IActionResult> Page(string slug)
        {
            if (slug == null) return View(await _pageRepository.FirstOrDefault(x => x.Slug == "home-page"));

            Page page = await _pageRepository.FirstOrDefault(x => x.Slug == slug);

            if (page == null) return NotFound();

            return View(page);
        }
    }
}

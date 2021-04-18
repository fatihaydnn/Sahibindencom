using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using SahibindenBitirmeProjesi.Entity.Enums;

namespace SahibindenBitirmeProjesi.Web.Areas.Admin.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly IPageRepository _pageRepository;

        public PageController(IPageRepository pageRepository) => _pageRepository = pageRepository;

        public async Task<IActionResult> List() => View(await _pageRepository.Get(x=> x.Status != Status.Passive));

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                var slug = await _pageRepository.FirstOrDefault(x => x.Slug == page.Slug);

                if (slug!=null)
                {
                    ModelState.AddModelError("", "Bu sayfa bulunuyor..!");
                    TempData["Warning"] = "Sayfa bulunuyor..!";
                    return View(page);
                }

                await _pageRepository.Add(page);
                TempData["Success"] = "Sayfa eklendi..!";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "Sayfa eklenemedi..!";
                return RedirectToAction("List");
            }
        }

        public async Task<IActionResult> Edit(int id) => View(await _pageRepository.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                var slug = _pageRepository.FirstOrDefault(x => x.Slug == page.Slug);
                if (slug == null)
                {
                    ModelState.AddModelError("", "Bu sayfa bulunuyor..!");
                    TempData["Warning"] = "Sayfa bulunuyor..!";
                    return View(page);
                }
                else
                {
                    page.UpdateDate = DateTime.Now;
                    page.Status = Status.Modified;
                    await _pageRepository.Update(page);
                    TempData["Success"] = "Sayfa güncellendi..!";
                    return RedirectToAction("List");
                }
            }
            else
            {
                TempData["Error"] = "Sayfa güncellenemedi..!";
                return View(page);
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            Page page = await _pageRepository.GetById(id);
            if (page != null)
            {
                await _pageRepository.Delete(page);
                TempData["Success"] = "Syafa silindi..!";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "Sayfa silinemedi..!";
                return RedirectToAction("List");
            }
        }

        
    }
}

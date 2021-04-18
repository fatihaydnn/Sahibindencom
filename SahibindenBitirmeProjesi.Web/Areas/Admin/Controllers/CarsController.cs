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
    //[Authorize(Roles = "admin")]
    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly ICarsRepository _carsRepository;

        public CarsController(ICarsRepository carsRepository) => _carsRepository = carsRepository;

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Cars cars)
        {
            if (ModelState.IsValid)
            {
                cars.Slug = cars.Name.ToLower().Replace(" ", "-");
                var slug = await _carsRepository.FirstOrDefault(x => x.Slug == cars.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Bu araç zaten bulunmaktadır..!");
                    TempData["Warning"] = "Bu araç zaten bulunmaktadır..!";
                    return View(cars);
                }
                else
                {
                    await _carsRepository.Add(cars);
                    TempData["Success"] = "Araba eklendi..!";
                    return RedirectToAction("List");
                }
            }
            else
            {
                TempData["Error"] = "Araç eklenemedi..!";
                return View(cars);
            }
        }

        public async Task<IActionResult> List() => View(await _carsRepository.Get(x => x.Status != Status.Passive));

        public async Task<IActionResult> Edit(int id) => View(await _carsRepository.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Edit(Cars cars)
        {
            if (ModelState.IsValid)
            {
                cars.Slug = cars.Name.ToLower().Replace(" ", "-");
                var slug = await _carsRepository.FirstOrDefault(x => x.Slug == cars.Slug);
                if (slug!=null)
                {
                    ModelState.AddModelError("", "Bu araba bulunuyor..!");
                    TempData["Warning"] = "Bu araba bulunuyor..!";
                    return View(cars);
                }
                else
                {
                    cars.UpdateDate = DateTime.Now;
                    cars.Status = Status.Modified;
                    await _carsRepository.Update(cars);
                    TempData["Success"] = "Araba güncellendi..!";
                    return RedirectToAction("List");
                }
            }
            else
            {
                TempData["Error"] = "Araba güncellenemedi..!";
                return View(cars);
            }

        }

        public async Task<IActionResult> Remove(int id)
        {
            Cars cars = await _carsRepository.GetById(id);
            if (cars != null)
            {
                await _carsRepository.Delete(cars);
                TempData["Success"] = "Araba silindi..!";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "Araba silinemedi..!";
                return RedirectToAction("List");
            }
        }

    }
}

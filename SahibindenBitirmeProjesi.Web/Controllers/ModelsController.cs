using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using SahibindenBitirmeProjesi.Entity.Enums;

namespace SahibindenBitirmeProjesi.Web.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IModelsRepository _modelsRepository;
        private readonly ICarsRepository _carsRepository;

        public ModelsController(IModelsRepository modelsRepository, ICarsRepository carsRepository)
        {
            _modelsRepository = modelsRepository;
            _carsRepository = carsRepository;
        }

        public async Task<IActionResult> Index() => View(await _modelsRepository.Get(x => x.Status != Status.Passive));

        public async Task<IActionResult> ModelsByCar(int id)
        {
            Cars car = await _carsRepository.FirstOrDefault(x => x.Id == id);
            if (car == null) return RedirectToAction("Index");

            ViewBag.CarsName = car.Name;
            ViewBag.CarsSlug = car.Slug;

            List<SahibindenBitirmeProjesi.Entity.Entities.Concrete.Models> model = await _modelsRepository.Get(x => x.CarsId == car.Id);

            return View(model);
        }
    }
}

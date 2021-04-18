using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using SahibindenBitirmeProjesi.Entity.Enums;

namespace SahibindenBitirmeProjesi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelController : Controller
    {
        private readonly IModelsRepository _modelsRepository;
        private readonly ICarsRepository _carsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ModelController(IModelsRepository modelsRepository, ICarsRepository carsRepository, IWebHostEnvironment webHostEnvironment)
        {
            _modelsRepository = modelsRepository;
            _carsRepository = carsRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CarId = new SelectList(await _carsRepository.Get(x => x.Status != Status.Passive), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SahibindenBitirmeProjesi.Entity.Entities.Concrete.Models model)
            {
            if (ModelState.IsValid)
            {
                string imageName = "noimage.png";
                if (model.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/models");
                    imageName = Guid.NewGuid().ToString() + "_" + model.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await model.ImageUpload.CopyToAsync(fileStream);
                    fileStream.Close();
                }
                model.Image = imageName;
                await _modelsRepository.Add(model);
                TempData["Success"] = "Model eklendi..!";
                return View();
            }
            else
            {
                TempData["Error"] = "Model eklenemedi..!";
                return View(model);
            }
        }

        public async Task<IActionResult> List() => View(await _modelsRepository.Get(x => x.Status != Status.Passive));

        public async Task<IActionResult> Edit(int id)
        {
            SahibindenBitirmeProjesi.Entity.Entities.Concrete.Models model = await _modelsRepository.GetById(id);
            ViewBag.CarId = new SelectList(await _carsRepository.Get(x => x.Status != Status.Passive), "Id", "Name", model.CarsId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SahibindenBitirmeProjesi.Entity.Entities.Concrete.Models model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/models");
                    if (!string.Equals(model.Image,"noimage.png"))
                    {
                        string oldPath = Path.Combine(uploadDir, model.Image);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    string imageName = Guid.NewGuid().ToString() + "_" + model.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await model.ImageUpload.CopyToAsync(fileStream);
                    fileStream.Close();
                    model.Image = imageName;
                }
                await _modelsRepository.Update(model);
                TempData["Success"] = "Model başarıyla güncellendi..!";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "Model güncellenemedi..!";
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            SahibindenBitirmeProjesi.Entity.Entities.Concrete.Models model = await _modelsRepository.GetById(id);
            if (model!=null)
            {
                await _modelsRepository.Delete(model);
                TempData["Success"] = "Model başarıyla silindi..!";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "Model silindi..!";
                return RedirectToAction("List");
            }
        }

    }
}

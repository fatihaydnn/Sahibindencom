using Microsoft.AspNetCore.Mvc;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahibindenBitirmeProjesi.Web.Models.Components
{
    public class CarsViewComponent:ViewComponent
    {
        private readonly ICarsRepository _carsRepository;
        public CarsViewComponent(ICarsRepository carsRepository) => _carsRepository = carsRepository;

        public async Task<IViewComponentResult> InvokeAsync() => View(await _carsRepository.GetAll());
    }
}

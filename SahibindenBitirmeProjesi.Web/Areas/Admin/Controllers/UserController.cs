using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;

namespace SahibindenBitirmeProjesi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserRepository _appUserRepository;

        public UserController(UserManager<AppUser> userManager, IAppUserRepository appUserRepository) 
        { 
            _userManager = userManager;
            _appUserRepository = appUserRepository;
        }

        public IActionResult Index() =>  View(_userManager.Users);

        public async Task<IActionResult> Remove(int id)
        {
            AppUser user = await _appUserRepository.GetById(id);
            if (user != null)
            {
                await _appUserRepository.Delete(user);
                TempData["Success"] = "The category deleted..!";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "The category hasn't been deleted..!";
                return RedirectToAction("List");
            }
        }
    }
}

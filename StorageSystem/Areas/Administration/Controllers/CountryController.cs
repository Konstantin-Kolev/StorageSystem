using Microsoft.AspNetCore.Mvc;
using StorageSystem.Models.Country;
using StorageSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Areas.Administration.Controllers
{
    public class CountryController : AdministrationBaseController
    {
        private readonly ICountryService countryService;
        private readonly IManufacturerService manufacturerService;

        public CountryController(ICountryService countryService, IManufacturerService manufacturerService)
        {
            this.countryService = countryService;
            this.manufacturerService = manufacturerService;
        }

        public IActionResult Index() => View(countryService.GetAllViewModel());

        public IActionResult Details(int id)
        {
            CountryDetailsViewModel model = countryService.FindById<CountryDetailsViewModel>(id);
            model.Manufacturers = manufacturerService.GetAll().Where(m => m.CountryId == model.Id);
            return View(model);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CountryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await countryService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            CountryEditInputModel model = countryService.FindById<CountryEditInputModel>(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CountryEditInputModel model)
        {
            await countryService.Update(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            CountryDetailsViewModel model = countryService.FindById<CountryDetailsViewModel>(id);
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await countryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

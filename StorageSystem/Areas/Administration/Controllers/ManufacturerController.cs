using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StorageSystem.Data.Entities;
using StorageSystem.Models.Manufacturer;
using StorageSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Areas.Administration.Controllers
{
    public class ManufacturerController : AdministrationBaseController
    {
        private readonly IManufacturerService manufactuerService;
        private readonly ICountryService countryService;
        private readonly SelectList countryList;

        public ManufacturerController(IManufacturerService manufactuerService, ICountryService countryService)
        {
            this.manufactuerService = manufactuerService;
            this.countryService = countryService;

            countryList = new SelectList(countryService.GetAll(), "Id", "Name");
        }

        public IActionResult Index()
        {
            IEnumerable<ManufacturerViewModel> models = manufactuerService.GetAll();
            foreach(var model in models)
            {
                model.CountryCode = countryService.GetById(model.CountryId).Code;
            }

            return View(models);
        }

        public IActionResult Details(int id)
        {
            ManufacturerDetailsModel model = manufactuerService.FindById<ManufacturerDetailsModel>(id);
            model.CountryName = countryService.GetById(model.CountryId).Name;
            return View(model);
        }

        public IActionResult Create()
        {
            ViewData["CountryId"] = countryList;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(ManufacturerInputModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewData["CountryId"] = countryList;
                return View(model);
            }

            await manufactuerService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ManufacturerEditInputModel model = manufactuerService.FindById<ManufacturerEditInputModel>(id);
            ViewData["CountryId"] = countryList;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ManufacturerEditInputModel model)
        {
            await manufactuerService.Update(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ManufacturerDetailsModel model = manufactuerService.FindById<ManufacturerDetailsModel>(id);
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await manufactuerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

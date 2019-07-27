using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service) =>
            _service = service;

        public async Task<IActionResult> Index(int? type, int? category, int? zipcode, int? city, int? page)
        {
            var itemsOnPage = 6;
            var catalog =
                await _service.GetCatalogEventsAsync(page ?? 0,
                itemsOnPage, type, category, zipcode, city);

            var vm = new CatalogIndexViewModel
            {
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                CatalogEvents = catalog.Data,
                Types = await _service.GetTypesAsync(),
                Categories = await _service.GetCategoriesAsync(),
                ZipCodes = await _service.GetEventZipcodesAsync(),
                Cities = await _service.GetEventCitiesAsync(),
                TypesFilterApplied = type ?? 0,
                CategoriesFilterApplied = category ?? 0,
                ZipCodesFilterApplied = zipcode ?? 0,
                CitiesFilterApplied = city ?? 0
            };

            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";
            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";

            return View(vm);
        }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface ICatalogService
    {
        Task<CatalogPVM> GetCatalogEventsAsync(int page, int size,
            int? type, int? category, int? zipcode, int? city);

        Task<IEnumerable<SelectListItem>> GetTypesAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetZipCodesAsync();
        Task<IEnumerable<SelectListItem>> GetCitiesAsync();


    }
}

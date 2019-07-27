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
        Task<Catalog> GetCatalogEventsAsync(int page, int size,
    int? category, int? type, int ? eventcity, int ? eventzipcode);

        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetTypesAsync();
        Task<IEnumerable<SelectListItem>> GetEventCitiesAsync();
        Task<IEnumerable<SelectListItem>> GetEventZipcodesAsync();

    }
}

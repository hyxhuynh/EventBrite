using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> ZipCodes { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<CatalogEvent> CatalogEvents { get; set; }

        public int? TypesFilterApplied { get; set; }
        public int? CategoriesFilterApplied { get; set; }
        public int? ZipCodesFilterApplied { get; set; }
        public int? CitiesFilterApplied { get; set; }

    }
}

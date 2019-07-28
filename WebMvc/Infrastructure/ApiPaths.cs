using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}catalogtypes";
            }
            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}catalogcategories";
            }

            public static string GetAllZipCodes(string baseUri)
            {
                return $"{baseUri}catalogeventzipcodes";
            }

            public static string GetAllCities(string baseUri)
            {
                return $"{baseUri}catalogeventcities";
            }

            public static string GetAllCatalogEvents(string baseUri,
                int page, int take, int? type, int? category, int? zipcode, int? city)
            {
                var filterQs = string.Empty;

                if (type.HasValue || category.HasValue || zipcode.HasValue || city.HasValue)
                {
                    var typesQs = (type.HasValue) ? type.Value.ToString() : "null";
                    var categoriesQs = (category.HasValue) ? category.Value.ToString() : "null";
                    var zipcodesQs = (zipcode.HasValue) ? zipcode.Value.ToString() : "null";
                    var citiesQs = (city.HasValue) ? city.Value.ToString() : "null";
                    filterQs = $"/type/{typesQs}/category/{categoriesQs}/zipcode/{zipcodesQs}/city/{citiesQs}";
                }

                return $"{baseUri}events{filterQs}?pageIndex={page}&pageSize={take}";

            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IHttpClient _client;
        private readonly string _baseUri;

        public CatalogService(IHttpClient httpclient,
            IConfiguration config)
        {
            _client = httpclient;
            _baseUri = $"{config["CatalogUrl"]}/api/catalog/";
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = ApiPaths.Catalog.GetAllTypes(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var events = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };

            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                events.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("type")
                    }
                 );
            }

            return events;
        }

        public async Task<CatalogPVM> GetCatalogEventsAsync(int page, int size, int? type, int? category, int? zipcode, int? city)
        {
            var catalogEventsUri = ApiPaths.Catalog
                            .GetAllCatalogEvents(_baseUri,
                                page, size, type, category, zipcode, city);

            var dataString = await _client.GetStringAsync(catalogEventsUri);
            var response = JsonConvert.DeserializeObject<CatalogPVM>(dataString);
            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categoryUri = ApiPaths.Catalog.GetAllCategories(_baseUri);
            var dataString = await _client.GetStringAsync(categoryUri);
            var events = new List<SelectListItem>
            //use differente variable name?
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };

            var categories = JArray.Parse(dataString);
            foreach (var category in categories)
            {
                events.Add(
                    new SelectListItem
                    {
                        Value = category.Value<string>("id"),
                        Text = category.Value<string>("category")
                    }
                 );
            }

            return events;
        }

        public async Task<IEnumerable<SelectListItem>> GetZipCodesAsync()
        {
            var zipUri = ApiPaths.Catalog.GetAllZipCodes(_baseUri);
            var dataString = await _client.GetStringAsync(zipUri);
            var events = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };

            var zips = JArray.Parse(dataString);
            foreach (var zip in zips)
            {
                events.Add(
                    new SelectListItem
                    {
                        Value = zip.Value<string>("id"),
                        Text = zip.Value<string>("zipcode")
                    }
                 );
            }

            return events;
        }

        public async Task<IEnumerable<SelectListItem>> GetCitiesAsync()
        {
            var cityUri = ApiPaths.Catalog.GetAllCities(_baseUri);
            var dataString = await _client.GetStringAsync(cityUri);
            var events = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };

            var cities = JArray.Parse(dataString);
            foreach (var city in cities)
            {
                events.Add(
                    new SelectListItem
                    {
                        Value = city.Value<string>("id"),
                        Text = city.Value<string>("city")
                    }
                 );
            }

            return events;
        }
    }
}

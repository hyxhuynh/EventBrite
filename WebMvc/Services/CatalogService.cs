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
        public async Task<Catalog> GetCatalogEventsAsync(int page, int size, int? category, int? type, int? eventcity, int? eventzipcode)
        {
            var catalogEventsUri = ApiPaths.Catalog
                            .GetAllCatalogEvents(_baseUri,
                                page, size, category, type, eventcity, eventzipcode);

            var dataString = await _client.GetStringAsync(catalogEventsUri);
            var response = JsonConvert.DeserializeObject<Catalog>(dataString);
            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categoryUri = ApiPaths.Catalog.GetAllCategories(_baseUri);
            var dataString = await _client.GetStringAsync(categoryUri);
            var events = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };

            var categories = JArray.Parse(dataString);
            foreach (var eventItem in categories)
            {
                events.Add(
                    new SelectListItem
                    {
                        Value = eventItem.Value<string>("id"),
                        Text = eventItem.Value<string>("category")
                    }
                 );
            }

            return events;
        }

        public async Task<IEnumerable<SelectListItem>> GetEventCitiesAsync()
        {
            var cityUri = ApiPaths.Catalog.GetAllEventCities(_baseUri);
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

        public async Task<IEnumerable<SelectListItem>> GetEventZipcodesAsync()
        {
            var zipUri = ApiPaths.Catalog.GetAllEventZipcodes(_baseUri);
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
    }
}

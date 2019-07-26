using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

        // Continue here ==================
        public Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetEventCitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetEventZipcodesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;
        public CatalogController(CatalogContext context,
            IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET api/catalog/items?pageSize=10&pageIndex=2
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Events(
            [FromQuery]int pageSize = 6,
            [FromQuery]int pageIndex = 0)
        {
            var eventsCount = await _context.CatalogEvents.LongCountAsync();

            var events = await _context.CatalogEvents
                 .OrderBy(c => c.Name)
                 .Skip(pageSize * pageIndex)
                 .Take(pageSize)
                 .ToListAsync();
            events = ChangePictureUrl(events);
            var model = new PaginatedItemsViewModel<CatalogEvent>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = eventsCount,
                Data = events
            };
            return Ok(model);
        }

        // GET api/Catalog/Items/type/1/brand/null[?pageSize=4&pageIndex=0]
        [HttpGet]
        [Route("[action]/category/{catalogCategoryId}/type/{catalogTypeId}")]
        public async Task<IActionResult> Events(int? catalogCategoryId,
            int? catalogTypeId, int? catalogEventZipCodeId, int? catalogEventCityId,
            [FromQuery] int pageSize = 6,
            [FromQuery] int pageIndex = 0)
        {
            var root = (IQueryable<CatalogEvent>)_context.CatalogEvents;

            if (catalogCategoryId.HasValue)
            {
                root = root.Where(c => c.CatalogCategoryId == catalogCategoryId);
            }
            if (catalogTypeId.HasValue)
            {
                root = root.Where(c => c.CatalogTypeId == catalogTypeId);
            }
            if (catalogEventZipCodeId.HasValue)
            {
                root = root.Where(c => c.CatalogEventZipcodeId == catalogEventZipCodeId);
            }
            if (catalogEventCityId.HasValue)
            {
                root = root.Where(c => c.CatalogEventCityId == catalogEventCityId);
            }

            var totalEvents = await root
                              .LongCountAsync();
            var eventsOnPage = await root
                              .OrderBy(c => c.Name)
                              .Skip(pageSize * pageIndex)
                              .Take(pageSize)
                              .ToListAsync();
            eventsOnPage = ChangePictureUrl(eventsOnPage);
            var model = new PaginatedItemsViewModel<CatalogEvent>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = totalEvents,
                Data = eventsOnPage
            };

            return Ok(model);
        }


        private List<CatalogEvent> ChangePictureUrl(
            List<CatalogEvent> events)
        {
            events.ForEach(
                c =>
                c.PictureUrl =
                 c.PictureUrl
                 .Replace("http://externalcatalogbaseurltobereplaced"
                 , _config["ExternalCatalogBaseUrl"]));

            return events;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogCategories()
        {
            var events = await _context.CatalogCategories.ToListAsync();
            return Ok(events);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
            var events = await _context.CatalogTypes.ToListAsync();
            return Ok(events);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogEventCities()
        {
            var events = await _context.CatalogEventCities.ToListAsync();
            return Ok(events);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogEventZipcodes()
        {
            var events = await _context.CatalogEventZipcodes.ToListAsync();
            return Ok(events);
        }


        [HttpGet]
        [Route("events/{id:int}")]
        public async Task<IActionResult> GetEventsById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Incorrect Id!");
            }

            var even = await _context.CatalogEvents
                            .SingleOrDefaultAsync(c => c.Id == id);


            if (even == null)
            {
                return NotFound("Event item not found");
            }

            even.PictureUrl = even.PictureUrl
                 .Replace("http://externalcatalogbaseurltobereplaced"
                 , _config["ExternalCatalogBaseUrl"]);
            return Ok(even);
        }

        //GET api/Catalog/items/withname/Wonder?pageSize=2&pageIndex=0
        [HttpGet]
        [Route("[action]/withname/{name:minlength(1)}")]
        public async Task<IActionResult> Events(string name,
            [FromQuery] int pageSize = 6,
            [FromQuery] int pageIndex = 0)
        {
            var totalEvents = await _context.CatalogEvents
                               .Where(c => c.Name.StartsWith(name))
                              .LongCountAsync();
            var eventsOnPage = await _context.CatalogEvents
                              .Where(c => c.Name.StartsWith(name))
                              .OrderBy(c => c.Name)
                              .Skip(pageSize * pageIndex)
                              .Take(pageSize)
                              .ToListAsync();
            eventsOnPage = ChangePictureUrl(eventsOnPage);
            var model = new PaginatedItemsViewModel<CatalogEvent>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = totalEvents,
                Data = eventsOnPage
            };

            return Ok(model);

        }
        /*
        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> CreateProduct(
            [FromBody] CatalogItem product)
        {
            var item = new CatalogItem
            {
                CatalogBrandId = product.CatalogBrandId,
                CatalogTypeId = product.CatalogTypeId,
                Description = product.Description,
                Name = product.Name,
                PictureUrl = product.PictureUrl,
                Price = product.Price
            };
            _context.CatalogItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItemsById), new { id = item.Id });
        }


        [HttpPut]
        [Route("items")]
        public async Task<IActionResult> UpdateProduct(
            [FromBody] CatalogItem productToUpdate)
        {
            var catalogItem = await _context.CatalogItems
                              .SingleOrDefaultAsync
                              (i => i.Id == productToUpdate.Id);
            if (catalogItem == null)
            {
                return NotFound(new { Message = $"Item with id {productToUpdate.Id} not found." });
            }
            catalogItem = productToUpdate;
            _context.CatalogItems.Update(catalogItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemsById), new { id = productToUpdate.Id });
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.CatalogItems
                .SingleOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();

            }
            _context.CatalogItems.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        */

    }
}
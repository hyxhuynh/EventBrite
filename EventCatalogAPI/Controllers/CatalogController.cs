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
            [FromQuery]int pageSize = 5,
            [FromQuery]int pageIndex = 0)
        {
            var eventsCount = await _context.CatalogEvents.LongCountAsync();

            var events = await _context.CatalogEvents
                 .OrderBy(c => c.Name)
                 .Skip(pageSize * pageIndex)
                 .Take(pageSize)
                 .ToListAsync();
            events = ChangePictureUrl(events);
            var model = new PaginatedEventsViewModel<CatalogEvent>
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
        [Route("[action]/category/{catalogCategoryId}/type/{catalogTypeId}/zipcode/{catalogZipcodeId}/city/{catalogCityId}")]
        public async Task<IActionResult> Events(int? catalogCategoryId,
            int? catalogTypeId, int? catalogEventZipcodeId, int? catalogEventCityId,
            [FromQuery] int pageSize = 5,
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
            if (catalogEventZipcodeId.HasValue)
            {
                root = root.Where(c => c.CatalogEventZipcodeId == catalogEventZipcodeId);
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
            var model = new PaginatedEventsViewModel<CatalogEvent>
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

            var eventItem = await _context.CatalogEvents
                            .SingleOrDefaultAsync(c => c.Id == id);


            if (eventItem == null)
            {
                return NotFound("Event item not found");
            }

            eventItem.PictureUrl = eventItem.PictureUrl
                 .Replace("http://externalcatalogbaseurltobereplaced"
                 , _config["ExternalCatalogBaseUrl"]);
            return Ok(eventItem);
        }

        //GET api/Catalog/items/withname/Wonder?pageSize=2&pageIndex=0
        [HttpGet]
        [Route("[action]/withname/{name:minlength(1)}")]
        public async Task<IActionResult> Events(string name,
            [FromQuery] int pageSize = 5,
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
            var model = new PaginatedEventsViewModel<CatalogEvent>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = totalEvents,
                Data = eventsOnPage
            };

            return Ok(model);
        }
        //JewelsonContainer- instead of "Item"  for the next 3 methods Kal states "Product" - just a naming difference
        [HttpPost]
        [Route("events")]
        public async Task<IActionResult> CreateEvent(
            [FromBody] CatalogEvent individualEvent)
        {
            var eventItem = new CatalogEvent
            {
                CatalogTypeId = individualEvent.CatalogTypeId,
                CatalogCategoryId = individualEvent.CatalogCategoryId,
                CatalogEventZipcodeId = individualEvent.CatalogEventZipcodeId,
                CatalogEventCityId = individualEvent.CatalogEventCityId,
                Description = individualEvent.Description,
                Name = individualEvent.Name,
                PictureUrl = individualEvent.PictureUrl,
                Price = individualEvent.Price
            };
            _context.CatalogEvents.Add(individualEvent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEventsById), new { id = individualEvent.Id });
        }

        [HttpPut]
        [Route("events")]
        public async Task<IActionResult> UpdateEvents(
            [FromBody] CatalogEvent eventToUpdate)
        {
            var catalogEvent = await _context.CatalogEvents
                              .SingleOrDefaultAsync
                              (i => i.Id == eventToUpdate.Id);
            if (catalogEvent == null)
            {
                return NotFound(new { Message = $"Item with id {eventToUpdate.Id} not found." });
            }
            catalogEvent = eventToUpdate;
            _context.CatalogEvents.Update(catalogEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventsById), new { id = eventToUpdate.Id });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventItem = await _context.CatalogEvents
                .SingleOrDefaultAsync(p => p.Id == id);
            if (eventItem == null)
            {
                return NotFound();

            }
            _context.CatalogEvents.Remove(eventItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}


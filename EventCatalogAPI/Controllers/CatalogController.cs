using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        private readonly CatalogContext _context;
        private readonly IConfiguration _config;
        public CatalogController(CatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Events(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var eventsCount = _context.Events.LongCountAsync();
            var events = await _context.Events
                  .OrderBy(e => e.Name)
                  .Skip(pageIndex * pageSize)
                  .Take(pageSize)
                  .ToListAsync();

            events = ChangePictureUrl(events);
            var model = new PaginatedEventsViewModels
            {
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount.Result,
                Data = events


            };
            return Ok(model);

        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> EventOrganizers()
        {
            var organizers = await _context.EventOrganizers.ToListAsync();
            return Ok(organizers);
        }
        [HttpGet("[Action]/filtered")]
        public async Task<IActionResult> Events(
            [FromQuery] int? EventTypeId,
            [FromQuery] int? EventOraganizerId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.Events;
            if(EventTypeId.HasValue)
            {
                query=query.Where(T => T.EventTypeId == EventTypeId);
            }
            if (EventOraganizerId.HasValue)
            {
                query=query.Where(O => O.EventOrganizerId == EventOraganizerId);
            }
            var eventsCount = query.LongCountAsync();
            var events = await query
                  .OrderBy(e => e.Name)
                  .Skip(pageIndex * pageSize)
                  .Take(pageSize)
                  .ToListAsync();

            events = ChangePictureUrl(events);
            var model = new PaginatedEventsViewModels
            {
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount.Result,
                Data = events


            };
            return Ok(model);

        }
        private List<Event> ChangePictureUrl(List<Event> events)
        {
            events.ForEach(e => e.PictureUrl= e.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogUrl"]));

            return events;

        }

    }
}


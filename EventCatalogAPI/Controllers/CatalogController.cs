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
            [HttpGet("[action]/{pageIndex}/{pageSize}")]
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
                return Ok(events);

            }

            private List<Event> ChangePictureUrl(List<Event> events)
            {
                events.ForEach(events =>
                events.PictureUrl.Replace("http://externalcatalogtobereplaced", _config["ExternalCatalogUrl"]));

                return events;

            }
        }
    }
}


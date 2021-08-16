﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page,int? organizerFilterApplied,int? typeFilterApplied)
        {
            var itemsOnPage = 10;
            var events= await _service.GetEventsAsync(page ?? 0, itemsOnPage, organizerFilterApplied, typeFilterApplied);
            var vm = new EventsCatalogIndexViewModel
            {
                Organizers = await _service.GetOrganizersAsync(),
                Types = await _service.GetTypesAsync(),
                Events = events.Data,
                PaginationInfo = new PaginationInfo
                {
                    TotalEvents = events.Count,
                    ItemsPerPage = events.PageSize,
                    ActualPage = page ?? 0,
                    TotalPages = (int)Math.Ceiling((decimal)events.Count / itemsOnPage)
                },
                OrganizerFilterApplied = organizerFilterApplied ?? 0,
                TypesFilterApplied = typeFilterApplied ?? 0


            };
            return View(vm);
        }
    }
}

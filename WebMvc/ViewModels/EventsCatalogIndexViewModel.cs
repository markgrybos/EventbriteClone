using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class EventsCatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Organizers { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? OrganizerFilterApplied { get; set; }
        public int? TypesFilterApplied { get; set; }

    }
}

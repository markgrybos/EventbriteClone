using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public string PictureUrl { get; set; }
        public string Tags { get; set; }
        public string Address { get; set; }
        public int EventTypeId { get; set; }
        public int EventOrganizerId { get; set; }
        public string EventType { get; set; }
        public string EventOrganizer { get; set; }
    }
}

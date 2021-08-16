using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class EventsCatalog
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public long Count { get; set; }
        public IEnumerable<Event> Data { get; set; }

    }
}

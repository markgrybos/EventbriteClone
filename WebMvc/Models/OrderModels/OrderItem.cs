using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models.OrderModels
{
    public class OrderItem
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public decimal EventPrice { get; set; }


        public int Tickets { get; set; }

        public string PictureUrl { get; set; }

    }
}
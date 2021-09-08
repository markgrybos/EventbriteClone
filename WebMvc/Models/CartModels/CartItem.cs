using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models.CartModels
{
    public class CartItem
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventURL { get; set; }
        public decimal EventPrice { get; set; }
        public decimal NewUnitPrice { get; set; }
        public int Tickets { get; set; }

    }
}
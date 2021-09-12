using OrderApi.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string EventName { get; set; }
        public string PictureUrl { get; set; }
        public decimal EventPrice { get; set; }

        public int Tickets { get; set; }
        public int EventId { get; private set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }

        public OrderItem(int eventId, string eventName, decimal eventPrice, string pictureUrl, int tickets = 1)
        {
            if (tickets <= 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }

            EventId = eventId;

            EventName = eventName;
            EventPrice = eventPrice;

            Tickets = tickets;
            PictureUrl = pictureUrl;
        }

        public void SetPictureUri(string pictureUri)
        {
            if (!String.IsNullOrWhiteSpace(pictureUri))
            {
                PictureUrl = pictureUri;
            }
        }

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new OrderingDomainException("Invalid units");
            }

            Tickets += units;
        }
    }
}
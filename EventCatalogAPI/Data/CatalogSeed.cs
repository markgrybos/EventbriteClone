using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext catalogContext)
        {
            catalogContext.Database.Migrate();
            if(!catalogContext.EventTypes.Any())
            {
                catalogContext.EventTypes.AddRange(GetEventTypes());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.EventOrganizers.Any())
            {
                catalogContext.EventOrganizers.AddRange(GetEventOrganizers());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.Events.Any())
            {
                catalogContext.Events.AddRange(GetEvents());
                catalogContext.SaveChanges();
            }

        }

        private static IEnumerable<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event
                {
                    Name="Saturday Work Party in Volunteer Park",Description="clean up the garden beds in Seattle’s Volunteer Park ",
                    Price=0,Location="Redmond",Venue="Volunteer Park",Date=DateTime.Parse("10/1/2021 11:30:00AM"),
                    PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/1",
                    Tags="",EventOrganizerId=1,EventTypeId=1

                },
                new Event
                {
                    Name="Summer Nights Party Cruise",Description="4 hour party cruise aboard",Price=100,Location="Seattle",
                     Venue="Emerald City Party Boats",Date=DateTime.Parse("11/3/2021 05:30:00PM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/2",Tags="",EventOrganizerId=2,EventTypeId=2

                },
                new Event
                {
                    Name="Seafair Booze Cruise 2021",Description="DJ and Bar",Price=125,Location="Seattle",
                     Venue="Emerald City Party Boats",Date=DateTime.Parse("09/15/2021 05:30:00PM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/3",Tags="",EventOrganizerId=2,EventTypeId=2

                },
                new Event
                {
                    Name="Seavey Vineyard Wine Tasting and Food Pairing Event",Description="wine tasting and food pairing from Seavey Vineyard at the beautiful Farm and Barn at Holly Farms in Bothell.",Price=30,Location="Bothell",
                     Venue="The Barn at Holly Farm",Date=DateTime.Parse("10/15/2021 04:00:00PM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/4",Tags="",EventOrganizerId=3,EventTypeId=3

                },
            };
        }

        private static IEnumerable<EventOrganizer> GetEventOrganizers()
        {
            return new List<EventOrganizer>
            {
                new EventOrganizer
                {
                    Organizer="Volunteer Park Trust"
                },
                new EventOrganizer
                {
                    Organizer="GetSketched Entertainment"
                },
                new EventOrganizer
                {
                    Organizer="CocuSocial"
                },
                new EventOrganizer
                {
                    Organizer="YogaUncorked"
                },
                new EventOrganizer
                {
                    Organizer="Trinity NightClub"
                },
                new EventOrganizer
                {
                    Organizer="PeacePalaton"
                },
                 new EventOrganizer
                {
                    Organizer="Tech Career Fair"
                },

            }; 
        }

        private static IEnumerable<EventType> GetEventTypes()
        {

            return new List<EventType>
            {
                new EventType
                {
                    Type="Charity&Causes"
                },
                new EventType
                {
                    Type="Music"
                },
                 new EventType
                {
                    Type="Food&Drink"
                },
                  new EventType
                {
                    Type="Online"
                },

};
        }
    }
}

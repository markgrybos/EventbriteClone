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
                    Tags="Volunteer",EventOrganizerId=1,EventTypeId=1

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
                new Event
                {
                    Name="Yoga+Wine",Description="Hatha yoga followed by complimentary wine tasting",Price=25,Location="Woodinville",
                     Venue="Gard Vintners Woodinville Wine Tasting Room",Date=DateTime.Parse("10/20/2021 11:00:00AM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/5",Tags="",EventOrganizerId=4,EventTypeId=3

                },
                 new Event
                {
                    Name="In-Person Class: Hand-Rolled Sushi",Description="Learn our Chef Instructor’s special recipe for Hand Rolled Sushi",Price=50,
                     Location="Seattle",
                     Venue="The Bistro @ SpringHill Suites Seattle Downtown",Date=DateTime.Parse("11/20/2021 11:00:00AM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/6",Tags="",EventOrganizerId=3,EventTypeId=3

                },
                  new Event
                {
                    Name="MassiveFridays",Description="3 Rooms of music with 2 dancefloors",Price=15,Location="Seattle",
                     Venue="Trinity",Date=DateTime.Parse("10/25/2021 4:00:00PM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/7",Tags="",EventOrganizerId=5,EventTypeId=2

                },
                  new Event
                {
                    Name="Reload Saturdays",Description="High-energy main room mix of EDM + Dance Music360-degree LED walls - World-Class Sound System",
                      Price=20,Location="Seattle",
                     Venue="Trinity",Date=DateTime.Parse("10/26/2021 4:00:00PM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/8",Tags="",EventOrganizerId=5,EventTypeId=2

                },
                  new Event
                {
                    Name="Vegan For Beginners",Description="Basics for Vegan Beginners",
                      Price=3,Location="Online",
                     Venue="Online",Date=DateTime.Parse("09/05/2021 11:00:00AM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/9",Tags="",EventOrganizerId=3,EventTypeId=4

                },
                  new Event
                {
                    Name="Tech Career Fair-Bellevue",Description="We will be hosting a Tech Career Fair with our hiring partners from fast growing startups and Fortune 500 companies in technology. ",
                      Price=0,Location="Bellevue",
                     Venue="Bellevue Community Center",Date=DateTime.Parse("11/10/2021 10:00:00AM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/10",Tags="",EventOrganizerId=7,EventTypeId=1

                },
                  new Event
                {
                    Name="Gentle Yoga",Description="Yoga for beginners",
                      Price=20,Location="Online",
                     Venue="Online",Date=DateTime.Parse("09/09/2021 10:00:00AM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/11",Tags="",EventOrganizerId=4,EventTypeId=4

                },
                  new Event
                {
                    Name="Unity Workshop",Description="An afternoon of Fun and Fellowship for the entire family. ",
                      Price=0,Location="Seattle",
                     Venue="Unity Church of God In Christ",Date=DateTime.Parse("10/01/2021 10:00:00AM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/12",Tags="",EventOrganizerId=1,EventTypeId=1

                },

                  new Event
                {
                    Name="Peace Palaton",Description="Peace Peloton’s Monthly Markets are a safe, fun, and easy way for shoppers and entrepreneurs ",
                      Price=0,Location="Seattle",
                     Venue="Columbia City,37th between Hudson and S Ferdinand",Date=DateTime.Parse("10/01/2021 10:00:00AM"),
                     PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/13",Tags="",EventOrganizerId=6,EventTypeId=1

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

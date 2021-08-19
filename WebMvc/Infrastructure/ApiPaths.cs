﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public static class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}EventTypes";
            }
            public static string GetAllOrganizers(string baseUri)
            {
                return $"{baseUri}EventOrganizers";
            }
            public static string GetAllCatalogItems(string baseUri, int page, int take, int? organizer, int? type)
            {
                if (organizer.HasValue && type.HasValue)
                {
                    return $"{baseUri}events/filtered?EventOraganizerId={organizer}&EventTypeId={type}&pageIndex={page}&pageSize={take}";
                }
                else if (type.HasValue)
                {
                    return $"{baseUri}events/filtered?EventTypeId={type}&pageIndex={page}&pageSize={take}";
                }
                else if (organizer.HasValue)
                {
                    return $"{baseUri}events/filtered?EventOraganizerId={organizer}&pageIndex={page}&pageSize={take}";
                }
                return $"{baseUri}events?pageIndex={page}&pageSize={take}";

                
            }     
        }
    }
}

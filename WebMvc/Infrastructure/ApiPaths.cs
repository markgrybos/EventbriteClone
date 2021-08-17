using System;
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
            public static string GetAllCatalogItems(string baseUri, int page, int take, int? Organizer, int? type)
            {
                var filterQs = string.Empty;
                if (Organizer.HasValue || type.HasValue)
                {
                    var OrganizerQs = (Organizer.HasValue) ? Organizer.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/Organizer/{OrganizerQs}";
                }
                return $"{baseUri}events{filterQs}?pageIndex={page}&pageSize={take}";
            }     
        }
    }
}

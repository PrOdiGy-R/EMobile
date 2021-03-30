using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Routing;

namespace EMobile.Models
{
    public class PagedCollection<T> : Collection<T>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Offset { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Limit { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Size { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Link First { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Link Previous { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Link Next { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Link Last { get; set; }

        public static PagedCollection<T> Create(Link self, T[] items, int size, PagingOptions pagingOptions)
        => new()
        {
            Self = self,
            Value = items,
            Size = size,
            Offset = pagingOptions.Offset,
            Limit = pagingOptions.Limit,
            First = self,
            Next = GetNextLink(self, size, pagingOptions),
            Previous = GetPreviousLink(self, size, pagingOptions),
            Last = GetLastLink(self, size, pagingOptions)
        };

        private static Link GetNextLink(Link self, int size, PagingOptions pagingOptions)
        {
            if (pagingOptions?.Limit == null || pagingOptions?.Offset == null) return null;

            var limit = pagingOptions.Limit.Value;
            var offset = pagingOptions.Offset.Value;

            var nextPage = offset + limit;
            if (nextPage >= size) return null;

            var parameters = new RouteValueDictionary(self.RouteValues)
            {
                ["limit"] = limit,
                ["offset"] = nextPage
            };

            return ToCollection(self.RouteName, parameters);
        }

        private static Link GetLastLink(Link self, int size, PagingOptions pagingOptions)
        {
            if (pagingOptions?.Limit == null) return null;

            var limit = pagingOptions.Limit.Value;

            if (size <= limit) return null;

            var offset = Math.Ceiling((size - (double)limit) / limit) * limit;

            var parameters = new RouteValueDictionary(self.RouteValues)
            {
                ["limit"] = limit,
                ["offset"] = offset
            };
            return ToCollection(self.RouteName, parameters);
        }

        private static Link GetPreviousLink(Link self, int size, PagingOptions pagingOptions)
        {
            if (pagingOptions?.Limit == null || pagingOptions?.Offset == null) return null;

            var limit = pagingOptions.Limit.Value;
            var offset = pagingOptions.Offset.Value;

            if (offset == 0)
            {
                return null;
            }

            if (offset > size)
            {
                return GetLastLink(self, size, pagingOptions);
            }

            var previousPage = Math.Max(offset - limit, 0);

            if (previousPage <= 0)
            {
                return self;
            }

            var parameters = new RouteValueDictionary(self.RouteValues)
            {
                ["limit"] = limit,
                ["offset"] = previousPage
            };

            return ToCollection(self.RouteName, parameters);
        }
    }
}

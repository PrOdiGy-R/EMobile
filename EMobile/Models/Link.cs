using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace EMobile.Models
{
    public class Link
    {
        public const string GetMethod = "GET";

        public static Link To(string routeName, object routeValues = null)
            => new()
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = null
            };

        public static Link ToCollection(string routeName, object routeValues = null)
            => new()
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = new[] { "collection" }
            };

        public string Href { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("rel")]
        public string[] Relations { get; set; }

        [DefaultValue(GetMethod)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Method { get; set; }

        // Stores route name-parameters before being rewritten by LinkRewritingFilter
        [JsonIgnore]
        public string RouteName { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public object RouteValues { get; set; }
    }
}

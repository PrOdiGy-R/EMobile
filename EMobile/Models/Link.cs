using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EMobile.Models
{
    public class Link
    {
        public const string GetMethod = "GET";

        public static Link To(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = null
            };

        [JsonProperty(Order = -4)]
        public string Href { get; set; }

        [JsonProperty(Order = -3, PropertyName = "rel", NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore]
        public string Relations { get; set; }

        [JsonProperty(Order = -2, DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(GetMethod)]
        [System.Text.Json.Serialization.JsonIgnore]
        public string Method { get; set; }

        // Stores route name-parameters before being rewritten by LinkRewritingFilter
        [System.Text.Json.Serialization.JsonIgnore]
        public string RouteName { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public object RouteValues { get; set; }
    }
}

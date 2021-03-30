using EMobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMobile.Models
{
    public class Mobile : Resource
    {
        [Sortable]
        public string Model { get; set; }

        [Sortable]
        public string Brand { get; set; }

        [Sortable]
        public string Size { get; set; }

        [Sortable]
        public string Weight { get; set; }

        [Sortable]
        public string Resolution { get; set; }

        [Sortable]
        public string Processor { get; set; }

        [Sortable]
        public string OperatingSystem { get; set; }

        [Sortable(Default = true)]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public string VideoPath { get; set; }
    }
}

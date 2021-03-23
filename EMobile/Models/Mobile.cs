using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMobile.Models
{
    public class Mobile : Resource
    {
        public string Model { get; set; }
        
        public string Brand { get; set; }

        public string Size { get; set; }

        public string Weight { get; set; }

        public string Resolution { get; set; }

        public string Processor { get; set; }

        public string OperatingSystem { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public string VideoPath { get; set; }
    }
}

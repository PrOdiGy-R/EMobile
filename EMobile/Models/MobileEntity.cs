using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMobile.Models
{
    public class MobileEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Brand { get; set; }

        public string Size { get; set; }

        public string Weight { get; set; }

        public string Resolution { get; set; }

        [MaxLength(500)]
        public string Processor { get; set; }

        public string OperatingSystem { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string ImagePath { get; set; }

        [MaxLength(500)]
        public string VideoPath { get; set; }
        
        //Some of the fields can/should be separate tables/entities
    }
}

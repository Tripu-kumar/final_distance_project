using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace distanceproject.Models
{
    public class distance
    {
        [Key]
        public int distance_id { get; set; }
        [Required]
        public DateTime date { get; set; }
        
        [Required]
        public float from_loc_lat { get; set; }
        [Required]
        public float from_loc_lng { get; set; }
        [Required]
        public float to_location_lat { get; set; }

        [Required]
        public float to_location_lng { get; set; }
        [Required]
        public float dist {get;set;}
    }
}

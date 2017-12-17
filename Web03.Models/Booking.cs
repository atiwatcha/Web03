using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web03.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string By { get; set; }

        public Room Room { get; set; }
        public int Attendees { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web03.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public string Name { get; set; }
        public string By { get; set; }

        public Room Room { get; set; }
        public int Attendees { get; set; }
    }
}

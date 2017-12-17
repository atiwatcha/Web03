using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web03.Models
{
    public class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int MaxSeat { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public bool AddBooking(Booking booking) {
            if (booking.From.Date != booking.To.Date)
            {
                throw new Exception("Booking failed ...");
            }

            
            if (IsOverlappedDates(booking))
            {
                throw new Exception("Booking failed ISOverlappedDates...");
            }

            booking.Room = this;
            Bookings.Add(booking);
            return true;
        }


        private bool IsOverlappedDates(Booking other)
        {
            foreach (var b in Bookings)
            {
                var overlapped = (other.From < b.To)
                                 && (b.From < other.To);

                if (overlapped) return true;
            }

            return false;
        }

        public void Cancel(Booking booking)
        {
            Bookings.Remove(booking);
        }



    }
}

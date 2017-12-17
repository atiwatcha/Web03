using System;
using Xunit;

namespace Web03.Models.Facts
{
    public class RoomFact
    {
        public class AddBooking
        {
            [Fact]
            public void BasicUsage()
            {
                var r = new Room
                {
                    Id = 100,
                    MaxSeat = 10,
                    Name = "Room 100"
                };
                var b = new Booking
                {
                    Id = 55,
                    From = DateTime.Now,
                    To = DateTime.Now.AddHours(2.5),
                    Attendees = 10,
                    Name = "Weekly Meetup",
                    By = "Someone"
                };

                var success = r.AddBooking(b);

                Assert.True(success);
                Assert.Equal(1, r.Bookings.Count);
                Assert.Same(r, b.Room);

            }
        }

        [Fact]
        public void BookingOnDifferentDateIsNotAllowed()
        {
            var r = new Room
            {
                Id = 100,
                MaxSeat = 10,
                Name = "Room 100"
            };
            var dt1 = DateTime.Now;
            var dt2 = dt1.AddDays(1);
            var b = new Booking
            {
                Id = 55,
                From = dt1,
                To = dt2,
                Attendees = 10,
                Name = "Weekly Meetup",
                By = "Someone"
            };

            var ex = Assert.Throws<Exception>(() =>
            {

                r.AddBooking(b);

            });

            Assert.Contains("Booking failed",
              ex.Message);
            Assert.Equal(0, r.Bookings.Count);
        }

        [Fact]
        public void BookingCannotBeOverlapped()
        {
            var r = new Room
            {
                Id = 100,
                MaxSeat = 10,
                Name = "Room 100"
            };
            var b1 = new Booking
            {
                Id = 55,
                From = DateTime.Parse("9:00"),
                To = DateTime.Parse("12:00"),
                Attendees = 10,
                Name = "Weekly Meetup",
                By = "Someone"
            };
            var b2 = new Booking
            {
                Id = 56,
                From = DateTime.Parse("11:00"),
                To = DateTime.Parse("15:00"),
                Attendees = 10,
                Name = "Weekly Meetup",
                By = "Another one"
            };

            r.AddBooking(b1);

            var ex = Assert.Throws<Exception>(() => {
                r.AddBooking(b2);
            });

            Assert.Contains("Booking failed",
              ex.Message);
            Assert.Equal(1, r.Bookings.Count);
        }

        [Fact]
        public void TwoConsecutiveBookingsNotOverlapped()
        {
            var r = new Room
            {
                Id = 100,
                MaxSeat = 10,
                Name = "Room 100"
            };
            var b1 = new Booking
            {
                Id = 55,
                From = DateTime.Parse("9:00"),
                To = DateTime.Parse("10:00"),
                Attendees = 10,
                Name = "Weekly Meetup",
                By = "Someone"
            };
            var b2 = new Booking
            {
                Id = 56,
                From = DateTime.Parse("10:00"),
                To = DateTime.Parse("11:00"),
                Attendees = 10,
                Name = "Weekly Meetup",
                By = "Another one"
            };

            r.AddBooking(b1);
            r.AddBooking(b2);

            Assert.Equal(2, r.Bookings.Count);
        }

    }
}

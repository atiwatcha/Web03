using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web03.Models;

namespace Web03.Data
{
    public class RoomDb:DbContext

    {

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public RoomDb(DbContextOptions<RoomDb> options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var cnString = "Server=10.101.23.203;Database=RoomDb_Atiwat;User Id=sa;Password=P@ssw0rd;";
        //    optionsBuilder.UseSqlServer(cnString);
        //    //optionsBuilder.UseInMemoryDatabase(cnString);
        //}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web03.Data;
using Web03.Models;

namespace Web03.Controllers
{
    public class RoomsController : Controller
    {
        public RoomsController(RoomDb roomDb)
        {
            RoomDb = roomDb;
        }

        public RoomDb RoomDb { get; }

        public IActionResult Index()
        {
            var rooms = RoomDb.Rooms.Include(s => s.Bookings).ToList();
            return View(rooms);
        }

        [Route("Rooms/{id}")]
        public IActionResult Details(int id)
        {
            var room = RoomDb.Rooms
                                 .Include(x => x.Bookings)
                                 .SingleOrDefault(x => x.Id == id);

            if (room == null)
            {
                return NotFound(); // 404
            }

            return View(room);
        }

        [HttpGet]
        [Route("AddBooking/{id}")]
        public IActionResult AddBooking(int id)
        {
            ViewBag.RoomId = new SelectList(RoomDb.Rooms, "Id", "Name", id);
            return View();
        }

        [HttpPost]
        [Route("AddBooking/{roomId}")]
        public IActionResult AddBooking(int roomId,
                                Booking item)
            {
            ViewBag.RoomId = new SelectList(RoomDb.Rooms, "Id", "Name", roomId);

            if (!ModelState.IsValid)
            {
                return View(item);
            }

            var room = RoomDb.Rooms.Find(roomId);
            if (room == null)
            {
                return NotFound();
            }

            RoomDb.Entry(room).Collection(s => s.Bookings).Load();
            try
            {
                room.AddBooking(item);
                RoomDb.SaveChanges();

                return RedirectToAction("Details", new { id = roomId });
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View(item);
        }

    }
}
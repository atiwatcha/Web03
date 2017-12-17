using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web03.Data;
using Web03.Models;

namespace Web03.Controllers
{
    public class HomeController : Controller
    {
        public RoomDb RoomDb { get; }
        public HomeController(RoomDb roomDb)
        {
            RoomDb = roomDb;
        }

        public IActionResult Index()
        {
            ViewBag.Count = RoomDb.Rooms.Count();
            return View();
        }

        public IActionResult About()
        {
            int ms = DateTime.Now.Millisecond;
            var r = new Room
            {
                Id = ms,
                Name = $"Room {ms}",
                MaxSeat = 10
            };

            RoomDb.Rooms.Add(r);
            RoomDb.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

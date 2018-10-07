using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using GigHub1.Models;

namespace GigHub1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Gig> upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now)
                .ToList();

            List<int> attendances = new List<int>();

            foreach (Attendance att in _context.Attendances)
            {
                if(att.AttendeeId == User.Identity.GetUserId())
                {
                    attendances.Add(att.GigId);
                }
            }

            ViewBag.Attendances = attendances;

            return View(upcomingGigs);
        }         
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using GigHub1.Models;
using GigHub1.ViewModels;
using System.Globalization;
using GigHub1.Helpers;

namespace GigHub1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            bool filterByAttendance = _context.FilterSettings.Find(1).FilterByAttend;

            List<Gig> upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now)
                .ToList();
         
            List<int> attendances = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.GigId)
                .ToList();
                    
            List<string> follows = _context.Follows
                .Where(f => f.FollowerId == userId)
                .Select(f => f.FollowingId)
                .ToList();
           
            HomeViewModel hvm = new HomeViewModel()
            {
                AppUserId = User.Identity.GetUserId(),
                UpcomingGigs = FiltersEnabler.ApplyFilters(filterByAttendance, upcomingGigs, attendances, userId),
                Atendances = attendances,
                Follows = follows,
                ShowActions = User.Identity.IsAuthenticated,
                Culture = new CultureInfo("en-EN"),
                FiltratedByAttendance = filterByAttendance
        };

            return View(hvm);
        }         
    }
}
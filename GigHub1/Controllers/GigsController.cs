using System.Linq;
using System.Web.Mvc;
using GigHub1.Models;
using GigHub1.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Globalization;
using System.Data.Entity;

namespace GigHub1.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [Authorize]
        public ActionResult Attending()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Gig> gigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Genre)
                .Include(g => g.Artist)
                .ToList();

            List<int> attendances = new List<int>();
            foreach (Attendance att in _context.Attendances)
            {
                if (att.AttendeeId == User.Identity.GetUserId())
                {
                    attendances.Add(att.GigId);
                }
            }

            List<string> follows = new List<string>();
            foreach (Follows fl in _context.Follows)
            {
                if (fl.FollowerId == User.Identity.GetUserId())
                {
                    follows.Add(fl.FollowingId);
                }
            }

            HomeViewModel hvm = new HomeViewModel()
            {
                AppUserId = User.Identity.GetUserId(),
                UpcomingGigs = gigs,
                Atendances = attendances,
                Follows = follows,
                ShowActions = User.Identity.IsAuthenticated,
                Culture = new CultureInfo("en-EN")
            };

            return View(hvm);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View(viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
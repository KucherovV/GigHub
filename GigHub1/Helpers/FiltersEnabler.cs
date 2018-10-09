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

namespace GigHub1.Helpers
{
    public static class FiltersEnabler
    {
        private static readonly ApplicationDbContext _context = new ApplicationDbContext();

        public static List<Gig> ApplyFilters(bool filterByAttending, List<Gig> gigs, List<int> attendances, string userId)
        {
            List<Gig> upcomingGigs = new List<Gig>();
            if (filterByAttending)
            {
                foreach (Gig gig in gigs)
                {
                    if (attendances.Contains(gig.Id))
                    {
                        upcomingGigs.Add(gig);
                    }
                }

              
            }
            else
            {
                upcomingGigs = gigs;
            }

            return upcomingGigs;
        }
    }
}
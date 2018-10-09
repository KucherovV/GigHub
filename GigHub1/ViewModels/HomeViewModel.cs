using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub1.Models;
using System.Globalization;

namespace GigHub1.ViewModels
{
    public class HomeViewModel
    {
        public string AppUserId { get; set; }
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
        public IEnumerable<int> Atendances { get; set; }
        public IEnumerable<string> Follows { get; set; }
        public CultureInfo Culture { get; set; }
        public bool FiltratedByAttendance { get; set; }
    }
}
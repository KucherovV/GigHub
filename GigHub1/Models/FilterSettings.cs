using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub1.Models
{
    public class FilterSettings
    {
        public int Id { get; set; }
        public bool FilterByAttend { get; set; }
        public bool FilterByFollow { get; set; }
    }
}
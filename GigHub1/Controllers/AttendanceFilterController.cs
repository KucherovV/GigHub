
using System.Web.Http;
using GigHub1.Models;
using System.Data.Entity;


namespace GigHub1.Controllers
{
    [Authorize]
    public class AttendanceFilterController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Change()
        {
            FilterSettings fs = _context.FilterSettings.Find(1);

            if(fs.FilterByAttend)
            {
                fs.FilterByAttend = false;
            }
            else
            {
                fs.FilterByAttend = true;
            }

            _context.Entry(fs).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }
    }
}

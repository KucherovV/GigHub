using System.Linq;
using System.Web.Http;
using GigHub1.Models;
using Microsoft.AspNet.Identity;

namespace GigHub1.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Attend([FromBody]int gigId)
        {
            var userId = User.Identity.GetUserId();

            if(_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gigId))
            {
                return BadRequest("Attendance already exists");
            }

            Attendance attendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}

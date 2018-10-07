using System.Linq;
using System.Web.Http;
using GigHub1.Models;
using Microsoft.AspNet.Identity;
using GigHub1.Dtos;
using System.Data.Entity;

namespace GigHub1.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            Attendance attendance;
            var gigId = dto.GigId;

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gigId))
            {
                attendance = new Attendance
                {
                    Attendee = _context.Users.Find(userId),
                    Gig = _context.Gigs.Find(gigId),
                    AttendeeId = userId,
                    GigId = gigId
                };

                _context.Entry(attendance).State = EntityState.Deleted;            
            }
            else
            {
                attendance = new Attendance
                {
                    GigId = dto.GigId,
                    AttendeeId = userId
                };

                _context.Attendances.Add(attendance);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}

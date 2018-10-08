using System.Linq;
using System.Web.Http;
using GigHub1.Models;
using Microsoft.AspNet.Identity;
using GigHub1.Dtos;
using System.Data.Entity;

namespace GigHub1.Controllers
{
    [Authorize]
    public class FollowsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IHttpActionResult Follow(FollowsDto dto)
        {
            var followerId = User.Identity.GetUserId();
            var followingId = dto.FollowingId;
            Follows follows;

            if (_context.Follows.Any(f => f.FollowerId == followerId
                && f.FollowingId == followingId))
            {
                follows = new Follows
                {
                    FollowerId = followerId,
                    FollowingId = followingId                  
                };

                _context.Entry(follows).State = EntityState.Deleted;
            }
            else
            {
                follows = new Follows
                {
                    FollowerId = followerId,
                    FollowingId = followingId
                };

                _context.Follows.Add(follows);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}

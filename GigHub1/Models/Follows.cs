using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub1.Models
{
    public class Follows
    {
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Following { get; set; }

        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FollowingId { get; set; }
    }
}
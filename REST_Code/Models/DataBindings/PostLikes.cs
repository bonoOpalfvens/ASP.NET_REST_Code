using System;
using System.ComponentModel.DataAnnotations;

namespace REST_Code.Models.DataBindings
{
    public class PostLikes
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public Post Post { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime DateLiked { get; set; }
    }
}

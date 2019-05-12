using System;
using System.ComponentModel.DataAnnotations;

namespace REST_Code.Models.DataBindings
{
    public class CommentLikes
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public Comment Comment { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime DateLiked { get; set; }
    }
}

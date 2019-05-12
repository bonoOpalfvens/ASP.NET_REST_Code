using REST_Code.Models.DataBindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace REST_Code.Models
{
    public class Comment
    {
        #region Properties
        [Key]
        public long Id { get; set; }
        [Required]
        public Post Post { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [MaxLength(250)]
        public string Content { get; set; }
        public ICollection<CommentLikes> Likes { get; set; }
        #endregion

        #region Constructors
        public Comment()
        {
            Likes = new List<CommentLikes>();
        }
        #endregion
    }
}

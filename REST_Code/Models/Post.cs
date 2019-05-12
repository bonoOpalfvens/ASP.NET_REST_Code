using REST_Code.Models.DataBindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_Code.Models
{
    public class Post
    {
        #region Properties
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String Title { get; set; }
        [Required]
        [MaxLength(10000)]
        public String Content { get; set; }
        [Required]
        public Board Board { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostLikes> Likes { get; set; }
        #endregion

        #region Constructors
        public Post()
        {
            DateAdded = DateTime.Now;
            Comments = new List<Comment>();
            Likes = new List<PostLikes>();
        }
        #endregion
    }
}

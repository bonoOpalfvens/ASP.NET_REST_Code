using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace REST_Code.DTOs
{
    public class PostDTO
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String Title { get; set; }
        [Required]
        public long BoardId { get; set; }
        [Required]
        [Url]
        public String BoardIcon { get; set; }
        [Required]
        public String BoardName { get; set; }
        [Required]
        [MaxLength(20)]
        public String User { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public ICollection<String> Comments { get; set; }
        [Required]
        public ICollection<String> Likes { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_Code.Models
{
    public class Post
    {
        #region Properties
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String Title { get; set; }
        [Required]
        public Board Board { get; set; }
        [Required]
        [MaxLength(20)]
        public String User { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [NotMapped]
        public ICollection<String> Comments { get; set; }
        [NotMapped]
        public ICollection<String> Likes { get; set; }
        #endregion

        #region Constructors
        public Post()
        {
            DateAdded = DateTime.Now;
            Comments = new List<String>();
            Likes = new List<String>();
        }
        #endregion

        #region Methods
        #endregion
    }
}

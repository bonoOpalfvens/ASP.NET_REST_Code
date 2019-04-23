﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace REST_Code.Models
{
    public class Post
    {
        #region Properties
        public long Id { get; set; }
        [Required]
        public String Title { get; set; }
        public Board Board { get; set; }
        public String User { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<String> Comments { get; set; }
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
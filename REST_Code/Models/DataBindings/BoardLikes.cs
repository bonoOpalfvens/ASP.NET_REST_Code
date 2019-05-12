using System;
using System.ComponentModel.DataAnnotations;

namespace REST_Code.Models.DataBindings
{
    public class BoardLikes
    {
        public long Id { get; set; }
        public Board Board { get; set; }
        public User User { get; set; }
        public DateTime DateLiked { get; set; }
    }
}

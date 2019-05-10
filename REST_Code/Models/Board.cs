using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace REST_Code.Models
{
    public class Board
    {
        #region Properties
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        [Url]
        [MaxLength(200)]
        public String Icon { get; set; }
        public ICollection<Post> Posts { get; set; }
        #endregion

        #region Constructors
        public Board()
        {
            Posts = new List<Post>();
        }
        #endregion
    }
}

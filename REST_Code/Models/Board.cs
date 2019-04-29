using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace REST_Code.Models
{
    public class Board
    {
        #region Properties
        public long Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
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

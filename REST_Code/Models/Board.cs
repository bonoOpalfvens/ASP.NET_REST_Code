using REST_Code.Models.DataBindings;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace REST_Code.Models
{
    public class Board
    {
        #region Properties
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(30)]
        [RegularExpression("^[A-Za-z0-9_-]+$", ErrorMessage = "Boardnames can only contain the following characters: upper case (A-Z), lower case (a-z), number (0-9), underscores and hyphens")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public Icon Icon { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<BoardLikes> Likes { get; set; }
        #endregion

        #region Constructors
        public Board()
        {
            Posts = new List<Post>();
            Likes = new List<BoardLikes>();
        }
        #endregion
    }
}

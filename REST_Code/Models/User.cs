using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace REST_Code.Models
{
    public class User
    {
        #region Fields
        private string _displayName;
        #endregion

        #region Properties
        public long Id { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9_-]+$", ErrorMessage = "Usernames can only contain the following characters: upper case (A-Z), lower case (a-z), number (0-9), underscores and hyphens")]
        public String Username { get; set; }
        public String DisplayName {
            get {
                if (String.IsNullOrWhiteSpace(_displayName))
                    return Username;
                else
                    return _displayName;
            }
            set { _displayName = value; }
        }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        public bool EmailIsPrivate { get; set; }
        public String Avatar { get; set; }
        public String Description { get; set; }
        [Url]
        public String Github { get; set; }
        public ICollection<Board> Boards { get; set; }
        public ICollection<Post> LikedPosts { get; set; }
        public ICollection<Post> CreatedPosts { get; set; }
        #endregion

        #region Constructors
        public User()
        {
            EmailIsPrivate = false;
            Boards = new List<Board>();
            LikedPosts = new List<Post>();
            CreatedPosts = new List<Post>();
        }
        #endregion
    }
}

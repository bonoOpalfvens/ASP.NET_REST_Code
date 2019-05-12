using REST_Code.Models.DataBindings;
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
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(30)]
        [RegularExpression("^[A-Za-z0-9_-]+$", ErrorMessage = "Usernames can only contain the following characters: upper case (A-Z), lower case (a-z), number (0-9), underscores and hyphens")]
        public String Username { get; set; }
        [MaxLength(20)]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "Invalid format for displayname")]
        public String DisplayName {
            get {
                if (String.IsNullOrWhiteSpace(_displayName))
                    return Username;
                else
                    return _displayName;
            }
            set { _displayName = value; }
        }
        [MaxLength(40)]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "Invalid format for first name")]
        public String FirstName { get; set; }
        [MaxLength(40)]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "Invalid format for last name")]
        public String LastName { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        public bool EmailIsPrivate { get; set; }
        [Required]
        public Icon Avatar { get; set; }
        [MaxLength(250)]
        public String Description { get; set; }
        [Url]
        [RegularExpression("^https://github.com/[-a-zA-Z0-9@:%._\\+~#=]+$", ErrorMessage = "The link you entered is not a valid Github profile link (eg.: https://github.com/bonoOpalfvens)")]
        public String Github { get; set; }
        public ICollection<BoardLikes> Boards { get; set; }
        public ICollection<PostLikes> LikedPosts { get; set; }
        public ICollection<CommentLikes> LikedComments { get; set; }
        public ICollection<Post> CreatedPosts { get; set; }
        public ICollection<Comment> CreatedComments { get; set; }
        #endregion

        #region Constructors
        public User()
        {
            EmailIsPrivate = false;
            Boards = new List<BoardLikes>();
            LikedPosts = new List<PostLikes>();
            LikedComments = new List<CommentLikes>();
            CreatedPosts = new List<Post>();
            CreatedComments = new List<Comment>();
        }
        #endregion
    }
}

using REST_Code.Models;
using System.Collections.Generic;

namespace REST_Code.DTOs.Models
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public bool EmailIsPrivate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Github { get; set; }
        public ICollection<string> AvailableAvatars { get; set; }
        public ICollection<BoardDTO> Boards { get; set; }
        public ICollection<PostDTO> LikedPosts { get; set; }
        public ICollection<PostDTO> CreatedPosts { get; set; }

        public static UserDTO FromUser(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.Username,
                DisplayName = user.DisplayName,
                Avatar = user.Avatar.Url,
                Email = (user.EmailIsPrivate ? null : user.Email),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Description = user.Description,
                Github = user.Github
            };
        }
    }
}

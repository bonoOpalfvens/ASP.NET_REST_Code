using REST_Code.Models;
using System;

namespace REST_Code.DTOs.Models
{
    public class CommentDTO
    {
        public long Id { get; set; }
        public PostDTO Post { get; set; }
        public UserDTO User { get; set; }
        public DateTime DateAdded { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public bool IsLiking { get; set; }

        public static CommentDTO FromComment(Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                User = UserDTO.FromUser(comment.User),
                DateAdded = comment.DateAdded,
                Content = comment.Content,
                Likes = comment.Likes.Count
            };
        }
    }
}

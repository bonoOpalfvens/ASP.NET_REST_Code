using System;
using System.Collections.Generic;

namespace REST_Code.DTOs.Models
{
    public class PostDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public BoardDTO Board { get; set; }
        public UserDTO User { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
        public int noComments { get; set; }
        public int Likes { get; set; }
        public bool IsLiking { get; set; }

        public static PostDTO FromPost(REST_Code.Models.Post post)
        {
            return new PostDTO
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                DateAdded = post.DateAdded,
                User = UserDTO.FromUser(post.User),
                noComments = post.Comments.Count,
                Likes = post.Likes.Count
            };
        }
    }
}
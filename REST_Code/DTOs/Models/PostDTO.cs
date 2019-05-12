using REST_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST_Code.DTOs.Models
{
    public class PostDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public BoardDTO Board { get; set; }
        public UserDTO User { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
        public int Likes { get; set; }
        public bool IsLiking { get; set; }

        public static PostDTO FromPost(Post post)
        {
            return new PostDTO
            {
                Id = post.Board.Id,
                Title = post.Title,
                DateAdded = post.DateAdded,
                Board = BoardDTO.FromBoard(post.Board),
                User = UserDTO.FromUser(post.User),
                Comments = post.Comments.Select(CommentDTO.FromComment),
                Likes = post.Likes.Count
            };
        }
        public static PostDTO FromPostMin(Post post)
        {
            return new PostDTO
            {
                Id = post.Board.Id,
                Title = post.Title,
                DateAdded = post.DateAdded,
                User = UserDTO.FromUser(post.User),
                Comments = post.Comments.Select(CommentDTO.FromComment),
                Likes = post.Likes.Count
            };
        }
    }
}
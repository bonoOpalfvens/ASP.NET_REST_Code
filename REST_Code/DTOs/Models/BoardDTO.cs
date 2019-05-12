using REST_Code.Models;
using System.Collections.Generic;

namespace REST_Code.DTOs.Models
{
    public class BoardDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public ICollection<PostDTO> Posts { get; set; }
        public int Likes { get; set; }
        public bool IsLiking { get; set; }


        public static BoardDTO FromBoard(Board board)
        {
            return new BoardDTO
            {
                Id = board.Id,
                Name = board.Name,
                Description = board.Description,
                Icon = board.Icon.Url,
                Likes = board.Likes.Count
            };
        }
    }
}

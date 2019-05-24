using System.ComponentModel.DataAnnotations;

namespace REST_Code.DTOs.Post
{
    public class CreateDTO
    {
        [Required]
        public long BoardId { get; set; }
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MinLength(30), MaxLength(10000)]
        public string Content { get; set; }
    }
}

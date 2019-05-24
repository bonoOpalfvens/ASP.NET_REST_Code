using System.ComponentModel.DataAnnotations;

namespace REST_Code.DTOs.Comment
{
    public class CreateDTO
    {
        [Required]
        public long PostId { get; set; }
        [Required]
        [MinLength(2), MaxLength(250)]
        public string Content { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace REST_Code.Models
{
    public class Icon
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
    }
}

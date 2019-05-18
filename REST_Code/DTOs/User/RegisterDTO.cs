using System.ComponentModel.DataAnnotations;

namespace REST_Code.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [RegularExpression("^[A-Za-z0-9_-]+$", ErrorMessage = "Usernames can only contain the following characters: upper case (A-Z), lower case (a-z), number (0-9), underscores and hyphens")]
        public string UserName { get; set; }
    }
}

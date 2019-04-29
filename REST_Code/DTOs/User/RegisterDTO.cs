﻿using System.ComponentModel.DataAnnotations;

namespace REST_Code.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [RegularExpression("^[A-Za-z0-9_-]+$", ErrorMessage = "Usernames can only contain the following characters: upper case (A-Z), lower case (a-z), number (0-9), underscores and hyphens")]
        public string UserName { get; set; }

        [Required]
        [Compare("Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at least 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string PasswordConfirmation { get; set; }
    }
}

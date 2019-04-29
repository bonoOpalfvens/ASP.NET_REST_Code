using System.ComponentModel.DataAnnotations;

namespace REST_Code.DTOs.User
{
    public class EditDTO
    {
        [Required]
        public long Id { get; set; }
        [MaxLength(50)]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "Invalid format for first name")]
        public string DisplayName { get; set; }
        [MaxLength(50)]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "Invalid format for first name")]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "Invalid format for last name")]
        public string LastName { get; set; }
        public string Description { get; set; }
        [Url]
        [RegularExpression("^https://github.com/[-a-zA-Z0-9@:%._\\+~#=]+$", ErrorMessage = "The link you entered is not a valid Github profile link (eg.: https://github.com/bonoOpalfvens)")]
        public string Github { get; set; }
        public bool EmailIsPrivate { get; set; }
    }
}

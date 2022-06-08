using System.ComponentModel.DataAnnotations;

namespace SchokoCinema.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Gelieve uw voornaam in te vullen")]
        [Display(Name = "Voornaam")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Gelieve uw achternaam in te vullen")]
        [Display(Name = "Achternaam")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Gelieve uw E-mail in te vullen")]
        [EmailAddress(ErrorMessage = "Geen geldig email adres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bericht achterlaten is verplicht")]
        public string Description { get; set; }
    }
}

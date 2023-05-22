using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ContactAppModels.Validation;

namespace ContactAppModels
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name field must be provided")]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = ("Last name field must be provided"))]
        [MinLength(3)]
        public string LastName { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        [EmailValidator(AllowedDomain = "gmail.com", ErrorMessage = "Unacceptable domain name")]
        public string Email { get; set; }
        [Phone]
        public string Phonenumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Occupation { get; set; }
        public string PhotoPath { get; set; }
    }
}
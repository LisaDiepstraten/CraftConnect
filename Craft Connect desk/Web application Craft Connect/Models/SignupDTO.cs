using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationCraftConnect.Models
{
    public class SignupDTO
    {

        [Required]
        public string Username { get; set; }
        [Required]
        public string Firstname {  get; set; }
        [Required] 
        public string Lastname { get; set; }
        [Required] 
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }


    }
}

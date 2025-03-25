using System.ComponentModel.DataAnnotations;

namespace WebApplicationCraftConnect.Models
{
    public class UserCredentials
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
       
        
        public UserCredentials() 
        {

        }
    }
}

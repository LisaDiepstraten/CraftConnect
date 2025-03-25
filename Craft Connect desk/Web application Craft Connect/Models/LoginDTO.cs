using System.ComponentModel.DataAnnotations;

namespace WebApplicationCraftConnect.Models
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }

    
    }
}

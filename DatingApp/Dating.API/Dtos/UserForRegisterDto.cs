using System.ComponentModel.DataAnnotations;

namespace Dating.API.Dtos
{
    public class UserForRegisterDto
    {
       [Required]
       public string Username { get; set; }   
      
      [Required]
      [StringLength(8, MinimumLength = 4, ErrorMessage="you must specify password between 4 and 8 charecters")]
       public string Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Adapters.ApplicationServices.Dtos
{

    public class CreateUserDto
    {

        [Required]
        public string username { get; set; }

        [Required, EmailAddress]
        public string email { get; set; }
        [Required, MinLength(7), MaxLength(15)]
        public string password { get; set; }

        public CreateUserDto(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }



    }
}
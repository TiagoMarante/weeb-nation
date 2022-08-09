using System.ComponentModel.DataAnnotations;

namespace Adapters.ApplicationServices.Dtos
{

    public class CrudUserDto
    {

        [Required]
        public string username { get; }

        [Required, EmailAddress]
        public string email { get; }
        [Required, MinLength(7), MaxLength(15)]
        public string password { get; }

        public CrudUserDto(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }



    }
}
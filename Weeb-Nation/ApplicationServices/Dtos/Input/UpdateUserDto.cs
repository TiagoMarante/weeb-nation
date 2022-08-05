using System.ComponentModel.DataAnnotations;

namespace Adapters.ApplicationServices.Dtos
{

    public class UpdateUserDto
    {

        public string username { get; set; }

        [EmailAddress]
        public string email { get; set; }
        [MinLength(7), MaxLength(15)]
        public string password { get; set; }

        public UpdateUserDto(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }



    }
}
using Entities;

namespace Adapters.ApplicationServices.Dtos
{

    public class UserDto
    {
        public Guid id { get; init; }
        public string username { get; }
        public string email { get; }


        public UserDto(Guid id, string username, string email)
        {
            this.id = id;
            this.username = username;
            this.email = email;
        }

    }
}
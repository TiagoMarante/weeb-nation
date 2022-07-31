using Entities;

namespace Weeb_Nation.Controllers;


public class InMemUsersRepository
{

    private readonly List<User> users = new(){
        new User {Id = Guid.NewGuid(), Username="Tiago Marante", Email="tiago@gmail.com", Password="boas", created=DateTime.UtcNow},
        new User {Id = Guid.NewGuid(), Username="Rui Angola", Email="rui@gmail.com", Password="boas2" , created=DateTime.UtcNow},
        new User {Id = Guid.NewGuid(), Username="Miguel Sousa", Email="tiago@gmail.com", Password="boas3", created=DateTime.UtcNow}
    };

    public IEnumerable<User> GetAll()
    {
        return users;
    }

    public User GetById(Guid Id)
    {
        return users.Where(user => user.Id == Id).SingleOrDefault();
    }

}
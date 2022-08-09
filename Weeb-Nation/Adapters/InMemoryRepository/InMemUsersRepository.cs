using Entities;

namespace Weeb_Nation.Adapters;


public class InMemUsersRepository : IRepository<User>
{

    private readonly List<User> users = new()
    {
        // new User {Id = Guid.NewGuid(), Username="Tiago Marante", Email="tiago@gmail.com", Password="boas", created=DateTime.UtcNow},
        // new User {Id = Guid.NewGuid(), Username="Rui Angola", Email="rui@gmail.com", Password="boas2" , created=DateTime.UtcNow},
        // new User {Id = Guid.NewGuid(), Username="Miguel Sousa", Email="miguel@gmail.com", Password="boas3", created=DateTime.UtcNow}
    };

    public User Add(User obj)
    {

        users.Add(obj);

        if (users.Contains(obj))
        {
            return obj;
        }

        return null;

    }

    public void Delete(User obj)
    {
        users.Remove(obj);

    }

    public User Get(Guid id)
    {
        return users.Where(user => user.Id == id).SingleOrDefault();
    }

    public List<User> GetAll()
    {
        return users;
    }

    public void Update(Guid id, User obj)
    {

        //Update for better solution

        var userDb = Get(id);

        users.Remove(userDb);
        users.Add(obj);

    }

    public List<User> GetByIdsAsync(List<int> ids)
    {
        throw new NotImplementedException();
    }


}
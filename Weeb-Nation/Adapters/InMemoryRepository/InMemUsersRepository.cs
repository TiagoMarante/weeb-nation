using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Weeb_Nation.RepositoryInterfaces;


public class InMemUsersRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{

    private readonly List<TEntity> users = new()
    {
        // new User {Id = Guid.NewGuid(), Username="Tiago Marante", Email="tiago@gmail.com", Password="boas", created=DateTime.UtcNow},
        // new User {Id = Guid.NewGuid(), Username="Rui Angola", Email="rui@gmail.com", Password="boas2" , created=DateTime.UtcNow},
        // new User {Id = Guid.NewGuid(), Username="Miguel Sousa", Email="miguel@gmail.com", Password="boas3", created=DateTime.UtcNow}
    };

    public ActionResult<TEntity> Add(TEntity obj)
    {

        users.Add(obj);

        if (users.Contains(obj))
        {
            return obj;
        }

        return null;

    }

    public void Delete(TEntity obj)
    {
        users.Remove(obj);

    }

    public TEntity Get(Guid id)
    {

        return users.Where(user => user.Id == id).SingleOrDefault();
    }

    public List<TEntity> GetAll()
    {
        return users;
    }

    public void Update(Guid id, TEntity obj)
    {

        //Update for better solution

        var userDb = Get(id);

        users.Remove(userDb);
        users.Add(obj);

    }

}
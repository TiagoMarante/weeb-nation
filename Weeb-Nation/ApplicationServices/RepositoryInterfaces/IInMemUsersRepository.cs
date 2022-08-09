using Entities;

namespace Weeb_Nation.RepositoryInterfaces;

public interface IInMemUsersRepository
{
    IEnumerable<User> GetAll();
    User GetById(Guid Id);
}
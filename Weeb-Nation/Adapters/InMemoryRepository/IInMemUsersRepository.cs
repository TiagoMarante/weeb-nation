using Entities;

namespace Weeb_Nation.Adapters;

public interface IInMemUsersRepository
{
    IEnumerable<User> GetAll();
    User GetById(Guid Id);
}
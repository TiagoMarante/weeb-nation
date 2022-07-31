using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Weeb_Nation.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{

    private readonly InMemUsersRepository repository;

    public UsersController()
    {
        repository = new InMemUsersRepository();
    }

    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        var users = repository.GetAll();
        return users;
    }

}

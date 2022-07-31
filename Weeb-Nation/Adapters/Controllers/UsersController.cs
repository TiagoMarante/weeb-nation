using Entities;
using Microsoft.AspNetCore.Mvc;
using Weeb_Nation.Adapters;

namespace Weeb_Nation.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IInMemUsersRepository repository;

    public UsersController(IInMemUsersRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        var users = repository.GetAll();
        return users;
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(Guid id)
    {
        var users = repository.GetById(id);

        if (users is null)
        {
            return NotFound();
        }

        return Ok(users);
    }

}

using Adapters.ApplicationServices.Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Weeb_Nation.Adapters;

namespace Weeb_Nation.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IRepository<User> repository;

    public UsersController(IRepository<User> repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IEnumerable<UserDto> GetUsers()
    {
        var users = repository.GetAll();

        var usersDto = new List<UserDto>();

        foreach (var user in users)
        {
            usersDto.Add(user.toDto());
        }

        return usersDto;
    }

    [HttpGet("{id}")]
    public ActionResult<UserDto> GetUserById(Guid id)
    {
        var users = repository.Get(id);

        if (users is null)
        {
            return NotFound();
        }

        return Ok(users.toDto());
    }


    [HttpDelete("{id}")]
    public ActionResult<UserDto> DeleteById(Guid id)
    {
        var user = repository.Get(id);

        if (user != null)
        {
            repository.Delete(user);
            return Ok(user.toDto());
        }

        return new NoContentResult();
    }

    [HttpPost]
    public ActionResult<UserDto> AddUser(UserDto user)
    {
        //repository.Add()


        return null;
    }

}

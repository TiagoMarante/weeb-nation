using Adapters.ApplicationServices.Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Weeb_Nation.RepositoryInterfaces;

namespace Weeb_Nation.Controllers;

[ApiController]
[Route("/users")]
public class UsersController : ControllerBase
{
    private readonly IRepository<User> repository;

    public UsersController(IRepository<User> repository)
    {
        this.repository = repository;
    }


    [HttpGet]
    public IEnumerable<UserDto> GetAll()
    {
        return listToDto(repository.GetAll());
    }


    [HttpGet("{id}")]
    public ActionResult<UserDto> GetById(Guid id)
    {
        var users = repository.Get(id);

        if (users == null)
        {
            return NotFound();
        }

        return Ok(users.toDto());
    }


    [HttpDelete("{id}")]
    public ActionResult<UserDto> Delete(Guid id)
    {
        var userDb = repository.Get(id);

        if (userDb != null)
        {
            repository.Delete(userDb);
        }

        return new NoContentResult();
    }


    [HttpPost]
    public ActionResult<UserDto> Add(CrudUserDto user)
    {

        // Passar para a camada serviço

        User newUser = new()
        {
            Id = Guid.NewGuid(),
            Username = user.username,
            Email = user.email,
            Password = user.password
        };

        var createUser = repository.Add(newUser);

        return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser.toDto());
    }


    [HttpPut("{id}")]
    public ActionResult<UserDto> Update(Guid id, CrudUserDto updateUser)
    {
        // Passar para a camada serviço

        var userDb = repository.Get(id);

        if (userDb != null)
        {

            userDb.Username = updateUser.username;
            userDb.Email = updateUser.email;
            userDb.Password = updateUser.password;
            userDb.changed = DateTime.UtcNow;

            repository.Update(userDb.Id, userDb);

        }

        return NoContent();


    }



    private List<UserDto> listToDto(List<User> data)
    {
        var usersDto = new List<UserDto>();

        if (data != null)
        {
            foreach (var elem in data)
            {
                usersDto.Add(elem.toDto());
            }

        }

        return usersDto;
    }

}

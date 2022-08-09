using Adapters.ApplicationServices.Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Weeb_Nation.RepositoryInterfaces;

namespace Weeb_Nation.Controllers;

[ApiController]
[Route("/movies")]
public class MoviesController : ControllerBase
{
    private readonly IRepository<Movie> _repository;

    public MoviesController(IRepository<Movie> repository)
    {
        this._repository = repository;
    }


    [HttpGet]
    public IEnumerable<MovieDto> GetAll()
    {
        return listToDto(_repository.GetAll());
    }


    [HttpGet("{id}")]
    public ActionResult<MovieDto> GetById(Guid id)
    {
        var movie = _repository.Get(id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie.toDto());
    }


    [HttpDelete("{id}")]
    public ActionResult<MovieDto> Delete(Guid id)
    {
        var movieDb = _repository.Get(id);

        if (movieDb != null)
        {
            _repository.Delete(movieDb);
        }

        return new NoContentResult();
    }


    [HttpPost]
    public ActionResult<MovieDto> Add(CrudMovieDto movie)
    {

        // Passar para a camada serviço

        Movie newMovie = new()
        {
            Id = Guid.NewGuid(),
            Name = movie.name,
            Rating = movie.rating,
            Sinopse = movie.sinopse
        };

        var createMovie = _repository.Add(newMovie);

        return CreatedAtAction(nameof(GetById), new { id = newMovie.Id }, newMovie.toDto());
    }


    [HttpPut("{id}")]
    public ActionResult<MovieDto> Update(Guid id, CrudMovieDto updateMovie)
    {
        // Passar para a camada serviço

        var movieDb = _repository.Get(id);

        if (movieDb != null)
        {

            movieDb.Name = updateMovie.name;
            movieDb.Rating = updateMovie.rating;
            movieDb.Sinopse = updateMovie.sinopse;
            movieDb.changed = DateTime.UtcNow;

            _repository.Update(movieDb.Id, movieDb);

        }

        return NoContent();


    }



    private List<MovieDto> listToDto(List<Movie> data)
    {
        var movieDto = new List<MovieDto>();

        if (data != null)
        {
            foreach (var elem in data)
            {
                movieDto.Add(elem.toDto());
            }

        }


        return movieDto;



    }

}

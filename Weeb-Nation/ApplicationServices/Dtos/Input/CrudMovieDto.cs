using System.ComponentModel.DataAnnotations;

namespace Adapters.ApplicationServices.Dtos
{

    public class CrudMovieDto
    {
        [Required]
        public string name { get; }

        [Required]
        [Range(0.0, 10.0)]
        public double rating { get; }

        [Required, MinLength(15), MaxLength(1000)]
        public string sinopse { get; }

        public CrudMovieDto(string name, double rating, string sinopse)
        {
            this.name = name;
            this.rating = rating;
            this.sinopse = sinopse;
        }



    }
}
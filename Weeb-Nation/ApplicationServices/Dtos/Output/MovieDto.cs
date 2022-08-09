namespace Adapters.ApplicationServices.Dtos
{

    public class MovieDto
    {


        public Guid id { get; init; }
        public string name { get; }
        public double rating { get; }
        public string sinopse { get; }


        public MovieDto(Guid id, string name, double rating, string sinopse)
        {
            this.id = id;
            this.name = name;
            this.rating = rating;
            this.sinopse = sinopse;
        }


    }
}
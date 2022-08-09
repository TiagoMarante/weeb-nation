using Adapters.ApplicationServices.Dtos;

namespace Entities
{
    public partial class Movie : Entity
    {
        public Movie()
        {
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
        }

        public string Name { get; set; }
        public double Rating { get; set; }
        public string Sinopse { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Movie movie &&
                   Id.Equals(movie.Id) &&
                   created == movie.created &&
                   changed == movie.changed &&
                   Name == movie.Name &&
                   Rating == movie.Rating &&
                   Sinopse == movie.Sinopse &&
                   EqualityComparer<ICollection<Comment>>.Default.Equals(Comments, movie.Comments) &&
                   EqualityComparer<ICollection<Image>>.Default.Equals(Images, movie.Images);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, created, changed, Name, Rating, Sinopse, Comments, Images);
        }


        public MovieDto toDto()
        {
            return new MovieDto(Id, Name, Rating, Sinopse);
        }
    }
}
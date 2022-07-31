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
    }
}
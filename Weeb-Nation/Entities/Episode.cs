namespace Entities
{
    public partial class Episode : Entity
    {
        public Episode()
        {
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
        }

        public string Name { get; set; }
        public string EpisodeNumber { get; set; }
        public double Rating { get; set; }
        public string Sinopse { get; set; }
        public Guid SerieId { get; set; }

        public virtual Serie Serie { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
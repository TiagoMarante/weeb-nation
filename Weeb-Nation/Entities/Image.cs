namespace Entities
{
    public partial class Image : Entity
    {
        public string ImageUrl { get; set; }
        public Guid SerieId { get; set; }
        public Guid EpisodeId { get; set; }
        public Guid MovieId { get; set; }

        public virtual Episode Episode { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Serie Serie { get; set; }
    }
}
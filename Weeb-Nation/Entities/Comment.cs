namespace Entities
{
    public partial class Comment : Entity
    {
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public Guid EpisodeId { get; set; }
        public Guid MovieId { get; set; }

        public virtual Episode Episode { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
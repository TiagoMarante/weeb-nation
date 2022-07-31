namespace Entities
{
    public partial class Serie : Entity
    {
        public Serie()
        {
            Episodes = new HashSet<Episode>();
            Images = new HashSet<Image>();
        }

        public string Name { get; set; }
        public double Rating { get; set; }
        public string Sinopse { get; set; }
        public Guid UserWatchedSerieId { get; set; }
        public Guid ToWatchSerieId { get; set; }
        public Guid FavoriteSerieId { get; set; }

        public virtual FavoriteSerie FavoriteSerie { get; set; }
        public virtual ToWatchSerie ToWatchSerie { get; set; }
        public virtual UserWatchedSerie UserWatchedSerie { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
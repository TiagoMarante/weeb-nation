using Adapters.ApplicationServices.Dtos;

namespace Entities
{
    public partial class User : Entity
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            FavoriteSeries = new HashSet<FavoriteSerie>();
            ToWatchSeries = new HashSet<ToWatchSerie>();
            UserWatchedSeries = new HashSet<UserWatchedSerie>();
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavoriteSerie> FavoriteSeries { get; set; }
        public virtual ICollection<ToWatchSerie> ToWatchSeries { get; set; }
        public virtual ICollection<UserWatchedSerie> UserWatchedSeries { get; set; }


        public UserDto toDto()
        {
            return new UserDto(Id, Username, Email);
        }
    }




}
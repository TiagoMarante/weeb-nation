using Adapters.ApplicationServices.Dtos;

namespace Entities
{
    public partial class User : Entity
    {
        public User()
        {
            Comments = new List<Guid>();
            FavoriteSeries = new List<Guid>();
            ToWatchSeries = new List<Guid>();
            UserWatchedSeries = new List<Guid>();
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<Guid> Comments { get; set; }
        public virtual List<Guid> FavoriteSeries { get; set; }
        public virtual List<Guid> ToWatchSeries { get; set; }
        public virtual List<Guid> UserWatchedSeries { get; set; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id.Equals(user.Id) &&
                   created == user.created &&
                   changed == user.changed &&
                   Username == user.Username &&
                   Email == user.Email &&
                   Password == user.Password &&
                   EqualityComparer<List<Guid>>.Default.Equals(Comments, user.Comments) &&
                   EqualityComparer<List<Guid>>.Default.Equals(FavoriteSeries, user.FavoriteSeries) &&
                   EqualityComparer<List<Guid>>.Default.Equals(ToWatchSeries, user.ToWatchSeries) &&
                   EqualityComparer<List<Guid>>.Default.Equals(UserWatchedSeries, user.UserWatchedSeries);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(created);
            hash.Add(changed);
            hash.Add(Username);
            hash.Add(Email);
            hash.Add(Password);
            hash.Add(Comments);
            hash.Add(FavoriteSeries);
            hash.Add(ToWatchSeries);
            hash.Add(UserWatchedSeries);
            return hash.ToHashCode();
        }

        public UserDto toDto()
        {
            return new UserDto(Id, Username, Email);
        }


    }




}
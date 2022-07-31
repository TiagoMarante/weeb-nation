using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ToWatchSerie : Entity
    {
        public ToWatchSerie()
        {
            Series = new HashSet<Serie>();
        }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
    }
}

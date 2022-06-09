using System.Collections.Generic;

namespace StationDesktop.Models
{
    public partial class Position
    {
        public Position()
        {
            Users = new HashSet<User>();
        }

        public int Code { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

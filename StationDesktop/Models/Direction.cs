using System.Collections.Generic;

namespace StationDesktop.Models
{
    public partial class Direction
    {
        public Direction()
        {
            Wagons = new HashSet<Wagon>();
        }

        public int Code { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Wagon> Wagons { get; set; }
    }
}

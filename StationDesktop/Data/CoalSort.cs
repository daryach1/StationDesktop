using System.Collections.Generic;

namespace StationDesktop.Data
{
    public partial class CoalSort
    {
        public CoalSort()
        {
            Wagons = new HashSet<Wagon>();
        }

        public int Code { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Wagon> Wagons { get; set; }
    }
}

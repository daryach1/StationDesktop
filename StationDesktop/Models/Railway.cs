using System.Collections.Generic;

namespace StationDesktop.Models
{
    public partial class Railway
    {
        public Railway()
        {
            Wagons = new HashSet<Wagon>();
        }

        public int Code { get; set; }
        public int Number { get; set; }
        public int? Capacity { get; set; }
        public int ParkCode { get; set; }

        public virtual Park ParkCodeNavigation { get; set; } = null!;
        public virtual ICollection<Wagon> Wagons { get; set; }
    }
}

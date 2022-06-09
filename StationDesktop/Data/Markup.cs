using System.Collections.Generic;

namespace StationDesktop.Data
{
    public partial class Markup
    {
        public Markup()
        {
            Wagons = new HashSet<Wagon>();
        }

        public int Code { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortTitle { get; set; }
        public string? Color { get; set; }

        public virtual ICollection<Wagon> Wagons { get; set; }
    }
}

using System.Collections.Generic;

namespace StationDesktop.Models
{
    public partial class Park
    {
        public Park()
        {
            Railways = new HashSet<Railway>();
        }

        public int Code { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Railway> Railways { get; set; }
    }
}

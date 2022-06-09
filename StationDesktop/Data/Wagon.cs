namespace StationDesktop.Data
{
    public partial class Wagon
    {
        public int Code { get; set; }
        public int ShortNumber { get; set; }
        public int? FullNumber { get; set; }
        public int? RailwayCode { get; set; }
        public bool? IsLoading { get; set; }
        public int? MarkupCode { get; set; }
        public int? DirectionCode { get; set; }
        public int? Position { get; set; }
        public int? CoalSortCode { get; set; }
        public bool? IsSelected { get; set; }

        public virtual CoalSort? CoalSortCodeNavigation { get; set; }
        public virtual Direction? DirectionCodeNavigation { get; set; }
        public virtual Markup? MarkupCodeNavigation { get; set; }
        public virtual Railway? RailwayCodeNavigation { get; set; }
    }
}

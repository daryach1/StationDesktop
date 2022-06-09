namespace StationDesktop.Models
{
    public partial class User
    {
        public int Code { get; set; }
        public string? Fullname { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int? PositionCode { get; set; }

        public virtual Position? PositionCodeNavigation { get; set; }
    }
}

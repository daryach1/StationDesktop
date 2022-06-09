using StationDesktop.Pages;
using StationDesktop.Windows;

namespace StationDesktop.Services
{
    public static class BootService
    {
        public static AuthWindow AuthWindow { get; set; }
        public static StationWindow StationWindow { get; set; }

        #region Станция Угольная

        public static SevenCoalRailwayPage SevenCoalRailwayPage;
        public static FiveCoalRailwayPage FiveCoalRailwayPage;
        public static ThreeCoalRailwayPage ThreeCoalRailwayPage;
        public static OneCoalRailwayPage OneCoalRailwayPage;
        public static TwoCoalRailwayPage TwoCoalRailwayPage;
        public static FourCoalRailwayPage FourCoalRailwayPage;

        #endregion
    }
}

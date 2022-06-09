using StationDesktop.Pages;
using StationDesktop.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StationDesktop.Windows
{
    public partial class StationWindow : Window
    {
        public StationWindow()
        {
            InitializeComponent();
            ListBoxService.ListBoxes = new Dictionary<ListBox, int>();
            SetUserInfo();
            SetPages();
        }
        private void SetUserInfo()
        {
            FullNameTextBlock.Text = UserService.User.Fullname;
            PositionTextBlock.Text = UserService.Position;
        }

        private void SetPages()
        {
            BootService.SevenCoalRailwayPage = new SevenCoalRailwayPage();
            BootService.FiveCoalRailwayPage = new FiveCoalRailwayPage();
            BootService.ThreeCoalRailwayPage = new ThreeCoalRailwayPage();
            BootService.OneCoalRailwayPage = new OneCoalRailwayPage();
            BootService.TwoCoalRailwayPage = new TwoCoalRailwayPage();
            BootService.FourCoalRailwayPage = new FourCoalRailwayPage();

            SevenCoal.Navigate(BootService.SevenCoalRailwayPage);
            FiveCoal.Navigate(BootService.FiveCoalRailwayPage);
            ThreeCoal.Navigate(BootService.ThreeCoalRailwayPage);
            OneCoal.Navigate(BootService.OneCoalRailwayPage);
            TwoCoal.Navigate(BootService.TwoCoalRailwayPage);
            FourCoal.Navigate(BootService.FourCoalRailwayPage);
        }
    }
}

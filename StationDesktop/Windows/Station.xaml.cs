using StationDesktop.Data;
using StationDesktop.Pages;
using StationDesktop.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StationDesktop.Windows
{
    public partial class Station : Window
    {
        User user;
        List <Wagon> wagonList;
        public Station(User user)
        {
            InitializeComponent();
            ContextService.StationContext = new StationContext();
            ListBoxService.ListBoxes = new Dictionary<ListBox, int>();
            BootService.stationWindow = this;
            this.user = user;
            SetInfo();
            SetPages();
        }
        private void SetInfo()
        {
            FullNameTextBlock.Text = user.Fullname;
            //PositionTextBlock.Text = user.PositionString;
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

        private void CreateReportButton_Click(object sender, RoutedEventArgs e)
        {
            wagonList = ContextService.StationContext.Wagons.ToList();
            var helper = new WordHelper("Otchet2.doc");

            var items = new Dictionary<string, string>
            {
                {"<all_lo>", wagonList.Where(x=> x.IsLoading==true).Count().ToString()}
            };

            helper.Process(items);

        }
    }
}

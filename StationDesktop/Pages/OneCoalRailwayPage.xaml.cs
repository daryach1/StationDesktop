using StationDesktop.Data;
using StationDesktop.Services;
using StationDesktop.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StationDesktop.Pages
{
    public partial class OneCoalRailwayPage : Page
    {
        List<Wagon> Wagons;
        List<Wagon> SelectedWagons;
        int railway = 4;
        public OneCoalRailwayPage()
        {
            InitializeComponent();
            ListBoxService.ListBoxes.Add(OneCoalListBox, railway);
            OneCoalListBox.Items.Clear();
            Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == railway).ToList();
            foreach (Wagon wagon in Wagons)
            {
                Button newButton = new Button();
                newButton.Height = 30;
                newButton.Width = 50;
                switch (wagon.MarkupCode)
                {
                    case 1:
                        newButton.Background = Brushes.HotPink;
                        break;
                    case 2:
                        newButton.Background = Brushes.LemonChiffon;
                        break;
                    case 3:
                        newButton.Background = Brushes.Blue;
                        break;
                    default:
                        if (wagon.IsLoading == true)
                            newButton.Background = Brushes.LightGreen;
                        else newButton.Background = Brushes.White;
                        break;
                }
                newButton.FontSize = 18;
                newButton.Content = wagon.ShortNumber;
                newButton.Name = "Wagon" + wagon.ShortNumber;
                OneCoalListBox.Items.Add(newButton);
            }
        }
        private void RelocateMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == railway).ToList();
            List<Button> selectedWagons = OneCoalListBox.SelectedItems.Cast<Button>().ToList();
            SelectedWagons = new List<Wagon>();
            foreach (var selWag in selectedWagons)
            {
                int wagonNumber = Convert.ToInt32(selWag.Content);
                var wagon = Wagons.FirstOrDefault(w => w.ShortNumber == wagonNumber);
                SelectedWagons.Add(wagon);
            }

            RelocateWagonsWindow relocateWagons = new RelocateWagonsWindow(SelectedWagons);
            relocateWagons.ShowDialog();
        }
        private void AddMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddWagonClass addWagon = new AddWagonClass(railway, OneCoalListBox);
        }

        private void DeleteMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить данные вагоны безвозвратно?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == railway).ToList();
                List<Button> selectedWagons = OneCoalListBox.SelectedItems.Cast<Button>().ToList();
                SelectedWagons = new List<Wagon>();
                foreach (var selWag in selectedWagons)
                {
                    int wagonNumber = Convert.ToInt32(selWag.Content);
                    var wagon = Wagons.FirstOrDefault(w => w.ShortNumber == wagonNumber);
                    ContextService.StationContext.Wagons.Remove(wagon);
                    ContextService.StationContext.SaveChanges();
                    ListBoxService.UpdateListBoxes();
                }
            }
        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

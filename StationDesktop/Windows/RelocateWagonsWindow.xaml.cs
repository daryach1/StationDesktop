using StationDesktop.Data;
using StationDesktop.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StationDesktop.Windows
{
    public partial class RelocateWagonsWindow : Window
    {
        List<Wagon> Wagons;
        public RelocateWagonsWindow(List<Wagon> selectedWagons)
        {
            InitializeComponent();
            this.Wagons = selectedWagons;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckRadioButton();
                ContextService.StationContext.SaveChanges();
                ListBoxService.UpdateListBoxes();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка переноса: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckRadioButton()
        {
            if (SevenCoalRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 1;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
            if (FiveCoalRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 2;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
            if (ThreeCoalRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 3;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
            if (OneCoalRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 4;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
            if (TwoCoalRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 5;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
            if (FourCoalRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 6;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
            if (OneNewRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 7;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
            if (ThreeNewRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 8;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
            if (FiveNewRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 9;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
            if (SevenNewRailway.IsChecked == true)
            {
                foreach (var wagon in Wagons)
                {
                    wagon.RailwayCode = 10;
                    ContextService.StationContext.Wagons.Update(wagon);
                }
            }
        }
    }
}

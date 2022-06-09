using StationDesktop.Data;
using StationDesktop.Services;
using System;
using System.Linq;
using System.Windows;

namespace StationDesktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddMarkupWindow.xaml
    /// </summary>
    public partial class AddMarkupWindow : Window
    {
        StationContext _stationContext;
        Wagon wagon;
        public AddMarkupWindow(Wagon wagon)
        {
            InitializeComponent();
            this.wagon = wagon; 
            _stationContext = new StationContext();
            MarkupComboBox.ItemsSource = _stationContext.Markups.ToList();
            AddInfo();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateData();
            _stationContext.SaveChanges();
            ListBoxService.UpdateListBoxes();
            this.Close();

        }

        private void AddInfo()
        {
            IsLoadingCheckBox.IsChecked = wagon.IsLoading;
            MarkupComboBox.SelectedIndex =Convert.ToInt32(wagon.MarkupCode)-1;
        }

        private void UpdateData()
        {
            if (IsLoadingCheckBox.IsChecked == true)
                wagon.IsLoading = true;
            else
                wagon.IsLoading = false;
            switch (MarkupComboBox.SelectedIndex)
            {
                case 0:
                    wagon.MarkupCode = 1;
                    break;
                case 1:
                    wagon.MarkupCode = 2;
                    break;
                case 2:
                    wagon.MarkupCode = 3;
                    break;
            }
            _stationContext.Wagons.Update(wagon);
        }
    }
}

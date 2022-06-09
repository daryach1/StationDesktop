using StationDesktop.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StationDesktop.Windows
{
    public partial class AddWagonWindow : Window
    {
        StationContext context;
        ListBox railwayListBox;

        public AddWagonWindow(StationContext context, Wagon wagon, ListBox railwayListBox)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = wagon;
            this.railwayListBox = railwayListBox;
        }

        private void NumberWagonTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void AddWagonButton_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            AddWagonListBox();
            this.Close();
        }

        private void AddWagonListBox()
        {
            Button newButton = new Button();
            newButton.Height = 30;
            newButton.Width = 50;
            newButton.Background = Brushes.White;
            newButton.FontSize = 18;
            newButton.Content = NumberWagonTextBox.Text;
            newButton.Name = "Wagon" + NumberWagonTextBox.Text;
            railwayListBox.Items.Add(newButton);
        }

    }
}

using StationDesktop.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace StationDesktop.Services
{
    public class AddContextClass
    {
        int railway;
        StationContext context;
        ListBox railwayListBox;
        public AddContextClass(int railway, ListBox railwayListBox)
        {
            this.railway = railway;
            context = new StationContext();
            this.railwayListBox = railwayListBox;
            AddContext();
        }

        private void AddContext()
        {
            List<Wagon> listWagon = context.Wagons.ToList();
            listWagon = listWagon.Where(x => x.RailwayCode == railway).ToList();
            foreach (var wagon in listWagon)
            {
                Button newButton = new Button();
                newButton.Height = 30;
                newButton.Width = 50;
                newButton.Background = Brushes.White;
                newButton.FontSize = 18;
                newButton.Content = wagon.ShortNumber;
                newButton.Name = "Wagon" + wagon.ShortNumber;
                railwayListBox.Items.Add(newButton);
            }
        }
    }
}

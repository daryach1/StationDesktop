using StationDesktop.Models;
using StationDesktop.Windows;
using System.Windows.Controls;

namespace StationDesktop.Services
{
    public class AddWagonClass
    {
        StationContext context;
        int railway;
        ListBox railwayListBox;
        public AddWagonClass(int railway, ListBox listBox)
        {
            context = new StationContext();
            this.railway = railway;
            this.railwayListBox = listBox;
            AddWagon();
        }

        private void AddWagon()
        {
            var wagon = new Wagon() { RailwayCode = railway, IsSelected = false };
            context.Wagons.Add(wagon);
            AddWagonWindow addWagon = new AddWagonWindow(context, wagon, railwayListBox);
            addWagon.ShowDialog();
        }
    }
}

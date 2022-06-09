using StationDesktop.Data;
using StationDesktop.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StationDesktop.Services
{
    public class RelocateWagonClass
    {
        StationContext context;
        List<Wagon> wagonList;
        ListBox railwayListBox;
        public RelocateWagonClass(ListBox railwayList)
        {
            this.railwayListBox = railwayList;
            wagonList = new List<Wagon>();
            context = new StationContext();
            RelocateWagon();
        }

        private void RelocateWagon()
        {
            try
            {
                wagonList.Clear();
                List<Button> listButton = railwayListBox.SelectedItems.Cast<Button>().ToList();
                foreach (var button in listButton)
                {
                    List<Wagon> currentWagon = context.Wagons.ToList();
                    int wagon = Convert.ToInt32(button.Content);
                    currentWagon = currentWagon.Where(x => x.ShortNumber == wagon).ToList();
                    foreach (var wagons in currentWagon)
                        wagonList.Add(wagons);
                }
                //RelocateWagonsWindow relocateWagons = new RelocateWagonsWindow(wagonList, context, railwayListBox);
                //relocateWagons.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

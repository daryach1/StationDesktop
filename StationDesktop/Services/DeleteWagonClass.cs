using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StationDesktop.Data;

namespace StationDesktop.Services
{
    public class DeleteWagonClass
    {
        ListBox railwayList;
        StationContext context;
        public DeleteWagonClass(ListBox railwayList)
        {
            this.railwayList = railwayList;
            //context = new StationContext();
            DeleteWagon();
        }

        private StationContext DeleteWagon()
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить данные вагоны безвозвратно?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                List<Button> listButton = railwayList.SelectedItems.Cast<Button>().ToList();
                foreach (var button in listButton)
                {
                    List<Wagon> currentWagon = context.Wagons.ToList();
                    int Wagon = Convert.ToInt16(button.Content);
                    railwayList.Items.Remove(button);
                    currentWagon = currentWagon.Where(x => x.ShortNumber == Wagon).ToList();
                    foreach (var wagon in currentWagon)
                    {
                        context.Wagons.Remove(wagon);
                        context.SaveChanges();
                    }
                }
            }
            return context;
        }
    }
}

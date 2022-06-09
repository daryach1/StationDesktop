using StationDesktop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace StationDesktop.Services
{
    static internal class ListBoxService
    {
        public static Dictionary<ListBox, int> ListBoxes;
        private static List<Wagon> Wagons;
        public static void UpdateListBoxes()
        {
            foreach(var listBox in ListBoxes)
            {
                switch(listBox.Value)
                {
                    case 1:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach(var wagon in Wagons)
                        {
                            Button newButton = new Button();
                            newButton.Height = 30;
                            newButton.Width = 50;
                            switch(wagon.MarkupCode)
                            {
                                case 1:
                                    newButton.Background = Brushes.HotPink;
                                    break;
                                case 2:
                                    newButton.Background = Brushes.LemonChiffon;
                                    break;
                                case 3:
                                    newButton.Background = Brushes.LightBlue;
                                    break;
                                default :
                                    if (wagon.IsLoading==true)
                                        newButton.Background = Brushes.LightGreen;
                                    else newButton.Background = Brushes.White;
                                    break;
                            }
                            newButton.FontSize = 18;
                            newButton.Content = wagon.ShortNumber;
                            newButton.Name = "Wagon" + wagon.ShortNumber;
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                    case 2:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach (var wagon in Wagons)
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
                                    newButton.Background = Brushes.LightBlue;
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
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                    case 3:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach (var wagon in Wagons)
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
                                    newButton.Background = Brushes.LightBlue;
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
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                    case 4:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach (var wagon in Wagons)
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
                                    newButton.Background = Brushes.LightBlue;
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
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                    case 5:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach (var wagon in Wagons)
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
                                    newButton.Background = Brushes.LightBlue;
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
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                    case 6:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach (var wagon in Wagons)
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
                                    newButton.Background = Brushes.LightBlue;
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
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                    case 7:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach (var wagon in Wagons)
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
                                    newButton.Background = Brushes.LightBlue;
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
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                    case 8:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach (var wagon in Wagons)
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
                                    newButton.Background = Brushes.LightBlue;
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
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                    case 9:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach (var wagon in Wagons)
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
                                    newButton.Background = Brushes.LightBlue;
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
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                    case 10:
                        listBox.Key.Items.Clear();
                        Wagons = ContextService.StationContext.Wagons.Where(w => w.RailwayCode == listBox.Value).ToList();
                        foreach (var wagon in Wagons)
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
                                    newButton.Background = Brushes.LightBlue;
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
                            listBox.Key.Items.Add(newButton);
                        }
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Workshop> workshops = new List<Workshop>();
        public MainWindow()
        {
            InitializeComponent();
            workshops = Workshop.ReadWorkshopList("workshops");
            workshops.ForEach(workshop =>
            {
                Workshops_List.Items.Add(workshop.ToShortString());
            });
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            Workshop newWorkshop = new Workshop();
            workshopWPF workshopModal = new workshopWPF(newWorkshop);
            if (workshopModal.ShowDialog() == true)
            {
                newWorkshop.Count = Workshops_List.Items.Count + 1;
                Workshops_List.Items.Add(newWorkshop.ToShortString());
                workshops.Add(newWorkshop);
            }
            else
            {
                MessageBox.Show("Изменения не сохранены");
            }
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = Workshops_List.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= workshops.Count)
            {
                MessageBox.Show("Выберете магазин!");
                return;
            }
            workshopWPF workshopModal = new workshopWPF(workshops[Workshops_List.SelectedIndex]);
            bool? result = workshopModal.ShowDialog();
            if ( result==true)
            {
                Workshops_List.Items[selectedIndex] = workshops[Workshops_List.SelectedIndex].ToShortString();
            }
            else
            {
                MessageBox.Show("Изменения не сохранены");
            }
        }

        private void ShowMore_Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = Workshops_List.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= workshops.Count)
            {
                MessageBox.Show("Выберете магазин!");
            }
            else
            {
                MessageBox.Show(workshops[selectedIndex].ToString());
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = Workshops_List.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= workshops.Count)
            {
                MessageBox.Show("Выберете магазин!");
                return;
            }
            workshops.RemoveAt(selectedIndex);
            Workshops_List.Items.RemoveAt(selectedIndex);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                MessageBoxResult result = MessageBox.Show("Сохранить?", "Сообщение", MessageBoxButton.YesNo);
     
                if (result == MessageBoxResult.Yes)
                {
                    Workshop.WriteWorkshopsToFile("workshops", workshops);
                }  
        }
    }
}

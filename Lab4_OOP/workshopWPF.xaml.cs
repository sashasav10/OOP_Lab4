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
using System.Windows.Shapes;

namespace Lab4_OOP
{
    /// <summary>
    /// Логика взаимодействия для workshopWPF.xaml
    /// </summary>
    public partial class workshopWPF : Window
    {
        public Workshop workshopWP;
        public workshopWPF(Workshop workshop)
        {
            InitializeComponent();
            workshopWP = workshop;
            workshopWP.Count = workshop.Count;
            if (workshopWP != null && workshopWP.Lumbers != null)
            {
                CountObject_Label.Content = Lumber_List.Items.Count;
                workshopWP.CalculateTotalPrice();
                TotalPrice_Label.Content = workshop.TotalLumberPrice.ToString();
                if (workshop.Lumbers != null)
                {
                    workshop.Lumbers.ForEach(lumber =>
                    {
                        Lumber_List.Items.Add(lumber);
                    });
                }
            }
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            Lumber newLumber = new Lumber();
            lumberWPF lumberModal = new lumberWPF(newLumber);
            if (lumberModal.ShowDialog() == true)
            {
                workshopWP.AddLumber(newLumber);
                workshopWP.CalculateTotalPrice();
                Lumber_List.Items.Add(newLumber.ToString());
                TotalPrice_Label.Content = workshopWP.TotalLumberPrice.ToString();
                CountObject_Label.Content = Lumber_List.Items.Count;
            }
            else
            {
                MessageBox.Show("Изменения не сохранены");
            }

        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = Lumber_List.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= workshopWP.Lumbers.Count)
            {
                MessageBox.Show("Выберете пиломатериал!");
                return;
            }
            lumberWPF lumberModal = new lumberWPF(workshopWP.Lumbers[selectedIndex]);
            if (lumberModal.ShowDialog() == true)
            {
                Lumber_List.Items[selectedIndex] = workshopWP.Lumbers[selectedIndex].ToString();
                workshopWP.CalculateTotalPrice();
                TotalPrice_Label.Content = workshopWP.TotalLumberPrice.ToString();
                CountObject_Label.Content= Lumber_List.Items.Count;

            }
            else
            {
                MessageBox.Show("Changes was not saved");
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveandExit_Button_Click(object sender, RoutedEventArgs e)
        {
            workshopWP.CountObjects = Lumber_List.Items.Count;
            workshopWP.TotalLumberPrice = Convert.ToInt32(TotalPrice_Label.Content);
            if (Lumber_List.Items == null)
            { MessageBox.Show("Заполните все поля!");
                return;
            }
            DialogResult = true;
            this.Close();
        }
    }
}

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
    /// Логика взаимодействия для lumberWPF.xaml
    /// </summary>
    public partial class lumberWPF : Window
    {
        Lumber lumberWP;
        List<Wood> woods;

        public lumberWPF(Lumber lumber)
        {
            InitializeComponent();

            SawingOption[] option = (SawingOption[])Enum.GetValues(typeof(SawingOption));
            foreach (SawingOption soption in option)
            {
                SavingOption_ComboBox.Items.Add(soption.ToString());

            }
            lumberWP = lumber;
            woods = Wood.ReadWoodsList("woods");
            woods.ForEach(author =>
            {
                Woods_ComboBox.Items.Add(author.ToString());
            });

            if (lumberWP != null && lumberWP.Wood != null)
            {
                Woods_ComboBox.SelectedIndex = Woods_ComboBox.Items.IndexOf(lumber.Wood.ToString());
               Marking_TextBox.Text = lumberWP.Marking.ToString();
                Quantity_TextBox.Text = lumberWP.Quantity.ToString();
                Price_TextBox.Text = lumberWP.Price.ToString();
            }          
        }

        private void EditWood_Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = Woods_ComboBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= woods.Count)
            {
                MessageBox.Show("Необходимо выбрать древесину!");
                return;
            }
            woodWPF woodModal = new woodWPF(woods[selectedIndex]);
            if (woodModal.ShowDialog() == true)
            {
                Woods_ComboBox.Items[selectedIndex] = woods[selectedIndex].ToString();
                Wood.WriteWoodsToFile("Woods", woods);
            }
            else
            {
                MessageBox.Show("Изменения не сохранены");
            }
        }

        private void CreateWood_Button_Click(object sender, RoutedEventArgs e)
        {
            Wood newWood = new Wood();
            woodWPF woodModal = new woodWPF(newWood);
            if (woodModal.ShowDialog() == true)
            {
                Woods_ComboBox.Items.Add(newWood.ToString());
                woods.Add(newWood);
                Wood.WriteWoodsToFile("Woods", woods);
            }
            else
            {
                MessageBox.Show("Изменения не сохранены");
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = Woods_ComboBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= woods.Count)
            {
                MessageBox.Show("You need to choose author!");
                return;
            }
            if (Marking_TextBox.Text == "" || Quantity_TextBox.Text == "" || Price_TextBox.Text == "")
            {
                MessageBox.Show("Необходимо заполнить поля!");
                return;
            }

            lumberWP.Wood = woods[selectedIndex];
            lumberWP.SawingOption =(SawingOption)Enum.Parse(typeof(SawingOption), SavingOption_ComboBox.SelectedItem.ToString());
            lumberWP.Marking = int.Parse(Marking_TextBox.Text);
            lumberWP.Quantity = int.Parse(Quantity_TextBox.Text);
            lumberWP.Price = int.Parse(Price_TextBox.Text);
            DialogResult = true;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

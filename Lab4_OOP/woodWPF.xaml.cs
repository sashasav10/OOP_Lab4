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
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Lab4_OOP
{
    /// <summary>
    /// Логика взаимодействия для woodWPF.xaml
    /// </summary>
    public partial class woodWPF : Window
    {
        Wood woodWP;
        public woodWPF()
        {
            InitializeComponent();
        }
        public woodWPF(Wood wood)
        {
            InitializeComponent();
            woodWP = wood;

            if (wood != null && wood.Breed != null)
            {
                Breed_TextBox.Text = wood.Breed;
                Humidity_TextBox.Text = Convert.ToString(wood.Humidity);
                Density_TextBox.Text = Convert.ToString(wood.Density);
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Breed_TextBox.Text == "" || Humidity_TextBox.Text == "" || Density_TextBox.Text == "")
            {
                MessageBox.Show("Необходимо заполнить значения!");
                return;
            }
            woodWP.Breed = Breed_TextBox.Text;
            woodWP.Humidity = Convert.ToInt16(Humidity_TextBox.Text);
            woodWP.Density = Convert.ToInt16(Density_TextBox.Text);
            DialogResult =true;
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сохранить изменения?", "Сообщение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes&& Breed_TextBox.Text!=""&& Humidity_TextBox.Text!=""&& Density_TextBox.Text!="")
                {
                woodWP.Breed = Breed_TextBox.Text;
                woodWP.Humidity = Convert.ToInt16(Humidity_TextBox.Text);
                woodWP.Density = Convert.ToInt16(Density_TextBox.Text);
                DialogResult = true;
            }
                else
                {

                    this.Close();
                }
            
        }

    }
}

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

namespace Car_Sale
{
    /// <summary>
    /// Interaction logic for Sale.xaml
    /// </summary>
    public partial class Vehicle : UserControl
    {
        public Vehicle()
        {
            InitializeComponent();
        }

        private void BtnAddcar_Click(object sender, RoutedEventArgs e)
        {
            Addcar obj = new Addcar();
            obj.Show();

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void BtnViewcar_Click(object sender, RoutedEventArgs e)
        {
            Viewcar obj = new Viewcar();
            obj.Show();

        }

        private void BtnManufacturer_Click(object sender, RoutedEventArgs e)
        {
            Addmanufacturer obj = new Addmanufacturer();
            obj.Show();
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnUpdatecar_Click(object sender, RoutedEventArgs e)
        {
            Update_Car obj = new Update_Car();
            obj.Show();
        }
    }
}

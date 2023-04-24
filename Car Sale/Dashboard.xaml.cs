using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Car_Sale
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        SqlConnection con;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             DateTime today = DateTime.Now;
             txt_date.Text = today.ToString();
        }
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void Btn_Restore_Click(object sender, RoutedEventArgs e)
        {

            BtnMaximize.Visibility = Visibility.Visible;
            BtnRestore.Visibility = Visibility.Hidden;
            icon_restore.Visibility = Visibility.Hidden;
            icon_maximize.Visibility = Visibility.Visible;
            SystemCommands.RestoreWindow(this);
        }
        private void Btn_Maximize_Click(object sender, RoutedEventArgs e)
        {
            BtnMaximize.Visibility = Visibility.Hidden;
            BtnRestore.Visibility = Visibility.Visible;
            icon_maximize.Visibility = Visibility.Hidden;
            icon_restore.Visibility = Visibility.Visible;
            SystemCommands.MaximizeWindow(this);
        }
        private void Btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            UserControl usc = null;
            GridMain.Children.Clear();
            MainWindowContent.Children.Clear();
            MainWindowButton.Children.Clear();
           

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {

                case "ItemLivechart":
                    usc = new Livechart();
                    GridMain.Children.Add(usc);

                    break;

                case "ItemSalesman":

                    usc = new Salesman();
                    GridMain.Children.Add(usc);

                    break;

                case "ItemVehicle":

                    usc = new Vehicle();
                    GridMain.Children.Add(usc);

                    break;

                case "ItemSale":

                    usc = new Sale();
                    GridMain.Children.Add(usc);

                    break;

                case "ItemSupplier":


                    usc = new Supplier();
                    GridMain.Children.Add(usc);

                    break;

                case "ItemCustomer":


                    usc = new Customer();
                    GridMain.Children.Add(usc);

                    break;

                case "ItemReport":


                    usc = new Report();
                    GridMain.Children.Add(usc);

                    break;



                case "ItemDashboard":


                    Dashboard obj = new Dashboard();
                    obj.Show();
                    this.Close();

                    break;


                default:

                    break;
            }

        }


        private void logout_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure to logout", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Login obj = new Login();
                obj.Show();
                this.Close();
            }
            else
            {
            }
        }

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            UserRegistration obj = new UserRegistration();
            obj.Show();
        }
    }
}

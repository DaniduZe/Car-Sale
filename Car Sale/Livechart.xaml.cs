using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;


namespace Car_Sale
{
    /// <summary>
    /// Interaction logic for Livechart.xaml
    /// </summary>
    public partial class Livechart : UserControl
    {
        public Livechart()
        {
            InitializeComponent();
        }

        SqlConnection con;
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DELL;Initial Catalog=CarSaleNew;Integrated Security=True");

             try
             {
            con.Open();
               SqlCommand countSaleQuery = new SqlCommand("Select Count(SaleID) from Sale", con);
               int countSale = Convert.ToInt32(countSaleQuery.ExecuteScalar());

                SqlCommand countVehQuery = new SqlCommand("Select Count(VehicleID) from Vehicle", con);
                int countVeh = Convert.ToInt32(countVehQuery.ExecuteScalar());

                SqlCommand countMCQuery = new SqlCommand("Select Count(MCName) from Manufactured_Campany", con);
                int countMC = Convert.ToInt32(countMCQuery.ExecuteScalar());

                SqlCommand countMODQuery = new SqlCommand("Select Count(modelID) from Model", con);
                int countMOD = Convert.ToInt32(countMODQuery.ExecuteScalar());

                SqlCommand countSupplierQuery = new SqlCommand("Select Count(NIC) from Supplier", con);
                int countSupplier = Convert.ToInt32(countSupplierQuery.ExecuteScalar());

                SqlCommand countSalesmanQuery = new SqlCommand("Select Count(SalesmanID) from Salesman", con);
                int countSalesman = Convert.ToInt32(countSalesmanQuery.ExecuteScalar());

                SqlCommand countCustomerQuery = new SqlCommand("Select Count(CustomerNIC) from Customer", con);
                int countCustomer = Convert.ToInt32(countCustomerQuery.ExecuteScalar());

                Veh_pie.Series.Clear();
                Veh_pie.Series.Add(new PieSeries { DataLabels = true, Title = "Sale", StrokeThickness = 0, Values = new ChartValues<int> { countSale } });
                Veh_pie.Series.Add(new PieSeries { DataLabels = true, Title = "Vehicle", StrokeThickness = 0, Values = new ChartValues<int> { countVeh } });
                Veh_pie.Series.Add(new PieSeries { DataLabels = true, Title = "Manufactured Company", StrokeThickness = 0, Values = new ChartValues<int> { countMC } });
                Veh_pie.Series.Add(new PieSeries { DataLabels = true, Title = "Model", StrokeThickness = 0, Values = new ChartValues<int> { countMOD } });
                Veh_pie.Series.Add(new PieSeries { DataLabels = true, Title = "Supplier", StrokeThickness = 0, Values = new ChartValues<int> { countSupplier } });
                Veh_pie.Series.Add(new PieSeries { DataLabels = true, Title = "Salesman", StrokeThickness = 0, Values = new ChartValues<int> { countSalesman } });
                Veh_pie.Series.Add(new PieSeries { DataLabels = true, Title = "Customer", StrokeThickness = 0, Values = new ChartValues<int> { countCustomer } });


                countSaleQuery.Dispose();
                countVehQuery.Dispose();
                countMCQuery.Dispose();
                countMODQuery.Dispose();
                countSupplierQuery.Dispose();
                countSalesmanQuery.Dispose();
                countCustomerQuery.Dispose();

                con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Database connection in a vulnerability or not data inserted yet!", "Warrning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Your Connection Time Out! Please sure your connection is real!", "Time Out!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (TimeZoneNotFoundException)
            {
                MessageBox.Show("Can't find real Time Zone!", "Time Zone Not Found!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidTimeZoneException)
            {
                MessageBox.Show("Your current TimeZone is useless!... Please! setup real Time Zone!", "Invalid Time Zone!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidProgramException)
            {
                MessageBox.Show("You have invalid Microsoft Intermediate Language or missing it! Please!... install MSIL and related metadata! ", "MSIL Not Found!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Something is going wrong!", "Oops!...", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
    
}

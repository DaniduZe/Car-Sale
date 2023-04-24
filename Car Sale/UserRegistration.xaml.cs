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
using System.Data.SqlClient;
using System.Data;

namespace Car_Sale
{
    /// <summary>
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        public UserRegistration()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        private void Btn_Browse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Camera_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cam_open_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cam_capture_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (txt_User_name.Text.Length < 4)
            {
                txt_error_user_name.Text = "Invalid Username!";
                txt_User_name.Focus();
            }
            else if (txt_Password.Text.Length < 4)
            {
                txt_error_password.Text = "Password must have letters,symbols and numbers more than five!";
                txt_Password.Focus();
            }
            else if (txt_Password.Text != txt_Retype_Password.Text)
            {
                txt_error_retype_password.Text = "Password did not match!";
                txt_Retype_Password.Focus();
            }
            else if (cmb_Type.SelectedIndex < 0)
            {
                cmb_Type.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Insert into VehicleSaleUser(UserName,UserPassword,UserType)values ('" + txt_User_name.Text + "','" + txt_Password.Text + "','" + cmb_Type.Text + "')", con);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("Data Saved Successfully");
                    }
                    con.Close();

                }
                catch(NullReferenceException)
                {
                    MessageBox.Show(this, "Object reference not set! ", "Null Reference Found!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (SqlException)
                {
                    MessageBox.Show(this, "Something is wrong in Database!", "Database Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (TimeoutException)
                {
                    MessageBox.Show(this, "Your Connection Time Out! Please sure your connection is real!", "Time Out!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (InvalidTimeZoneException)
                {
                    MessageBox.Show("Your current TimeZone is useless!... Please! setup real Time Zone!", "Invalid Time Zone!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (TimeZoneNotFoundException)
                {
                    MessageBox.Show(this, "Can't find your Time Zone! Make sure you are in valid Time Zone or check BIOS!", "Time Zone Not Found!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (InvalidProgramException)
                {
                    MessageBox.Show(this, "You have invalid Microsoft Intermediate Language or missing it! Please!... install MSIL and related metadata! ", "MSIL Not Found!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Something is going wrong! Please check what you trying to insert!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
           
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            txt_error_retype_password.Text = null;
            txt_error_password.Text = null;
            txt_error_type.Text = null;
            txt_error_user_name.Text = null;
            txt_Password.Text = null;
            txt_Retype_Password.Text = null;
            txt_User_name.Text = null;

        }
  

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //con = new SqlConnection("Data Source=;Initial Catalog=CarSaleNew;Integrated Security=True");
            con = new SqlConnection("Data Source=DELL;Initial Catalog=DB_VehicleSale;Integrated Security=True");

        }
    }
}

using System;
using System.Data.SqlClient;
using System.Windows;

namespace Car_Sale
{
    public partial class Login : Window
    {
        SqlConnection con;
        SqlCommand cmd;
        public Login()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //con = new SqlConnection("Data Source=;Initial Catalog=DB_VehicleSale;Integrated Security=True");
            con = new SqlConnection("Data Source=DELL;Initial Catalog=CarSaleNew;Integrated Security=True");
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "Treat customers as family", "Successfully Loggedin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Dashboard obj1 = new Dashboard();
            obj1.Show();
            this.Close();

            string password = "", username = "";


            if (string.IsNullOrEmpty(txt_username.Text))
            {
                txt_error.Text = "Username Cannot be blank Please Enter username !";
                txt_username.Focus();
            }
            else if (string.IsNullOrEmpty(txt_password.Password))
            {
                txt_error.Text = "Password Cannot be Blank Please Enter the Password !";
                txt_password.Focus();
            }
            else
            {
                txt_error.Text = "";
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Select UserName,UserPassword from VehicleSaleUser where UserName='" + txt_username.Text + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        username = dr.GetString(0);
                        password = dr.GetString(1);
                    }
                    con.Close();
                    if (username != txt_username.Text)
                    {
                        txt_error.Text = "Username you enterd is not existed Please check the username again";
                        txt_username.Focus();
                    }
                    else if (password != txt_password.Password)
                    {
                        txt_error.Text = "Password is wrong Please Check the password again";
                        txt_password.Focus();
                        txt_password.Clear();
                    }
                    else
                    {
                        MessageBox.Show(this, "Treat customers as family", "Successfully Loggedin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Dashboard obj = new Dashboard();
                        obj.Show();
                        this.Close();
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show(this, "Something Wrong with data source please contact System Maintainer", "Error !", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Something went wrong Please contact system Maintainer", "Error !", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Contact Manager for help", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

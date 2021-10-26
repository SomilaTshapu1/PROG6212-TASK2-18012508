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
using System.Data;
using System.Data.SqlClient;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();

        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=userregistration;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[register]
           ([firstname]
           ,[lastname]
           ,[email]
           ,[phone]
           ,[password]
           ,[username])
     VALUES
            ('" + txtfirstname.Text + "', '" + txtlastname.Text + "', '" + txtemail.Text + "', '" + txtphone.Text + "', '" + Hash_Password.HashPass (txtpassword.Text) + "', '" + txtusername.Text + "')", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Register Successfully");
            Login log = new Login();
            log.ShowDialog();




        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void chkbox_show_hide_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

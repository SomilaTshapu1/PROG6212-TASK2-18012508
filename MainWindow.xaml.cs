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
using System.Data;
using System.Data.SqlClient;
using System.Windows.Shapes;
using System.Configuration;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Reference: 
        //https://youtu.be/Qh-oWyvJgIU
        //https://youtu.be/n7P5FfB0SkE

        public MainWindow()
        {
            InitializeComponent();
           
            binddatagrid();
        }

        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Prog_task2;Integrated Security=True");

        private void binddatagrid()
        {

            // Selecting data from the sql database and displaying it in datagridview
            SqlCommand cmd = new SqlCommand("select * from Modules", conn);
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();
            datagrid1.ItemsSource = dt.DefaultView;

            
        }

        // add new module was clicked
        private void btnNew_Clicked(object sender, RoutedEventArgs e)
        {
            MyModules mymodules = new MyModules();
            mymodules.moduleCode = txtModuleCOde.Text;
            mymodules.moduleName = txtModuleName.Text;
            mymodules.credits = txtCredits.Text;
            mymodules.weeklyHours = txtweeklyHours.Text;
            mymodules.semesterWeeks = txtSmesterWeeks.Text;
            mymodules.startDate = dpStartDate.Text;
            mymodules.selfstudy = txtSelfstudy.Text;
            mymodules.selfstudy = txtRemainingHouurs.Text;
            
            mymodules.recorddate = dpDate.Text;

            
           // inserting data to the database from textboxes

            if (validate())
            {
                Connection con = new Connection();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Modules]
           ([Module_name]
           ,[Module_code]
           ,[Credits]
           ,[Weekly_hours]
           ,[Semester_weeks]
           ,[Start_date]
           ,[Selfstudy_weekly]
           ,[Remaining_hours]
            ,[Date_recorded])

        VALUES
           ('" + txtModuleName.Text + "','" + txtModuleCOde.Text + "','" + txtCredits.Text + "','" + txtweeklyHours.Text + "','" + txtSmesterWeeks.Text + "','" + dpDate.Text + "','" + txtSelfstudy
               .Text + "','" + txtRemainingHouurs.Text + "','" + dpDate.Text + "' )", con.active());
                cmd.ExecuteNonQuery();
                binddatagrid();
                MessageBox.Show("successful", "insert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("error", "insert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
         bool validate()
        {
            bool returnvalue = true;
            if (txtModuleName.Text.Length== 0)
            {
                returnvalue = false;
            }
           if (txtModuleCOde.Text.Length == 0)
            {
                returnvalue = false;
            }
            if (txtCredits.Text.Length == 0)
            {
                returnvalue = false;
            }
            if (txtweeklyHours.Text.Length == 0)
            {
                returnvalue = false;
            }
            if (txtSmesterWeeks.Text.Length == 0)
            {
                returnvalue = false;
            }
            if (dpStartDate.Text.Length == 0)
            {
                returnvalue = false;
            }
            if (txtSelfstudy.Text.Length == 0)
            {
                returnvalue = false;
            }
            if (txtRemainingHouurs.Text.Length == 0)
            {
                returnvalue = false;
            }
            if (txtModuleName.Text.Length == 0)
            {
                returnvalue = false;
            }

            return returnvalue;
        }

        private void btnSelfStudy_Clicked(object sender, RoutedEventArgs e)
        {
            int credits = Convert.ToInt32(txtCredits.Text);
            int semesterweeks = Convert.ToInt32(txtSmesterWeeks.Text);
            int weeklyhours = Convert.ToInt32(txtweeklyHours.Text);
            int self_study_weeklyHours = Convert.ToInt32(credits * 10 / semesterweeks - weeklyhours);

            txtSelfstudy.Text = self_study_weeklyHours.ToString();
        }

        private void btnHoursRemaining_Clicked(object sender, RoutedEventArgs e)
        {
            int hoursSpent = Convert.ToInt32(txtHoursSpent.Text);
            int selfstudyHours = Convert.ToInt32(txtSelfstudy.Text);
            int hoursRemaining = Convert.ToInt32(selfstudyHours - hoursSpent);

            txtRemainingHouurs.Text = hoursRemaining.ToString();
        }

        private void btnDelete_Clicked(object sender, RoutedEventArgs e)
        {
            //if(dgv.SelectedIndex >=0)
            //    {
            //    dgv.Items.RemoveAt(dgv.SelectedIndex);
            //} 

            //new code 26/10/2021
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Modules]
      WHERE [Module_name] = '" + txtModuleName.Text + "'", con.active());
            cmd.ExecuteNonQuery();
            MessageBox.Show("successfull", "delete", MessageBoxButton.OK, MessageBoxImage.Information);
            txtModuleName.Clear();
            txtModuleCOde.Clear();
            txtCredits.Clear();
            txtHoursSpent.Clear();
            txtRemainingHouurs.Clear();
            txtSelfstudy.Clear();
            txtSmesterWeeks.Clear();
            txtweeklyHours.Clear();



        }

        private void btnUpdate_Clicked(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Modules]
   SET [Module_name] = '" + txtModuleName.Text + "',[Module_code] = '" + txtModuleCOde.Text + "',[Credits] = '" + txtCredits.Text + "',[Weekly_hours] = '" + txtweeklyHours.Text + "',[Semester_weeks] = '" + txtSmesterWeeks.Text + "',[Start_date] = '" + dpStartDate.Text + "',[Selfstudy_weekly] = '" + txtSelfstudy.Text  + "',[Remaining_hours] = '" + txtRemainingHouurs.Text +"' WHERE [Module_name] ='" + txtModuleName.Text + "'", con.active());
            cmd.ExecuteNonQuery();
            binddatagrid();
            MessageBox.Show("successful", "update", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnNew1_Clicked(object sender, RoutedEventArgs e)
        {
            txtCredits.Clear();
            txtModuleCOde.Clear();
            txtModuleName.Clear();
            txtSmesterWeeks.Clear();
            txtweeklyHours.Clear();
            txtSelfstudy.Clear();
            txtHoursSpent.Clear();
            txtRemainingHouurs.Clear();

            dpDate.Text = "";
            dpStartDate.Text = "";
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Calculate_Marks cm = new Calculate_Marks();
            cm.ShowDialog();
        }
       
    }
}

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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Calculate_Marks.xaml
    /// </summary>
    public partial class Calculate_Marks : Window
    {
        public Calculate_Marks()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float num1, num2, num3, num4, num5, num6, num7, num8, num9, total, avarage;
            num1 = float.Parse(txtProg.Text);
            num2 = float.Parse(txtProject.Text);
            num3 = float.Parse(txtData.Text);
            num4 = float.Parse(txtComputing.Text);
            num5 = float.Parse(txtWill.Text);
            num6= float.Parse(txtOPSC.Text);
            num7 = float.Parse(txtIsec.Text);
            num8 = float.Parse(txtbusiness.Text);
            num9 = float.Parse(txtMaths.Text);
            total = num1 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
            avarage = total / 9;
            txtTotal.Text = "" + total;
            txtaverage.Text = "" + avarage;
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtaverage.Text = "";
            txtbusiness.Text = "";
            txtComputing.Text = "";
            txtData.Text = "";
            txtIsec.Text = "";
            txtMaths.Text = "";
            txtOPSC.Text = "";
            txtProg.Text = "";
            txtProject.Text = "";
            txtTotal.Text = "";
            txtWill.Text = "";
        }
    }
}

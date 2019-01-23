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

namespace FitnessApplication
{
    /// <summary>
    /// Interaction logic for GenderDialog.xaml
    /// </summary>
    public partial class GenderDialog : Window
    {
        public static string user = AuthentificationWindow.currentUsername;

        public GenderDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFitEntities c = new MyFitEntities();
            var id = (from s in c.Accounts
                      where s.Username == user
                      select s).FirstOrDefault();
            Window2 w = new Window2();
            if (Male.IsChecked == true && id.Gender != "Male")
            {
                id.Gender = "Male";
               
            }
            else if(Female.IsChecked==true && id.Gender!="Female")
            {
                id.Gender = "Female";
            }
            w.Gender.Text = id.Gender;
            c.SaveChanges();

            Close();
        }
        public void Show()
        {
            ShowDialog();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

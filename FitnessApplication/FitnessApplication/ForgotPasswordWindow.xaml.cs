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
    /// Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : Window
    {
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void ChPass_button_Click(object sender, RoutedEventArgs e)
        {
            var context = new MyFitEntities();
            var temp = (from p in context.AccountCredentials where p.AccEmail == EmAdress_textbox.Text select p).FirstOrDefault();

            if (temp == null)
            {
                MessageBox.Show("The Email you entered is not valid!");
            }
            else
            {
               this.Close();

                ChangePasswordWindow window = new ChangePasswordWindow();
                window.Show();
            }
        }
    }
}

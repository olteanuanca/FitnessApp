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
   
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void ChPassword_button_Click(object sender, RoutedEventArgs e)
        {
            var context = new MyFitEntities();
            var temp = (from p in context.AccountCredentials where p.AccUsername == username_textbox.Text select p).FirstOrDefault();

            if (NewPassword_textbox.Password == rewritepass_textbox.Password)
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(NewPassword_textbox.Password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hashPassword = System.Text.Encoding.ASCII.GetString(data);

                temp.AccPassword = hashPassword;
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("The passwords don't match!");
                return;
            }
          

            this.Close();
        }
    }
}

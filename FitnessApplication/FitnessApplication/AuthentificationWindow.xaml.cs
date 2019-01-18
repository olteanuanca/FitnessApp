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
  
    public partial class AuthentificationWindow : Window
    {
        public static string currentUsername;
        public AuthentificationWindow()
        {
            InitializeComponent();
        }

        private void ForgotPassword_label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ForgotPasswordWindow window = new ForgotPasswordWindow();
            window.Show();
        }

        private void newAccount_label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            

            NewAccountWindow1 window =  new NewAccountWindow1();
            window.Show();
           
        }

        private void LogIn_button_Click(object sender, RoutedEventArgs e)
        {
            currentUsername = Username_textbox.Text;
            

            byte[] data = System.Text.Encoding.ASCII.GetBytes(Password_textbox.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hashPassword = System.Text.Encoding.ASCII.GetString(data);

            var context = new MyFitEntities();

            var check = (from c in context.AccountCredentials where c.AccUsername == Username_textbox.Text select c).FirstOrDefault();

            if (check == null)
            {
                MessageBox.Show("You don't have an account!");
                NewAccountWindow1 window = new NewAccountWindow1();
                window.Show();
            }
            else if (check.AccUsername == Username_textbox.Text && check.AccPassword == hashPassword)
            {
                currentUsername = Username_textbox.Text;
                HomePageWindow home = new HomePageWindow();
                home.Show();
                this.Close();
            }
            else if(check.AccPassword!=hashPassword)
            {
                MessageBox.Show("Wrong password!");
              
            }



        }
    }
}

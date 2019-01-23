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
    /// Interaction logic for UserDialog.xaml
    /// </summary>
    public partial class UserDialog : Window
    {
        public UserDialog()
        {
            InitializeComponent();
        }
        public void Show()
        {
            ShowDialog();
        }
        private void Button_ClickOK(object sender, RoutedEventArgs e)
        {
            string oldUsername = AuthentificationWindow.currentUsername;
            string newUsername = ChangedUser.Text;

            MyFitEntities context = new MyFitEntities();
            var  c = (from s in context.Accounts
                    where s.Username == oldUsername
                    select s).First();
            c.Username = newUsername;


            var c2=(from s in context.AccountCredentials
                    where s.AccUsername == oldUsername
                    select s).First();
            c2.AccUsername = newUsername;


            context.SaveChanges();

            Close();
        }

        private void Button_ClickCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

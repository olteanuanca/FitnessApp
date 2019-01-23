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
    /// Interaction logic for Email.xaml
    /// </summary>
    public partial class Email : Window
    {
        public Email()
        {
            InitializeComponent();
        }
        public void Show() => ShowDialog();
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Window2 w = new Window2();
            w.EmailBlock.Text = EmailBox.Text;

            MyFitEntities context = new MyFitEntities();

            var c =( from s in context.Accounts
                    where s.Username == AuthentificationWindow.currentUsername
                 select s).First();
            var c2=(from s in context.AccountCredentials
                    where s.AccUsername == AuthentificationWindow.currentUsername
                    select s).First();

            c.Email = EmailBox.Text;
            c2.AccEmail = EmailBox.Text;
            context.SaveChanges();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

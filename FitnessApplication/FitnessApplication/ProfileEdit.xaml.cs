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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        public static string user = AuthentificationWindow.currentUsername;
        public MyFitEntities c = new MyFitEntities();
        public new void Show()
        {
          
            var line = (from s in c.Accounts
                        where s.Username == user
                        select s).First();

            Username.Text = user;
            Height.Text = line.Height.ToString();
            Gender.Text = line.Gender;
            Birth.Text = line.BirthDate.ToString();
            EmailBlock.Text = line.Email;

            ShowDialog();
        }
        private void Button_Click_Username(object sender, RoutedEventArgs e)
        {
            UserDialog d = new UserDialog();
            d.Show();

            Username.Text = user;
          
        }
        private void Button_Click_Height(object sender, RoutedEventArgs e)
        {
            HeightScale height = new HeightScale();
            height.Show();
        }

        private void Button_Click_Gender(object sender, RoutedEventArgs e)
        {
            GenderDialog g = new GenderDialog();
            g.Show();
  
        }

        private void Button_Click_Birth(object sender, RoutedEventArgs e)
        {
            BirthDialog b = new BirthDialog();
            b.Show();

        }

        private void Button_Click_Email(object sender, RoutedEventArgs e)
        {
            Email em = new Email();
            em.Show();
        }

    }
}

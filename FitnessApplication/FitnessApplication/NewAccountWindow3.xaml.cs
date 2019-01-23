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
  
    public partial class NewAccountWindow3 : Window
    {
        public NewAccountWindow3()
        {
            InitializeComponent();
        }

        private void addfriend_button_Click(object sender, RoutedEventArgs e)
        {
            var context = new MyFitEntities();

            var check = (from c in context.AccountCredentials where c.AccEmail == friend1_textbox.Text select c).FirstOrDefault();

            if (check==null)
            {
               // MessageBox.Show($"Your friend with this email {friend1_textbox.Text} doesn't have an account! Please invite him to join us and then add him/her as a friend!");
            }
            else
            {
                var friend1 = new FriendRequest()
                {
                    fromUsername = NewAccountWindow1.currentUsername,
                    toUsername = friend1_textbox.Text,
                };

                context.FriendRequests.Add(friend1);
                context.SaveChanges();
            }

            var check2 = (from c in context.AccountCredentials where c.AccEmail == friend2_textbox.Text select c).FirstOrDefault();
            if (check2 == null)
            {
              //  MessageBox.Show($"Your friend with this email {friend2_textbox.Text} doesn't have an account! Please invite him to join us and then add him/her as a friend!");
            }
            else
            {
                var friend2= new FriendRequest()
                {
                    fromUsername = NewAccountWindow1.currentUsername,
                    toUsername = friend2_textbox.Text,
                };

                context.FriendRequests.Add(friend2);
                context.SaveChanges();
            };

            

            var check3 = (from c in context.AccountCredentials where c.AccEmail == friend3_textbox.Text select c).FirstOrDefault();

            if (check3 == null)
            {
              //  MessageBox.Show($"Your friend with this email {friend3_textbox.Text} doesn't have an account! Please invite him to join us and then add him/her as a friend!");
            }
            else
            {
                var friend3 = new FriendRequest()
                {
                    fromUsername = NewAccountWindow1.currentUsername,
                    toUsername = friend3_textbox.Text,
                };

                context.FriendRequests.Add(friend3);
                context.SaveChanges();
            }
            this.Close();
        }
    }
}

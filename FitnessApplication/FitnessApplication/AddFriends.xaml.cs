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
 
    public partial class AddFriends : Window
    {
        public AddFriends()
        {
            InitializeComponent();
        }

        private void Send_button_Click(object sender, RoutedEventArgs e)
        {
            var context = new MyFitEntities();

            var newFriend = new FriendRequest()
            {
                fromUsername = myusername_textbox.Text,
                toUsername=ToUsername_textbox.Text,
            };

            context.FriendRequests.Add(newFriend);
            context.SaveChanges();

            this.Close();
        }

        private void Friends_Click(object sender, RoutedEventArgs e)
        {
            FriendsMenuWindow friends = new FriendsMenuWindow();
            friends.Show();
            this.Close();
        }

        private void Food_Click(object sender, RoutedEventArgs e)
        {
            Recipes window = new Recipes();
            window.Show();

        }
    }
}

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
    /// Interaction logic for FriendsMenuWindow.xaml
    /// </summary>
    public partial class FriendsMenuWindow : Window
    {
        public FriendsMenuWindow()
        {
            InitializeComponent();
        }

        private void AddFriend_button_Click(object sender, RoutedEventArgs e)
        {
            AddFriends Add = new AddFriends();
            Add.Show();
        }

        private void Messages_button_Click(object sender, RoutedEventArgs e)
        {
            FriendMessages friendMess = new FriendMessages();
            friendMess.Show();
            //this.Close();
        }

        private void FriendReq_button_Click(object sender, RoutedEventArgs e)
        {
            FriendRequests friendReq=new FriendRequests();
            friendReq.Show();
           // this.Close();

        }

        private void FriendList_Click(object sender, RoutedEventArgs e)
        {
            FriendsList friendList = new FriendsList();
            friendList.Show();
        }

        private void Friends_Click(object sender, RoutedEventArgs e)
        {
            FriendsMenuWindow friends = new FriendsMenuWindow();
            friends.Show();
            this.Close();
        }

        private void Send_button_Click(object sender, RoutedEventArgs e)
        {
            var context = new MyFitEntities();

            var newMsg = new FriendMessage()
            {
                fromUsername = AuthentificationWindow.currentUsername,
                toUsername = ToUsername_TB.Text,
                Message=Message_TB.Text,
            };


            context.FriendMessages.Add(newMsg);
            context.SaveChanges();

            ToUsername_TB.Clear();
            Message_TB.Clear();
       
        }
        private void Food_Click(object sender, RoutedEventArgs e)
        {
            Recipes window = new Recipes();
            window.Show();

        }
    }
}

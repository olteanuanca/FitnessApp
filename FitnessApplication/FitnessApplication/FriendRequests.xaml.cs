using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FitnessApplication
{
    /// <summary>
    /// Interaction logic for FriendRequests.xaml
    /// </summary>
    public partial class FriendRequests : Window
    {
        MyFitEntities context = new MyFitEntities();
        CollectionViewSource friendRequestViewSource;
       
        public FriendRequests()
        {
            InitializeComponent();
            friendRequestViewSource = ((CollectionViewSource)(FindResource("friendRequestViewSource")));
          
            DataContext = this;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            context.FriendRequests.Where(c => c.toUsername == AuthentificationWindow.currentUsername).Load();

            friendRequestViewSource.Source = context.FriendRequests.Local;
         
            
        }

        private void Confirm_button_Clicked(object sender, RoutedEventArgs e)
        {
            var selectedRow = friendRequestViewSource.View.CurrentItem as FriendRequest;

            Account currentID = context.Accounts.Where(i => i.Username == AuthentificationWindow.currentUsername).Single();

            FriendRequest currentRequest= (from c in context.FriendRequests
                                           where c.id_FriendRequest == selectedRow.id_FriendRequest
                                           select c).SingleOrDefault();
            Account requestInfo = (from c in context.Accounts
                                   where c.Username==selectedRow.fromUsername
                                   select c).SingleOrDefault();
            
            
            var newFriend = new Friend()
           {
                Username=selectedRow.fromUsername,
                EmailAddress=requestInfo.Email,
            };

                context.Friends.Add(newFriend);
                context.SaveChanges();

            var Acc_Friend = new Accounts_Friends()
            {
                id_Friends = newFriend.id_Friend,
                id_Account = currentID.id_Account,
            };

                context.Accounts_Friends.Add(Acc_Friend);
                context.SaveChanges();

            var newFriend2 = new Friend()
            {
                Username=AuthentificationWindow.currentUsername,
                EmailAddress=currentID.Email,
            };
            context.Friends.Add(newFriend2);
            context.SaveChanges();

            var Acc_Friend2 = new Accounts_Friends()
            {
                id_Friends= newFriend2.id_Friend,
                id_Account=requestInfo.id_Account,
            };

            context.Accounts_Friends.Add(Acc_Friend2);
            context.SaveChanges();

            if (currentRequest != null)
            {
                context.FriendRequests.Remove(currentRequest);
                context.SaveChanges();
            }

            friendRequestViewSource.View.Refresh();
        }
        private void Delete_button_Clicked(object sender, RoutedEventArgs e)
        {
            var selectedRow = friendRequestViewSource.View.CurrentItem as FriendRequest;


            FriendRequest currentRequest = (from c in context.FriendRequests
                                            where c.id_FriendRequest == selectedRow.id_FriendRequest
                                            select c).SingleOrDefault();
            if (currentRequest != null)
            {
                context.FriendRequests.Remove(currentRequest);
                context.SaveChanges();
            }

            friendRequestViewSource.View.Refresh();

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

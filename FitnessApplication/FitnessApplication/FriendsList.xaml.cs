using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
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
    /// Interaction logic for FriendsList.xaml
    /// </summary>
    public partial class FriendsList : Window
    {
        MyFitEntities context = new MyFitEntities();
        System.Windows.Data.CollectionViewSource friendViewSource;

        public FriendsList()
        {
            InitializeComponent();
           friendViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("friendViewSource")));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var accountID = (from i in context.Accounts
                             where i.Username==AuthentificationWindow.currentUsername
                             select i).SingleOrDefault();
            var friendId = (from c in context.Accounts_Friends
                            where c.id_Account==accountID.id_Account
                            select c).ToArray();


            int tmp;
            for (int id = 0; id < friendId.Count(); id++)
            {

                tmp = (int)friendId[id].id_Friends;
                context.Friends.Where(c => c.id_Friend == tmp).Load();
                friendViewSource.Source = context.Friends.Local;
            }
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

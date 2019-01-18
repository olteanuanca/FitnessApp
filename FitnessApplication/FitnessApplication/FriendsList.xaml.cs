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
    /// Interaction logic for FriendsList.xaml
    /// </summary>
    public partial class FriendsList : Window
    {
        public FriendsList()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var context = new MyFitEntities();

            var getCurrentID = (from c in context.Accounts where c.Username == AuthentificationWindow.currentUsername select c).FirstOrDefault();

         IQueryable  getFriendsID= from c in context.Accounts_Friends where c.id_Account == getCurrentID.id_Account select c.id_Friends;

            foreach(int id in getFriendsID)
            {

            }
           
           // var getFriends=()
            //var table = from c in context.Accounts_Friends
            //            where c.toUsername == AuthentificationWindow.currentUsername
            //            select new
            //            {
            //                c.fromUsername,
            //                c.toUsername,
            //                c.Message
            //            };

           // friendList_datagrid.ItemsSource = table.ToList();
        }
    }
}

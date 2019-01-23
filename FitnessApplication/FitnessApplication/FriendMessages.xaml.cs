using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for FriendMessages.xaml
    /// </summary>
    public partial class FriendMessages : Window
    {
        MyFitEntities context = new MyFitEntities();
        System.Windows.Data.CollectionViewSource friendMessageViewSource;
        public FriendMessages()
        {
            InitializeComponent();
            friendMessageViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("friendMessageViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            context.FriendMessages.Load();
           friendMessageViewSource.Source = context.FriendMessages.Local;


        }


        private void Delete_button_Clicked(object sender, RoutedEventArgs e)
        {
            var selectedRow = friendMessageViewSource.View.CurrentItem as FriendMessage;


            FriendMessage currentRequest = (from c in context.FriendMessages
                                            where c.id_FriendMessage == selectedRow.id_FriendMessage
                                            select c).SingleOrDefault();
            if (currentRequest != null)
            {
                context.FriendMessages.Remove(currentRequest);
                context.SaveChanges();
            }

            friendMessageViewSource.View.Refresh();

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

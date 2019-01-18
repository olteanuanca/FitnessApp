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
    /// Interaction logic for FriendMessages.xaml
    /// </summary>
    public partial class FriendMessages : Window
    {
        public FriendMessages()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var context = new MyFitEntities();

            var table = from c in context.FriendMessages
                       where c.toUsername==AuthentificationWindow.currentUsername
                        select new
                        { c.fromUsername,
                          c.toUsername,
                          c.Message};

           // friendMessage_datagrid.ItemsSource = table.ToList();
        }
    }
}

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
    /// Interaction logic for HomePageWindow.xaml
    /// </summary>
    public partial class HomePageWindow : Window
    {
        public HomePageWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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

        private void DiaryFood_Click(object sender, RoutedEventArgs e)
        {

            DiaryFood Food = new DiaryFood();
            Food.Show();
            this.Close();
        }

        private void DiaryExercise_Click(object sender, RoutedEventArgs e)
        {
            DiaryExercise Exercise = new DiaryExercise();
            Exercise.Show();
            this.Close();
        }

        private void NutritionButton_Click(object sender, RoutedEventArgs e)
        {
            Nutrition N = new Nutrition();
            N.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 profile = new Window1();
            profile.Show();
        }
    }
}

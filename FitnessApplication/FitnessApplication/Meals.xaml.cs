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
    /// Interaction logic for Meals.xaml
    /// </summary>
    public partial class Meals : Window
    {
        MyFitEntities context = new MyFitEntities();
        System.Windows.Data.CollectionViewSource myMealViewSource;
        public Meals()
        {
            InitializeComponent();
            myMealViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("myMealViewSource")));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var accountID = (from i in context.Accounts
                             where i.Username == AuthentificationWindow.currentUsername
                             select i).SingleOrDefault();


            var mealId = (from c in context.Accounts_Meals
                         where c.id_Account == accountID.id_Account
                         select c).ToArray();

            int tmp;

            for (int id = 0; id < mealId.Count(); id++)
            {
                tmp = (int)mealId[id].id_Meals;

                context.MyMeals.Where(c => c.id_myMeal == tmp).Load();

                myMealViewSource.Source = context.MyMeals.Local;
            }

        }
        private void Create_button_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            CreateMeal window = new CreateMeal();
            window.Show();



        }

        private void MyReciepe_label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            Recipes window = new Recipes();
            window.Show();
        }
    }
}

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
    /// Interaction logic for Recipes.xaml
    /// </summary>
    public partial class Recipes : Window
    {
        MyFitEntities context = new MyFitEntities();
        System.Windows.Data.CollectionViewSource myRecipeViewSource;
        public Recipes()
        {
            InitializeComponent();

            myRecipeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("myRecipeViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var accountID = (from i in context.Accounts
                             where i.Username == AuthentificationWindow.currentUsername
                             select i).SingleOrDefault();


            var recId = (from c in context.Accounts_Recipes
                            where c.id_Account == accountID.id_Account
                            select c).ToArray();

            int tmp;

            for (int id = 0; id < recId.Count(); id++)
            {
                tmp = (int)recId[id].id_MyRecipes;

                context.MyRecipes.Where(c => c.id_myRecipe == tmp).Load();

               myRecipeViewSource.Source = context.MyRecipes.Local;
            }

        }

        private void Create_button_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            CreateRecipe window = new CreateRecipe();
            window.Show();



        }

        private void MyMeal_label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            Meals window = new Meals();
            window.Show();
        }
    }
}

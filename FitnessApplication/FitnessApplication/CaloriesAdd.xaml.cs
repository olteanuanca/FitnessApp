using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CaloriesAdd.xaml
    /// </summary>
    public partial class CaloriesAdd : Window
    {
        MyFitEntities context = new MyFitEntities();
        public int UserID;

        public CaloriesAdd()
        {
            InitializeComponent();

            MenuItems = new ObservableCollection<MenuItem>();
            for (int i = 0; i < 100; i++)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = i.ToString();
                MenuItems.Add(menuItem);
            }



            var c = (from s in context.Accounts
                     where s.Username == AuthentificationWindow.currentUsername
                     select s).First();
            UserID = c.id_Account;

        }
        
        public NutritionGoal NutritionGoal()
        {
            Account c1 = (from s in context.Accounts
                          where s.Username == AuthentificationWindow.currentUsername
                          select s).First();
            Goal c = (from s in context.Goals
                      where s.id_Goals == c1.id_Account_Goals
                      select s).First();

            NutritionGoal c2 = (from s in context.NutritionGoals
                                where s.id_NutritionGoals == c.id_Goals_Nutrition
                             select s).First();

            return c2;
        }


        public ObservableCollection<MenuItem> MenuItems
        {
            get;
            set;
        }

        private void Calories_TextChanged(object sender, TextChangedEventArgs e)
        {
            NutritionGoal().CaloriesPerDay = Convert.ToDouble(Calories.Text);
            context.SaveChanges();
        }

        private void Carbs_TextChanged(object sender, TextChangedEventArgs e)
        {
            NutritionGoal().CarbsPerDay = Convert.ToDouble(Carbs.Text);
            context.SaveChanges();

        }

        private void Prot_TextChanged(object sender, TextChangedEventArgs e)
        {
            NutritionGoal().ProteinPerDay = Convert.ToDouble(Prot.Text);
            context.SaveChanges();

        }

        private void Fat_TextChanged(object sender, TextChangedEventArgs e)
        {
            NutritionGoal().FatPerDay = Convert.ToDouble(Fat.Text);
            context.SaveChanges();

        }
    }
}

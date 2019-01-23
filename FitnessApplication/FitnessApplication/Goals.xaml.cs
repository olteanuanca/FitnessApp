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
    /// Interaction logic for Goals.xaml
    /// </summary>
    public partial class Goals : Window
    {
        public int UserID;
        public MyFitEntities context = new MyFitEntities();


        public Dictionary<int,string>ActiveStatus=new Dictionary<int, string>
        {
            {1, "Not very active"},
            {2,"Lightly active"},
            {3,"Active" },
            {4,"Very Active"}

        };


        public Goals()
        {
            InitializeComponent();
            var c = (from s in context.Accounts
                     where s.Username == AuthentificationWindow.currentUsername
                     select s).First();
            UserID = c.id_Account;


        }
        public WeightGoal getfromWG()
        {
            Account c1= (from s in context.Accounts
                         where s.Username == AuthentificationWindow.currentUsername
                         select s).First();
            Goal c = (from s in context.Goals
                     where s.id_Goals == c1.id_Account_Goals
                     select s).First();

            WeightGoal c2 = (from s in context.WeightGoals
                      where s.id_WeightGoals == c.id_Goals_WeightG
                      select s).First();

            return c2;
        }
        public FitnessGoal getfromFG()
        {
            Account c1 = (from s in context.Accounts
                          where s.Username == AuthentificationWindow.currentUsername
                          select s).First();
            Goal c = (from s in context.Goals
                      where s.id_Goals == c1.id_Account_Goals
                      select s).First();

            FitnessGoal f= (from s in context.FitnessGoals
                           where s.id_FitnessGoals == c.id_Goals_FitnessG
                           select s).First();

            return f;

        }
        private void Button_Click_StartingWeight(object sender, RoutedEventArgs e)
        {
            
            SWeight.Text = getfromWG().StartingWeight.ToString();
        }

        private void Button_Click_CurrentWeight(object sender, RoutedEventArgs e)
        {
           
            CWeight.Text = getfromWG().CurrentWeight.ToString();

        }
        private void Button_Click_GoalWeight(object sender, RoutedEventArgs e)

        {
            GWeight.Text = getfromWG().GoalWeight.ToString();
        }

        private void Button_Click_WeeklyGoal(object sender, RoutedEventArgs e)
        {
            WKGoal.Text = getfromWG().WeeklyGoal.ToString();
        }

        public int i;
        private void Button_Click_ActivityLevel(object sender, RoutedEventArgs e)
        {
            for (i = 0; i < 4; i++)
            {
                if (getfromWG().ActivityLevel == i + 1)
                {
                    Cmb.SelectedIndex = i + 1;
                    return;
                }
            }
        }
     

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            foreach(ComboBoxItem cb in Cmb.Items)
            {
                if (Cmb.SelectedItem.ToString() != ActiveStatus[i + 1])
                {
                    int j = 1;
                    foreach( var index in ActiveStatus.Values)
                    {
                        string s = Cmb.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();

                        if (index == s)
                            getfromWG().ActivityLevel = j;
                                j++;

                    }
                }
            }
            context.SaveChanges();
        }

        private void Button_Click_Calorie(object sender, RoutedEventArgs e)
        {
            CaloriesAdd c = new CaloriesAdd();
            c.ShowDialog();
        }

        private void SWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            getfromWG().StartingWeight = Convert.ToDouble(SWeight.Text);
         

        }

        private void CWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            getfromWG().CurrentWeight = Convert.ToDouble(CWeight.Text);
            context.SaveChanges();
        }

        private void GWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            getfromWG().GoalWeight = Convert.ToDouble(GWeight.Text);
            context.SaveChanges();
        }

        private void WKGoal_TextChanged(object sender, TextChangedEventArgs e)
        {
            getfromWG().WeeklyGoal = Convert.ToDouble(WKGoal.Text);
            context.SaveChanges();
        }

        private void Button_Click_Workout(object sender, RoutedEventArgs e)
        {
            getfromFG().WorkoutsPerWeek = Convert.ToInt32(Workout.Text);
            context.SaveChanges();

        }

        private void Button_Click_Minutes(object sender, RoutedEventArgs e)
        {
            getfromFG().MinutesPerWorkout = Convert.ToInt32(Minutes.Text);
            getfromFG().CaloriesPerWorkout = 10 * Convert.ToInt32(Minutes.Text);
            context.SaveChanges();



        }


    }

}

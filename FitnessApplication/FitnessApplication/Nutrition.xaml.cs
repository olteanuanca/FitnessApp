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
    
    public partial class Nutrition : Window
    {
        MyFitEntities context = new MyFitEntities();
        public static DateTime myDate;
        public static int isSet = 0;

        public static DateTime Getdate() { return myDate; }

        public Nutrition()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            if (isSet == 0)
            {
                CurrentDate.SelectedDate = DateTime.Today;
                myDate = DateTime.Today;
                isSet = 1;
            }
            else
            {
                CurrentDate.SelectedDate = myDate;
            }

            Account currentID = context.Accounts.Where(i => i.Username == AuthentificationWindow.currentUsername).SingleOrDefault();

            var DiaryId = context.Diaries.Where(c => c.id_Account == currentID.id_Account).ToList();

            int breakfastCalories = 0, lunchCalories = 0, dinnerCalories = 0, snackCalories = 0;


            for (int j = 0; j < DiaryId.Count(); j++)
            {
                int temp = (int)DiaryId[j].id_Diary_Entry;
                var DiaryEntryId = context.DiaryEntries.Where(c => c.id_DiaryEntry == temp).ToArray();

                int tmp, tmp2, tmp3,tmp4,tmp5;              
                for (int i = 0; i < DiaryEntryId.Count(); i++)
                {
                    if (DiaryEntryId[i].DiaryDate.ToShortDateString() == CurrentDate.SelectedDate.Value.Date.ToShortDateString())
                    {
                        tmp = (int)DiaryEntryId[i].id_DEntry_DBreakfast;
                        var breakfast=context.DiaryBreakfasts.Where(c => c.id_DiaryBreakfast == tmp).SingleOrDefault();
                        if(breakfast.Calories != null)
                        breakfastCalories = (int)breakfast.Calories;

                        tmp2 = (int)DiaryEntryId[i].id_DEntry_DLunch;
                        var lunch=context.DiaryLunches.Where(c => c.id_DiaryLunch == tmp2).SingleOrDefault();
                        if(lunch.Calories != null)
                        lunchCalories = (int)lunch.Calories;

                        tmp3 = (int)DiaryEntryId[i].id_DEntry_DDinner;
                        var dinner = context.DiaryDinners.Where(c => c.id_DiaryDinner == tmp3).SingleOrDefault();
                        if(dinner.Calories != null)
                        dinnerCalories = (int)dinner.Calories;

                        tmp4 = (int)DiaryEntryId[i].id_DEntry_DSnack1;
                        var snack1 = context.DiarySnack1.Where(c => c.id_DiarySnack1 == tmp4).SingleOrDefault();
                        if(snack1.Calories!=null)
                        snackCalories += (int)snack1.Calories;

                        tmp5 = (int)DiaryEntryId[i].id_DEntry_DSnack2;
                        var snack2 = context.DiarySnack2.Where(c => c.id_DiarySnack2 == tmp5).SingleOrDefault();
                        if(snack2.Calories != null)
                        snackCalories += (int)snack2.Calories;                      
                    }

                }

            }

            var GoalsId = context.Goals.Where(c => c.id_Goals == currentID.id_Account_Goals).SingleOrDefault();

            var NutritionGoalsId = context.NutritionGoals.Where(c => c.id_NutritionGoals == GoalsId.id_Goals_Nutrition).SingleOrDefault();

            int caloriesGoal = (int)NutritionGoalsId.CaloriesPerDay;

            int TotalCalories = breakfastCalories + lunchCalories + dinnerCalories + snackCalories;
            TotalCaloriesBox.Text = TotalCalories.ToString();
            GoalsBox.Text = caloriesGoal.ToString();

            float bc = Convert.ToSingle(breakfastCalories) / Convert.ToSingle( TotalCalories) * 100;
            BreakfastValue.Value =(int) bc;
            BreakfastCalories.Text = breakfastCalories.ToString();
            float lc = Convert.ToSingle(lunchCalories) / Convert.ToSingle(TotalCalories) * 100;
            LunchValue.Value = (int)lc;
            LunchCalories.Text = lunchCalories.ToString();
            float dc = Convert.ToSingle(dinnerCalories) / Convert.ToSingle(TotalCalories) * 100;
            DinnerValue.Value = (int)dc;
            DinnerCalories.Text = dinnerCalories.ToString();
            float sc = Convert.ToSingle(snackCalories) / Convert.ToSingle(TotalCalories) * 100;
            SnacksValue.Value = (int)sc;
            SnackCalories.Text = snackCalories.ToString();

        
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            myDate = CurrentDate.SelectedDate.Value.Date;
            Nutrition N = new Nutrition();
            N.Show();
            this.Close();
        }

        private void NutrientsButton_Click(object sender, RoutedEventArgs e)
        {
            Nutrients Nt = new Nutrients();
            Nt.Show();
            this.Close();
        }

        private void DiaryFoodButton_Click(object sender, RoutedEventArgs e)
        {
            DiaryFood df = new DiaryFood();
            df.Show();
            this.Close();
        }

        private void DiaryExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            DiaryExercise D = new DiaryExercise();
            D.Show();
            this.Close();
        }

        private void Friends_Click(object sender, RoutedEventArgs e)
        {
            FriendsMenuWindow friends = new FriendsMenuWindow();
            friends.Show();
            this.Close();
        }
    }
}

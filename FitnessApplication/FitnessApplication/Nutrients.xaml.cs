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
   
    public partial class Nutrients : Window
    {

        MyFitEntities context = new MyFitEntities();
        public static DateTime myDate;
        public static int isSet = 0;

        public static DateTime Getdate() { return myDate; }

        public Nutrients()
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
            int carbs = 0, fat = 0, protein = 0, cholesterol = 0, fiber = 0, sugar = 0, sodium = 0, potassium = 0, vitA = 0, vitC = 0, calcium = 0, iron = 0;

            for (int j = 0; j < DiaryId.Count(); j++)
            {                
                int temp = (int)DiaryId[j].id_Diary_Entry;
                var DiaryEntryId = context.DiaryEntries.Where(c => c.id_DiaryEntry == temp).ToArray();

                for (int i = 0; i < DiaryEntryId.Count(); i++)
                {
                    if (DiaryEntryId[i].DiaryDate.ToShortDateString() == CurrentDate.SelectedDate.Value.Date.ToShortDateString())
                    {
                        int tmp = (int)DiaryEntryId[i].id_DEntry_DBreakfast;
                        var breakfast = context.DiaryBreakfasts.Where(c => c.id_DiaryBreakfast == tmp).SingleOrDefault();
                        if (breakfast.Carbs != null)
                            carbs += (int)breakfast.Carbs;
                        if (breakfast.Protein != null)
                            protein += (int)breakfast.Protein;
                        if (breakfast.Fat != null)
                            fat += (int)breakfast.Fat;
                        if (breakfast.Fiber != null)
                            fiber += (int)breakfast.Fiber;
                        if (breakfast.Sodium != null)
                            sodium += (int)breakfast.Sodium;
                        if (breakfast.Potassium != null)
                            potassium += (int)breakfast.Potassium;
                        if (breakfast.VitA != null)
                            vitA += (int)breakfast.VitA;
                        if (breakfast.VitC != null)
                            vitC += (int)breakfast.VitC;
                        if (breakfast.Calcium != null)
                            calcium += (int)breakfast.Calcium;
                        if (breakfast.Iron != null)
                            iron += (int)breakfast.Iron;
                        if (breakfast.Sugars != null)
                            sugar += (int)breakfast.Sugars;
                        if (breakfast.Cholesterol != null)
                            cholesterol += (int)breakfast.Cholesterol; 

                        int tmp2 = (int)DiaryEntryId[i].id_DEntry_DLunch;
                        var lunch = context.DiaryLunches.Where(c => c.id_DiaryLunch == tmp2).SingleOrDefault();
                        if (lunch.Carbs != null)
                            carbs += (int)lunch.Carbs;
                        if (lunch.Protein != null)
                            protein += (int)lunch.Protein;
                        if (lunch.Fat != null)
                            fat += (int)lunch.Fat;
                        if (lunch.Fiber != null)
                            fiber += (int)lunch.Fiber;
                        if (lunch.Sodium != null)
                            sodium += (int)lunch.Sodium;
                        if (lunch.Potassium != null)
                            potassium += (int)lunch.Potassium;
                        if (lunch.VitA != null)
                            vitA += (int)lunch.VitA;
                        if (lunch.VitC != null)
                            vitC += (int)lunch.VitC;
                        if (lunch.Calcium != null)
                            calcium += (int)lunch.Calcium;
                        if (lunch.Iron != null)
                            iron += (int)lunch.Iron;
                        if (lunch.Sugars != null)
                            sugar += (int)lunch.Sugars;
                        if (lunch.Cholesterol != null)
                            cholesterol += (int)lunch.Cholesterol;

                        int tmp3 = (int)DiaryEntryId[i].id_DEntry_DDinner;
                        var dinner = context.DiaryDinners.Where(c => c.id_DiaryDinner == tmp3).SingleOrDefault();
                        if (dinner.Carbs != null)
                            carbs += (int)dinner.Carbs;
                        if (dinner.Protein != null)
                            protein += (int)dinner.Protein;
                        if (dinner.Fat != null)
                            fat += (int)dinner.Fat;
                        if (dinner.Fiber != null)
                            fiber += (int)dinner.Fiber;
                        if (dinner.Sodium != null)
                            sodium += (int)dinner.Sodium;
                        if (dinner.Potassium != null)
                            potassium += (int)dinner.Potassium;
                        if (dinner.VitA != null)
                            vitA += (int)dinner.VitA;
                        if (dinner.VitC != null)
                            vitC += (int)dinner.VitC;
                        if (dinner.Calcium != null)
                            calcium += (int)dinner.Calcium;
                        if (dinner.Iron != null)
                            iron += (int)dinner.Iron;
                        if (dinner.Sugars != null)
                            sugar += (int)dinner.Sugars;
                        if (dinner.Cholesterol != null)
                            cholesterol += (int)dinner.Cholesterol;

                        int tmp4 = (int)DiaryEntryId[i].id_DEntry_DSnack1;
                        var snack1 = context.DiarySnack1.Where(c => c.id_DiarySnack1 == tmp4).SingleOrDefault();
                        if (snack1.Carbs != null)
                            carbs += (int)snack1.Carbs;
                        if (snack1.Protein != null)
                            protein += (int)snack1.Protein;
                        if (snack1.Fat != null)
                            fat += (int)snack1.Fat;
                        if (snack1.Fiber != null)
                            fiber += (int)snack1.Fiber;
                        if (snack1.Sodium != null)
                            sodium += (int)snack1.Sodium;
                        if (snack1.Potassium != null)
                            potassium += (int)snack1.Potassium;
                        if (snack1.VitA != null)
                            vitA += (int)snack1.VitA;
                        if (snack1.VitC != null)
                            vitC += (int)snack1.VitC;
                        if (snack1.Calcium != null)
                            calcium += (int)snack1.Calcium;
                        if (snack1.Iron != null)
                            iron += (int)snack1.Iron;
                        if (snack1.Sugars != null)
                            sugar += (int)snack1.Sugars;
                        if (snack1.Cholesterol != null)
                            cholesterol += (int)snack1.Cholesterol;

                        int tmp5 = (int)DiaryEntryId[i].id_DEntry_DSnack2;
                        var snack2 = context.DiarySnack2.Where(c => c.id_DiarySnack2 == tmp5).SingleOrDefault();
                        if (snack2.Carbs != null)
                            carbs += (int)snack2.Carbs;
                        if (snack2.Protein != null)
                            protein += (int)snack2.Protein;
                        if (snack2.Fat != null)
                            fat += (int)snack2.Fat;
                        if (snack2.Fiber != null)
                            fiber += (int)snack2.Fiber;
                        if (snack2.Sodium != null)
                            sodium += (int)snack2.Sodium;
                        if (snack2.Potassium != null)
                            potassium += (int)snack2.Potassium;
                        if (snack2.VitA != null)
                            vitA += (int)snack2.VitA;
                        if (snack2.VitC != null)
                            vitC += (int)snack2.VitC;
                        if (snack2.Calcium != null)
                            calcium += (int)snack2.Calcium;
                        if (snack2.Iron != null)
                            iron += (int)snack2.Iron;
                        if (snack2.Sugars != null)
                            sugar += (int)snack2.Sugars;
                        if (snack2.Cholesterol != null)
                            cholesterol += (int)snack2.Cholesterol;
                    }

                }

            }

            TotalCarbs.Text = carbs.ToString();
            TotalCholesterol.Text = cholesterol.ToString();
            TotalFat.Text = fat.ToString();
            TotalFiber.Text = fiber.ToString();
            TotalPotassium.Text = potassium.ToString();
            TotalProtein.Text = protein.ToString();
            TotalSodium.Text = sodium.ToString();
            TotalSugar.Text = sugar.ToString();
            TotalVitA.Text = vitA.ToString();
            TotalVitC.Text = vitC.ToString();
            TotalCalcium.Text = calcium.ToString();
            TotalIron.Text = iron.ToString();

            var GoalsId = context.Goals.Where(c => c.id_Goals == currentID.id_Account_Goals).SingleOrDefault();

            var NutritionGoalsId = context.NutritionGoals.Where(c => c.id_NutritionGoals == GoalsId.id_Goals_Nutrition).SingleOrDefault();

            GoalCarbs.Text = NutritionGoalsId.CarbsPerDay.ToString();
            GoalCholesterol.Text = NutritionGoalsId.CholesterolPerDay.ToString();
            GoalFat.Text = NutritionGoalsId.FatPerDay.ToString();
            GoalFiber.Text = NutritionGoalsId.FiberPerDay.ToString();
            GoalPotassium.Text = NutritionGoalsId.PotassiumPerDay.ToString();
            GoalProtein.Text = NutritionGoalsId.ProteinPerDay.ToString();
            GoalSodium.Text = NutritionGoalsId.SodiumPerDay.ToString();
            GoalSugar.Text = NutritionGoalsId.SugarsPerDay.ToString();
            GoalVitA.Text = NutritionGoalsId.VitAPerDay.ToString();
            GoalVitC.Text = NutritionGoalsId.VitCPerDay.ToString();
            GoalCalcium.Text = NutritionGoalsId.CalciumPerDay.ToString();
            GoalIron.Text = NutritionGoalsId.IronPerDay.ToString();

            LeftCarbs.Text = (Int32.Parse(GoalCarbs.Text) - carbs).ToString();
            LeftCholesterol.Text = (Int32.Parse(GoalCholesterol.Text) - cholesterol).ToString();
            LeftFat.Text = (Int32.Parse(GoalFat.Text) - fat).ToString();
            LeftFiber.Text = (Int32.Parse(GoalFiber.Text) - fiber).ToString();
            LeftPotassium.Text = (Int32.Parse(GoalPotassium.Text) - potassium).ToString();
            LeftProtein.Text = (Int32.Parse(GoalProtein.Text) - protein).ToString();
            LeftSodium.Text = (Int32.Parse(GoalSodium.Text) - sodium).ToString();
            LeftSugar.Text = (Int32.Parse(GoalSugar.Text) - sugar).ToString();
            LeftVitA.Text = (Int32.Parse(GoalVitA.Text) - vitA).ToString();
            LeftVitC.Text = (Int32.Parse(GoalVitC.Text) - vitC).ToString();
            LeftCalcium.Text = (Int32.Parse(GoalCalcium.Text) - calcium).ToString();
            LeftIron.Text = (Int32.Parse(GoalIron.Text) - iron).ToString();


            CarbsBar.Maximum = Int32.Parse(GoalCarbs.Text);
            CholesterolBar.Maximum = Int32.Parse(GoalCholesterol.Text);
            FatBar.Maximum = Int32.Parse(GoalFat.Text);
            FiberBar.Maximum = Int32.Parse(GoalFiber.Text);
            PotassiumBar.Maximum = Int32.Parse(GoalPotassium.Text);
            ProteinBar.Maximum = Int32.Parse(GoalProtein.Text);
            SodiumBar.Maximum = Int32.Parse(GoalSodium.Text);
            SugarBar.Maximum = Int32.Parse(GoalSugar.Text);
            VitABar.Maximum = Int32.Parse(GoalVitA.Text);
            VitCBar.Maximum = Int32.Parse(GoalVitC.Text);
            CalciumBar.Maximum = Int32.Parse(GoalCalcium.Text);
            IronBar.Maximum = Int32.Parse(GoalIron.Text);

            CarbsBar.Value = carbs;
            CholesterolBar.Value = cholesterol;
            FatBar.Value = fat;
            FiberBar.Value = fiber;
            PotassiumBar.Value = potassium;
            ProteinBar.Value = protein;
            SodiumBar.Value = sodium;
            SugarBar.Value = sugar;
            VitABar.Value = vitA;
            VitCBar.Value = vitC;
            CalciumBar.Value = calcium;
            IronBar.Value = iron;



        }

        private void NutritionButton_Click(object sender, RoutedEventArgs e)
        {
            Nutrition N = new Nutrition();
            N.Show();
            this.Close();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            myDate = CurrentDate.SelectedDate.Value.Date;
            Nutrients N = new Nutrients();
            N.Show();
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

        private void GoToNutritionButton_Click(object sender, RoutedEventArgs e)
        {
            Nutrition N = new Nutrition();
            N.Show();
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

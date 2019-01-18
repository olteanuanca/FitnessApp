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
  
    public partial class NewAccountWindow2 : Window
    {
        public NewAccountWindow2()
        {
            InitializeComponent();


        }

        private void Countinue_button_Click(object sender, RoutedEventArgs e)
        {
            int temp;
            if (Sedentary_rbutton.IsChecked == true)
                temp = 1;
            else if (LightlyActive_rbutton.IsChecked == true)
                temp =2;
            else if (Active_rbutton.IsChecked == true)
                temp = 3;
            else
                temp = 4;

            var context = new MyFitEntities();
            
            var WeightGoals = new WeightGoal
            {
                StartingWeight = Convert.ToDouble(StartingWeight_textbox.Text),
                CurrentWeight = Convert.ToDouble(StartingWeight_textbox.Text),
                GoalWeight = Convert.ToDouble(GoalWeight_textbox.Text),
                WeeklyGoal = Convert.ToDouble(WeeklyGoal_textbox.Text),
                ActivityLevel = temp,
            };

            context.WeightGoals.Add(WeightGoals);
            context.SaveChanges();

            var BreakfastGoals = new BreakfastGoal
            {
                Calories = 0,
                Carbs = 0,
                Protein = 0,
                Fat = 0,
                Cholesterol = 0,
                Sodium = 0,
                Potassium = 0,
                Fiber = 0,
                Sugars = 0,
                VitA = 0,
                VitC = 0,
                Calcium = 0,
                Iron = 0,
            };

            context.BreakfastGoals.Add(BreakfastGoals);
            context.SaveChanges();

            var Snack1Goals = new Snack1Goals
            {
                Calories = 0,
                Carbs=0,
                Protein=0,
                Fat=0,
                Cholesterol=0,
                Sodium=0,
                Potassium=0,
                Fiber=0,
                Sugars=0,
                VitA=0,
                VitC=0,
                Calcium=0,
                Iron=0,
            };

            context.Snack1Goals.Add(Snack1Goals);
            context.SaveChanges();

            var LunchGoals = new LunchGoal
            {
                Calories = 0,
                Carbs = 0,
                Protein = 0,
                Fat = 0,
                Cholesterol = 0,
                Sodium = 0,
                Potassium = 0,
                Fiber = 0,
                Sugars = 0,
                VitA = 0,
                VitC = 0,
                Calcium = 0,
                Iron = 0,
            };

            context.LunchGoals.Add(LunchGoals);
            context.SaveChanges();

            var Snack2Goals = new Snack2Goals
            {
                Calories = 0,
                Carbs = 0,
                Protein = 0,
                Fat = 0,
                Cholesterol = 0,
                Sodium = 0,
                Potassium = 0,
                Fiber = 0,
                Sugars = 0,
                VitA = 0,
                VitC = 0,
                Calcium = 0,
                Iron = 0,
            };

            context.Snack2Goals.Add(Snack2Goals);
            context.SaveChanges();

            var DinnerGoals = new DinnerGoal
            {
                Calories = 0,
                Carbs = 0,
                Protein = 0,
                Fat = 0,
                Cholesterol = 0,
                Sodium = 0,
                Potassium = 0,
                Fiber = 0,
                Sugars = 0,
                VitA = 0,
                VitC = 0,
                Calcium = 0,
                Iron = 0,
            };

            context.DinnerGoals.Add(DinnerGoals);
            context.SaveChanges();

            var id = context.BreakfastGoals.Max(i => i.id_Breakfast);
            var id18= context.Snack1Goals.Max(i => i.id_Snack1);
            var id19= context.LunchGoals.Max(i => i.id_Lunch);
            var id20= context.Snack2Goals.Max(i => i.id_Snack2);
            var id21= context.DinnerGoals.Max(i => i.id_Dinner);

            var MealGoals = new MealGoal
            {
                id_BreakfastG_MealG =id,
                id_Snack1G_MealG=id18,
                id_LunchG_MealG=id19,
                id_Snack2G_MealG=id20,
                id_DinnerG_MealG=id21,
            };

            context.MealGoals.Add(MealGoals);
            context.SaveChanges();

            var id2 = context.MealGoals.Max(i => i.id_MealGoals);
            var NutritionGoals = new NutritionGoal
            {
                id_NutritionG_MealG=id,
                CaloriesPerDay=0,
                CarbsPerDay=0,
                ProteinPerDay=0,
                FatPerDay=0,
                CholesterolPerDay=0,
                SodiumPerDay=0,
                PotassiumPerDay=0,
                FiberPerDay=0,
                SugarsPerDay=0,
                VitAPerDay=0,
                VitCPerDay=0,
                CalciumPerDay=0,
                IronPerDay=0,
            };

            context.NutritionGoals.Add(NutritionGoals);
            context.SaveChanges();

            var FitnessGoals = new FitnessGoal
            {
                WorkoutsPerWeek = Convert.ToInt32(WorkoutsperWeek_textbox.Text),
                MinutesPerWorkout=Convert.ToInt32(MinutesperWeek_textbox.Text),
                CaloriesPerWorkout= Convert.ToInt32(CaloriesperWorkout_textbox.Text),

            };

            context.FitnessGoals.Add(FitnessGoals);
            context.SaveChanges();

            var id3 = context.FitnessGoals.Max(i => i.id_FitnessGoals);
            var id22= context.NutritionGoals.Max(i => i.id_NutritionGoals);
            var id23 = context.WeightGoals.Max(i => i.id_WeightGoals);

            var Goals = new Goal
            {
                id_Goals_FitnessG=id3,
                id_Goals_Nutrition=id22,
                id_Goals_WeightG=id23,

            };

            context.Goals.Add(Goals);
            context.SaveChanges();

          
            var Progress = new Progress
            {
                pDate=DateTime.Now,
                pWeight=0,
                pWaist=0,
                pHips=0,
                pLegs=0,
                pBut=0,
                pPhoto=null,

            };
            context.Progresses.Add(Progress);
            context.SaveChanges();

          var DiaryBreakfast = new DiaryBreakfast
            {
                Name="null",
                Calories=0,
                Carbs = 0,
                Protein = 0,
                Fat = 0,
                Cholesterol = 0,
                Sodium = 0,
                Potassium = 0,
                Fiber = 0,
                Sugars = 0,
                VitA = 0,
                VitC = 0,
                Calcium = 0,
                Iron = 0,

            };
            context.DiaryBreakfasts.Add(DiaryBreakfast);
            context.SaveChanges();

            var DiarySnack1 = new DiarySnack1
            {
                Name = "null",
                Calories = 0,
                Carbs = 0,
                Protein = 0,
                Fat = 0,
                Cholesterol = 0,
                Sodium = 0,
                Potassium = 0,
                Fiber = 0,
                Sugars = 0,
                VitA = 0,
                VitC = 0,
                Calcium = 0,
                Iron = 0,

            };
            context.DiarySnack1.Add(DiarySnack1);
            context.SaveChanges();

            var DiarySnack2 = new DiarySnack2
            {
                Name = "null",
                Calories = 0,
                Carbs = 0,
                Protein = 0,
                Fat = 0,
                Cholesterol = 0,
                Sodium = 0,
                Potassium = 0,
                Fiber = 0,
                Sugars = 0,
                VitA = 0,
                VitC = 0,
                Calcium = 0,
                Iron = 0,

            };
            context.DiarySnack2.Add(DiarySnack2);
            context.SaveChanges();

            var DiaryLunch = new DiaryLunch
            {
                Name = "null",
                Calories = 0,
                Carbs = 0,
                Protein = 0,
                Fat = 0,
                Cholesterol = 0,
                Sodium = 0,
                Potassium = 0,
                Fiber = 0,
                Sugars = 0,
                VitA = 0,
                VitC = 0,
                Calcium = 0,
                Iron = 0,

            };
            
            context.DiaryLunches.Add(DiaryLunch);
            context.SaveChanges();

            var DiaryDinner = new DiaryDinner
            {
                Name = "null",
                Calories = 0,
                Carbs = 0,
                Protein = 0,
                Fat = 0,
                Cholesterol = 0,
                Sodium = 0,
                Potassium = 0,
                Fiber = 0,
                Sugars = 0,
                VitA = 0,
                VitC = 0,
                Calcium = 0,
                Iron = 0,

            };

            context.DiaryDinners.Add(DiaryDinner);
            context.SaveChanges();

            var DiaryCardio = new DiaryCardio
            {
                Cardio_Description = "null",
                Duration_min = 0,
                Calories_burned = 0,

            };
            
            context.DiaryCardios.Add(DiaryCardio);
            context.SaveChanges();

            var DiaryStrength = new DiaryStrength
            {
                NbOfSets = 0,
                RepsPerSet = 0,
                WeightPerRep = 0,
                Calories_burned = 0,
                Strength_Description = "null",

            };

            context.DiaryStrengths.Add(DiaryStrength);
            context.SaveChanges();

            var DiaryWater = new DiaryWater
            {
                Quantity_ml=0,

            };

            context.DiaryWaters.Add(DiaryWater);
            context.SaveChanges();

            var DiaryNotes = new DiaryNote
            {
              Note = "null",
              NoteType="null",

            };

            context.DiaryNotes.Add(DiaryNotes);
            context.SaveChanges();

           var id4 = context.DiaryBreakfasts.Max(i => i.id_DiaryBreakfast);
            var id5 = context.DiarySnack1.Max(i => i.id_DiarySnack1);
            var id6 = context.DiarySnack2.Max(i => i.id_DiarySnack2);
            var id7 = context.DiaryLunches.Max(i => i.id_DiaryLunch);
            var id8 = context.DiaryDinners.Max(i => i.id_DiaryDinner);
            var id9 = context.DiaryCardios.Max(i => i.id_DiaryCardio);
            var id10 = context.DiaryWaters.Max(i => i.id_DiaryWater);
            var id11 = context.DiaryNotes.Max(i => i.id_DiaryNotes);
            var id12 = context.DiaryStrengths.Max(i => i.id_DiaryStrength);


            var DiaryEntry = new DiaryEntry
            {
                DiaryDate = DateTime.Now,
                id_DEntry_DBreakfast = id4,
                id_DEntry_DSnack1=id5,
                id_DEntry_DSnack2=id6,
                id_DEntry_DLunch=id7,
                id_DEntry_DDinner=id8,
                id_DEntry_DCardio=id9,
                id_DEntry_DWater=id10,
                id_DEntry_DNotes=id11,
                id_DEntry_DStrength=id12,

            };

            context.DiaryEntries.Add(DiaryEntry);
            context.SaveChanges();

            var id13 = context.DiaryEntries.Max(i => i.id_DiaryEntry);

            var Diary = new Diary
            {
               id_Diary_Entry=id13,
            };

            context.Diaries.Add(Diary);
            context.SaveChanges();

            NewAccountWindow1 w1 = new NewAccountWindow1();
            var temp1 = Convert.ToDateTime(BirthDate_textbox.Text).ToString("yyyy-MM-dd");


           String temp3;

            if (Male_rbutton.IsChecked == true)
                temp3 = "Male";
            else
                temp3 = "Female";


            var id14 = context.Diaries.Max(i => i.id_Diary);
            var id15 = context.Goals.Max(i => i.id_Goals);
            var id16 = context.AccountCredentials.Max(i => i.id_AccCredentials);
            var id17 = context.Progresses.Max(i => i.id_Progress);

            
            var Accounts = new Account
            {
                FirstName= NewAccountWindow1.FName,
                LastName = NewAccountWindow1.LName,
                BirthDate= Convert.ToDateTime(temp1),
                Age=DateTime.Now.Year- Convert.ToDateTime(temp1).Year,
                Height=Convert.ToDouble(Height_textbox.Text),
                Email = NewAccountWindow1.EmAdress,
                Gender=temp3,
                Photo=NewAccountWindow1.binImage,
                id_Account_Diary=id14,
                id_Account_Goals=id15,
                id_Account_AccountCredentials=id16,
                id_Account_Progress=id17,
                Username=NewAccountWindow1.Username,
            };

            context.Accounts.Add(Accounts);
            context.SaveChanges();



            this.Close();
            NewAccountWindow3 window = new NewAccountWindow3();
             window.Show();


        }
    }
}

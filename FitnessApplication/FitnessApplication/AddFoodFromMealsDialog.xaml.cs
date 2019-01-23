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
    /// Interaction logic for AddFoodFromMealsDialog.xaml
    /// </summary>

    public partial class AddFoodFromMealsDialog : Window
    {
        MyFitEntities context = new MyFitEntities();
        System.Windows.Data.CollectionViewSource myMealViewSource;

        public AddFoodFromMealsDialog()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            myMealViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("myMealViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            Account currentID = context.Accounts.Where(i => i.Username == AuthentificationWindow.currentUsername).SingleOrDefault();

            var Acc_Meal_Id = context.Accounts_Meals.Where(c => c.id_Account == currentID.id_Account).ToList();

            for (int j = 0; j < Acc_Meal_Id.Count(); j++)
            {
                int temp = (int)Acc_Meal_Id[j].id_Meals;
                context.MyMeals.Where(c => c.id_myMeal == temp).Load();
                myMealViewSource.Source = context.MyMeals.Local;

            }
             
        }

        private void myMealDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var meal = myMealDataGrid.SelectedItem as MyMeal;
            SelectBox.Text = meal.Name.ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string TimeOfDay = TimeOfDayBox.Text.ToString();
            string servings = ServingsBox.Text.ToString();
            int nbOfServings = Int32.Parse(servings);
            string selectedFood = SelectBox.Text.ToString();

            List<MyMeal> meals = context.MyMeals.ToList();

            for (int i = 0; i < meals.Count(); i++)
                if (meals[i].Name.ToString().Contains(selectedFood))
                {
                    Account currentID = context.Accounts.Where(c => c.Username == AuthentificationWindow.currentUsername).SingleOrDefault();

                    var DiaryId = context.Diaries.Where(c => c.id_Account == currentID.id_Account).ToList();

                    int found = 0;

                    for (int j = 0; j < DiaryId.Count(); j++)
                    {
                        int temp = (int)DiaryId[j].id_Diary_Entry;
                        var DiaryEntryId = context.DiaryEntries.Where(c => c.id_DiaryEntry == temp).ToArray();

                        int tmp;
                        for (int k = 0; k < DiaryEntryId.Count(); k++)
                        {
                            //DiaryFood DF = new DiaryFood();
                            if (DiaryEntryId[k].DiaryDate.ToShortDateString() == DiaryFood.Getdate().ToShortDateString())
                            {
                                found = 1;
                                if (TimeOfDay == "Breakfast")
                                {
                                    tmp = (int)DiaryEntryId[k].id_DEntry_DBreakfast;
                                    DiaryBreakfast breakfast = context.DiaryBreakfasts.Where(c => c.id_DiaryBreakfast == tmp).FirstOrDefault();
                                    MyMeal I = meals[i];
                                    breakfast.Name = I.Name;
                                    breakfast.Calories = I.Calories * nbOfServings;
                                    breakfast.Carbs = I.Carbs * nbOfServings;
                                    breakfast.Protein = I.Protein * nbOfServings;
                                    breakfast.Fat = I.Fat * nbOfServings;
                                    breakfast.Cholesterol = I.Cholesterol * nbOfServings;
                                    breakfast.Sodium = I.Sodium * nbOfServings;
                                    breakfast.Potassium = I.Potassium * nbOfServings;
                                    breakfast.Fiber = I.Potassium * nbOfServings;
                                    breakfast.Sugars = I.Sugars * nbOfServings;
                                    breakfast.VitA = I.VitA * nbOfServings;
                                    breakfast.VitC = I.VitC * nbOfServings;
                                    breakfast.Calcium = I.Calcium * nbOfServings;
                                    breakfast.Iron = I.Iron * nbOfServings;

                                    context.SaveChanges();
                                }
                                else if (TimeOfDay == "Lunch")
                                {
                                    tmp = (int)DiaryEntryId[k].id_DEntry_DLunch;
                                    DiaryLunch lunch = context.DiaryLunches.Where(c => c.id_DiaryLunch == tmp).FirstOrDefault();
                                    MyMeal I = meals[i];
                                    lunch.Name = I.Name;
                                    lunch.Calories = I.Calories * nbOfServings;
                                    lunch.Carbs = I.Carbs * nbOfServings;
                                    lunch.Protein = I.Protein * nbOfServings;
                                    lunch.Fat = I.Fat * nbOfServings;
                                    lunch.Cholesterol = I.Cholesterol * nbOfServings;
                                    lunch.Sodium = I.Sodium * nbOfServings;
                                    lunch.Potassium = I.Potassium * nbOfServings;
                                    lunch.Fiber = I.Potassium * nbOfServings;
                                    lunch.Sugars = I.Sugars * nbOfServings;
                                    lunch.VitA = I.VitA * nbOfServings;
                                    lunch.VitC = I.VitC * nbOfServings;
                                    lunch.Calcium = I.Calcium * nbOfServings;
                                    lunch.Iron = I.Iron * nbOfServings;

                                    context.SaveChanges();
                                }

                                else if (TimeOfDay == "Dinner")
                                {
                                    tmp = (int)DiaryEntryId[k].id_DEntry_DDinner;
                                    DiaryDinner dinner = context.DiaryDinners.Where(c => c.id_DiaryDinner == tmp).FirstOrDefault();
                                    MyMeal I = meals[i];
                                    dinner.Name = I.Name;
                                    dinner.Calories = I.Calories * nbOfServings;
                                    dinner.Carbs = I.Carbs * nbOfServings;
                                    dinner.Protein = I.Protein * nbOfServings;
                                    dinner.Fat = I.Fat * nbOfServings;
                                    dinner.Cholesterol = I.Cholesterol * nbOfServings;
                                    dinner.Sodium = I.Sodium * nbOfServings;
                                    dinner.Potassium = I.Potassium * nbOfServings;
                                    dinner.Fiber = I.Potassium * nbOfServings;
                                    dinner.Sugars = I.Sugars * nbOfServings;
                                    dinner.VitA = I.VitA * nbOfServings;
                                    dinner.VitC = I.VitC * nbOfServings;
                                    dinner.Calcium = I.Calcium * nbOfServings;
                                    dinner.Iron = I.Iron * nbOfServings;

                                    context.SaveChanges();
                                }
                                else if (TimeOfDay == "Snack1")
                                {
                                    tmp = (int)DiaryEntryId[k].id_DEntry_DLunch;
                                    DiarySnack1 snack1 = context.DiarySnack1.Where(c => c.id_DiarySnack1 == tmp).FirstOrDefault();
                                    MyMeal I = meals[i];
                                    snack1.Name = I.Name;
                                    snack1.Calories = I.Calories * nbOfServings;
                                    snack1.Carbs = I.Carbs * nbOfServings;
                                    snack1.Protein = I.Protein * nbOfServings;
                                    snack1.Fat = I.Fat * nbOfServings;
                                    snack1.Cholesterol = I.Cholesterol * nbOfServings;
                                    snack1.Sodium = I.Sodium * nbOfServings;
                                    snack1.Potassium = I.Potassium * nbOfServings;
                                    snack1.Fiber = I.Potassium * nbOfServings;
                                    snack1.Sugars = I.Sugars * nbOfServings;
                                    snack1.VitA = I.VitA * nbOfServings;
                                    snack1.VitC = I.VitC * nbOfServings;
                                    snack1.Calcium = I.Calcium * nbOfServings;
                                    snack1.Iron = I.Iron * nbOfServings;

                                    context.SaveChanges();
                                }
                                else if (TimeOfDay == "Snack2")
                                {
                                    tmp = (int)DiaryEntryId[k].id_DEntry_DLunch;
                                    DiarySnack2 snack2 = context.DiarySnack2.Where(c => c.id_DiarySnack2 == tmp).FirstOrDefault();
                                    MyMeal I = meals[i];
                                    snack2.Name = I.Name;
                                    snack2.Calories = I.Calories * nbOfServings;
                                    snack2.Carbs = I.Carbs * nbOfServings;
                                    snack2.Protein = I.Protein * nbOfServings;
                                    snack2.Fat = I.Fat * nbOfServings;
                                    snack2.Cholesterol = I.Cholesterol * nbOfServings;
                                    snack2.Sodium = I.Sodium * nbOfServings;
                                    snack2.Potassium = I.Potassium * nbOfServings;
                                    snack2.Fiber = I.Potassium * nbOfServings;
                                    snack2.Sugars = I.Sugars * nbOfServings;
                                    snack2.VitA = I.VitA * nbOfServings;
                                    snack2.VitC = I.VitC * nbOfServings;
                                    snack2.Calcium = I.Calcium * nbOfServings;
                                    snack2.Iron = I.Iron * nbOfServings;

                                    context.SaveChanges();
                                }
                            }


                        }

                    }

                    if (found == 0)
                    {
                        MyMeal I = meals[i];
                        if (TimeOfDay == "Breakfast")
                        {
                            DiaryBreakfast breakfast = new DiaryBreakfast()
                            {
                                Name = I.Name,
                                Calories = I.Calories * nbOfServings,
                                Carbs = I.Carbs * nbOfServings,
                                Protein = I.Protein * nbOfServings,
                                Fat = I.Fat * nbOfServings,
                                Cholesterol = I.Cholesterol * nbOfServings,
                                Sodium = I.Sodium * nbOfServings,
                                Potassium = I.Potassium * nbOfServings,
                                Fiber = I.Potassium * nbOfServings,
                                Sugars = I.Sugars * nbOfServings,
                                VitA = I.VitA * nbOfServings,
                                VitC = I.VitC * nbOfServings,
                                Calcium = I.Calcium * nbOfServings,
                                Iron = I.Iron * nbOfServings
                            };
                            var lunch = new DiaryLunch();
                            var dinner = new DiaryDinner();
                            var snack1 = new DiarySnack1();
                            var snack2 = new DiarySnack2();
                            var cardio = new DiaryCardio();
                            var strength = new DiaryStrength();
                            var water = new DiaryWater();
                            var note = new DiaryNote();


                            context.DiaryBreakfasts.Add(breakfast);
                            context.DiaryLunches.Add(lunch);
                            context.DiaryDinners.Add(dinner);
                            context.DiarySnack1.Add(snack1);
                            context.DiarySnack2.Add(snack2);
                            context.DiaryCardios.Add(cardio);
                            context.DiaryStrengths.Add(strength);
                            context.DiaryWaters.Add(water);
                            context.DiaryNotes.Add(note);
                            context.SaveChanges();
                            var diaryentry = new DiaryEntry()
                            {
                                id_DEntry_DBreakfast = breakfast.id_DiaryBreakfast,
                                DiaryDate = DiaryFood.Getdate(),
                                id_DEntry_DLunch = lunch.id_DiaryLunch,
                                id_DEntry_DDinner = dinner.id_DiaryDinner,
                                id_DEntry_DCardio = cardio.id_DiaryCardio,
                                id_DEntry_DNotes = note.id_DiaryNotes,
                                id_DEntry_DSnack1 = snack1.id_DiarySnack1,
                                id_DEntry_DSnack2 = snack2.id_DiarySnack2,
                                id_DEntry_DStrength = strength.id_DiaryStrength,
                                id_DEntry_DWater = water.id_DiaryWater
                            };
                            context.DiaryEntries.Add(diaryentry);
                            context.SaveChanges();

                            var diary = new Diary()
                            {
                                id_Account = currentID.id_Account,
                                id_Diary_Entry = diaryentry.id_DiaryEntry
                            };
                            context.Diaries.Add(diary);
                            context.SaveChanges();
                        }

                        else if (TimeOfDay == "Lunch")
                        {
                            DiaryLunch lunch = new DiaryLunch()
                            {
                                Name = I.Name,
                                Calories = I.Calories * nbOfServings,
                                Carbs = I.Carbs * nbOfServings,
                                Protein = I.Protein * nbOfServings,
                                Fat = I.Fat * nbOfServings,
                                Cholesterol = I.Cholesterol * nbOfServings,
                                Sodium = I.Sodium * nbOfServings,
                                Potassium = I.Potassium * nbOfServings,
                                Fiber = I.Potassium * nbOfServings,
                                Sugars = I.Sugars * nbOfServings,
                                VitA = I.VitA * nbOfServings,
                                VitC = I.VitC * nbOfServings,
                                Calcium = I.Calcium * nbOfServings,
                                Iron = I.Iron * nbOfServings
                            };
                            var breakfast = new DiaryBreakfast();
                            var dinner = new DiaryDinner();
                            var snack1 = new DiarySnack1();
                            var snack2 = new DiarySnack2();
                            var cardio = new DiaryCardio();
                            var strength = new DiaryStrength();
                            var water = new DiaryWater();
                            var note = new DiaryNote();


                            context.DiaryBreakfasts.Add(breakfast);
                            context.DiaryLunches.Add(lunch);
                            context.DiaryDinners.Add(dinner);
                            context.DiarySnack1.Add(snack1);
                            context.DiarySnack2.Add(snack2);
                            context.DiaryCardios.Add(cardio);
                            context.DiaryStrengths.Add(strength);
                            context.DiaryWaters.Add(water);
                            context.DiaryNotes.Add(note);
                            context.SaveChanges();
                            var diaryentry = new DiaryEntry()
                            {
                                id_DEntry_DBreakfast = breakfast.id_DiaryBreakfast,
                                DiaryDate = DiaryFood.Getdate(),
                                id_DEntry_DLunch = lunch.id_DiaryLunch,
                                id_DEntry_DDinner = dinner.id_DiaryDinner,
                                id_DEntry_DCardio = cardio.id_DiaryCardio,
                                id_DEntry_DNotes = note.id_DiaryNotes,
                                id_DEntry_DSnack1 = snack1.id_DiarySnack1,
                                id_DEntry_DSnack2 = snack2.id_DiarySnack2,
                                id_DEntry_DStrength = strength.id_DiaryStrength,
                                id_DEntry_DWater = water.id_DiaryWater
                            };
                            context.DiaryEntries.Add(diaryentry);
                            context.SaveChanges();

                            var diary = new Diary()
                            {
                                id_Account = currentID.id_Account,
                                id_Diary_Entry = diaryentry.id_DiaryEntry
                            };
                            context.Diaries.Add(diary);
                            context.SaveChanges();
                        }
                        else if (TimeOfDay == "Dinner")
                        {
                            DiaryDinner dinner = new DiaryDinner()
                            {
                                Name = I.Name,
                                Calories = I.Calories * nbOfServings,
                                Carbs = I.Carbs * nbOfServings,
                                Protein = I.Protein * nbOfServings,
                                Fat = I.Fat * nbOfServings,
                                Cholesterol = I.Cholesterol * nbOfServings,
                                Sodium = I.Sodium * nbOfServings,
                                Potassium = I.Potassium * nbOfServings,
                                Fiber = I.Potassium * nbOfServings,
                                Sugars = I.Sugars * nbOfServings,
                                VitA = I.VitA * nbOfServings,
                                VitC = I.VitC * nbOfServings,
                                Calcium = I.Calcium * nbOfServings,
                                Iron = I.Iron * nbOfServings
                            };
                            var lunch = new DiaryLunch();
                            var breakfast = new DiaryBreakfast();
                            var snack1 = new DiarySnack1();
                            var snack2 = new DiarySnack2();
                            var cardio = new DiaryCardio();
                            var strength = new DiaryStrength();
                            var water = new DiaryWater();
                            var note = new DiaryNote();


                            context.DiaryBreakfasts.Add(breakfast);
                            context.DiaryLunches.Add(lunch);
                            context.DiaryDinners.Add(dinner);
                            context.DiarySnack1.Add(snack1);
                            context.DiarySnack2.Add(snack2);
                            context.DiaryCardios.Add(cardio);
                            context.DiaryStrengths.Add(strength);
                            context.DiaryWaters.Add(water);
                            context.DiaryNotes.Add(note);
                            context.SaveChanges();
                            var diaryentry = new DiaryEntry()
                            {
                                id_DEntry_DBreakfast = breakfast.id_DiaryBreakfast,
                                DiaryDate = DiaryFood.Getdate(),
                                id_DEntry_DLunch = lunch.id_DiaryLunch,
                                id_DEntry_DDinner = dinner.id_DiaryDinner,
                                id_DEntry_DCardio = cardio.id_DiaryCardio,
                                id_DEntry_DNotes = note.id_DiaryNotes,
                                id_DEntry_DSnack1 = snack1.id_DiarySnack1,
                                id_DEntry_DSnack2 = snack2.id_DiarySnack2,
                                id_DEntry_DStrength = strength.id_DiaryStrength,
                                id_DEntry_DWater = water.id_DiaryWater
                            };
                            context.DiaryEntries.Add(diaryentry);
                            context.SaveChanges();

                            var diary = new Diary()
                            {
                                id_Account = currentID.id_Account,
                                id_Diary_Entry = diaryentry.id_DiaryEntry
                            };
                            context.Diaries.Add(diary);
                            context.SaveChanges();
                        }
                        else if (TimeOfDay == "Snack1")
                        {
                            DiarySnack1 snack1 = new DiarySnack1()
                            {
                                Name = I.Name,
                                Calories = I.Calories * nbOfServings,
                                Carbs = I.Carbs * nbOfServings,
                                Protein = I.Protein * nbOfServings,
                                Fat = I.Fat * nbOfServings,
                                Cholesterol = I.Cholesterol * nbOfServings,
                                Sodium = I.Sodium * nbOfServings,
                                Potassium = I.Potassium * nbOfServings,
                                Fiber = I.Potassium * nbOfServings,
                                Sugars = I.Sugars * nbOfServings,
                                VitA = I.VitA * nbOfServings,
                                VitC = I.VitC * nbOfServings,
                                Calcium = I.Calcium * nbOfServings,
                                Iron = I.Iron * nbOfServings
                            };
                            var lunch = new DiaryLunch();
                            var breakfast = new DiaryBreakfast();
                            var dinner = new DiaryDinner();
                            var snack2 = new DiarySnack2();
                            var cardio = new DiaryCardio();
                            var strength = new DiaryStrength();
                            var water = new DiaryWater();
                            var note = new DiaryNote();


                            context.DiaryBreakfasts.Add(breakfast);
                            context.DiaryLunches.Add(lunch);
                            context.DiaryDinners.Add(dinner);
                            context.DiarySnack1.Add(snack1);
                            context.DiarySnack2.Add(snack2);
                            context.DiaryCardios.Add(cardio);
                            context.DiaryStrengths.Add(strength);
                            context.DiaryWaters.Add(water);
                            context.DiaryNotes.Add(note);
                            context.SaveChanges();
                            var diaryentry = new DiaryEntry()
                            {
                                id_DEntry_DBreakfast = breakfast.id_DiaryBreakfast,
                                DiaryDate = DiaryFood.Getdate(),
                                id_DEntry_DLunch = lunch.id_DiaryLunch,
                                id_DEntry_DDinner = dinner.id_DiaryDinner,
                                id_DEntry_DCardio = cardio.id_DiaryCardio,
                                id_DEntry_DNotes = note.id_DiaryNotes,
                                id_DEntry_DSnack1 = snack1.id_DiarySnack1,
                                id_DEntry_DSnack2 = snack2.id_DiarySnack2,
                                id_DEntry_DStrength = strength.id_DiaryStrength,
                                id_DEntry_DWater = water.id_DiaryWater
                            };
                            context.DiaryEntries.Add(diaryentry);
                            context.SaveChanges();

                            var diary = new Diary()
                            {
                                id_Account = currentID.id_Account,
                                id_Diary_Entry = diaryentry.id_DiaryEntry
                            };
                            context.Diaries.Add(diary);
                            context.SaveChanges();
                        }
                        else if (TimeOfDay == "Snack2")
                        {
                            DiarySnack2 snack2 = new DiarySnack2()
                            {
                                Name = I.Name,
                                Calories = I.Calories * nbOfServings,
                                Carbs = I.Carbs * nbOfServings,
                                Protein = I.Protein * nbOfServings,
                                Fat = I.Fat * nbOfServings,
                                Cholesterol = I.Cholesterol * nbOfServings,
                                Sodium = I.Sodium * nbOfServings,
                                Potassium = I.Potassium * nbOfServings,
                                Fiber = I.Potassium * nbOfServings,
                                Sugars = I.Sugars * nbOfServings,
                                VitA = I.VitA * nbOfServings,
                                VitC = I.VitC * nbOfServings,
                                Calcium = I.Calcium * nbOfServings,
                                Iron = I.Iron * nbOfServings
                            };
                            var lunch = new DiaryLunch();
                            var breakfast = new DiaryBreakfast();
                            var snack1 = new DiarySnack1();
                            var dinner = new DiaryDinner();
                            var cardio = new DiaryCardio();
                            var strength = new DiaryStrength();
                            var water = new DiaryWater();
                            var note = new DiaryNote();


                            context.DiaryBreakfasts.Add(breakfast);
                            context.DiaryLunches.Add(lunch);
                            context.DiaryDinners.Add(dinner);
                            context.DiarySnack1.Add(snack1);
                            context.DiarySnack2.Add(snack2);
                            context.DiaryCardios.Add(cardio);
                            context.DiaryStrengths.Add(strength);
                            context.DiaryWaters.Add(water);
                            context.DiaryNotes.Add(note);
                            context.SaveChanges();
                            var diaryentry = new DiaryEntry()
                            {
                                id_DEntry_DBreakfast = breakfast.id_DiaryBreakfast,
                                DiaryDate = DiaryFood.Getdate(),
                                id_DEntry_DLunch = lunch.id_DiaryLunch,
                                id_DEntry_DDinner = dinner.id_DiaryDinner,
                                id_DEntry_DCardio = cardio.id_DiaryCardio,
                                id_DEntry_DNotes = note.id_DiaryNotes,
                                id_DEntry_DSnack1 = snack1.id_DiarySnack1,
                                id_DEntry_DSnack2 = snack2.id_DiarySnack2,
                                id_DEntry_DStrength = strength.id_DiaryStrength,
                                id_DEntry_DWater = water.id_DiaryWater
                            };
                            context.DiaryEntries.Add(diaryentry);
                            context.SaveChanges();

                            var diary = new Diary()
                            {
                                id_Account = currentID.id_Account,
                                id_Diary_Entry = diaryentry.id_DiaryEntry
                            };
                            context.Diaries.Add(diary);
                            context.SaveChanges();
                        }



                    }
                }

          
            this.Close();


        }

        private void DatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            AddFoodDialog addFromDatabase = new AddFoodDialog();
            addFromDatabase.Show();
            this.Close();
        }

        private void MyRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            AddFoodFromRecipes addFromRecipes = new AddFoodFromRecipes();
            addFromRecipes.Show();
            this.Close();

        }
    }
}

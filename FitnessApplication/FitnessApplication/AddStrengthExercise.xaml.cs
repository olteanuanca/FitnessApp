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
    
    public partial class AddStrengthExercise : Window
    {
        System.Windows.Data.CollectionViewSource strengthViewSource;
        MyFitEntities context = new MyFitEntities();

        public AddStrengthExercise()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            strengthViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("strengthViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Strengths.Load();
            strengthViewSource.Source = context.Strengths.Local;
        }

        private void strengthDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var exercise = strengthDataGrid.SelectedItem as Strength;
            SelectedBox.Text = exercise.Strength_Description;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedEx = SelectedBox.Text;
            int nbOfSets = Int32.Parse(NbSetsBox.Text);
            int nbOfReps = Int32.Parse(RepsBox.Text);
            int weight = Int32.Parse(WeightBox.Text);

            List<Strength> StrengthExercises = context.Strengths.ToList();
            for (int i = 0; i < StrengthExercises.Count(); i++)
                if (StrengthExercises[i].Strength_Description.Contains(selectedEx))
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
                            if (DiaryEntryId[k].DiaryDate.ToShortDateString() == DiaryExercise.Getdate().ToShortDateString())
                            {
                                found = 1;
                                tmp = (int)DiaryEntryId[k].id_DEntry_DStrength;
                                DiaryStrength strength = context.DiaryStrengths.Where(c => c.id_DiaryStrength== tmp).FirstOrDefault();
                                Strength mystrength = StrengthExercises[i];

                                strength.Strength_Description = mystrength.Strength_Description;
                                strength.NbOfSets = nbOfSets;
                                strength.RepsPerSet = nbOfReps;
                                strength.WeightPerRep = weight;
                                strength.Calories_burned = mystrength.Calories_burned / mystrength.NbOfSets / mystrength.RepsPerSet * nbOfSets * nbOfReps;

                                context.SaveChanges();
                            }
                        }

                    }

                    if (found == 0)
                    {
                        Strength mystrength = StrengthExercises[i];

                        DiaryStrength strength = new DiaryStrength()
                        {
                            Strength_Description = mystrength.Strength_Description,
                            NbOfSets = nbOfSets,
                            RepsPerSet = nbOfReps,
                            WeightPerRep = weight,
                            Calories_burned = mystrength.Calories_burned / mystrength.NbOfSets / mystrength.RepsPerSet * nbOfSets * nbOfReps
                         };
                        var breakfast = new DiaryBreakfast();
                        var lunch = new DiaryLunch();
                        var dinner = new DiaryDinner();
                        var snack1 = new DiarySnack1();
                        var snack2 = new DiarySnack2();
                        var cardio = new DiaryCardio();
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
                            DiaryDate = DiaryExercise.Getdate(),
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
            this.Close();
        
        }

        private void MyStrengthButton_Click(object sender, RoutedEventArgs e)
        {
            AddFromMyStrength addExercise = new AddFromMyStrength();
            addExercise.Show();
            this.Close();
        }
    }
}

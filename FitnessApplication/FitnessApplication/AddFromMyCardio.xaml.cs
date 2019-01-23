﻿using System;
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
    /// Interaction logic for AddFromMyCardio.xaml
    /// </summary>
    public partial class AddFromMyCardio : Window
    {
        System.Windows.Data.CollectionViewSource myCardioViewSource;
        MyFitEntities context = new MyFitEntities();

        public AddFromMyCardio()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            myCardioViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("myCardioViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Account currentID = context.Accounts.Where(i => i.Username == AuthentificationWindow.currentUsername).SingleOrDefault();

            var Acc_Cardio_Id = context.Accounts_Cardio.Where(c => c.id_Account == currentID.id_Account).ToList();

            for (int j = 0; j < Acc_Cardio_Id.Count(); j++)
            {
                int temp = (int)Acc_Cardio_Id[j].id_Cardio;
                context.MyCardios.Where(c => c.id_myCardio == temp).Load();
                myCardioViewSource.Source = context.MyCardios.Local;

            }

        }

       

        private void myCardioDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var exercise = myCardioDataGrid.SelectedItem as MyCardio;
            SelectedBox.Text = exercise.Cardio_Description;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedEx = SelectedBox.Text;
            int duration = Int32.Parse(DurationBox.Text);

            List<MyCardio> CardioExercises = context.MyCardios.ToList();

            for (int i = 0; i < CardioExercises.Count(); i++)
                if (CardioExercises[i].Cardio_Description.Contains(selectedEx))
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
                                tmp = (int)DiaryEntryId[k].id_DEntry_DCardio;
                                DiaryCardio cardio = context.DiaryCardios.Where(c => c.id_DiaryCardio == tmp).FirstOrDefault();
                                MyCardio mycardio = CardioExercises[i];

                                cardio.Cardio_Description = mycardio.Cardio_Description;
                                cardio.Duration_min = duration;
                                cardio.Calories_burned = mycardio.Calories_burned / mycardio.Duration_min * duration;

                                context.SaveChanges();
                            }
                        }

                    }

                    if (found == 0)
                    {
                        MyCardio mycardio = CardioExercises[i];

                        DiaryCardio cardio = new DiaryCardio()
                        {
                            Cardio_Description = mycardio.Cardio_Description,
                            Duration_min = duration,
                            Calories_burned = mycardio.Calories_burned / mycardio.Duration_min * duration
                        };
                        var breakfast = new DiaryBreakfast();
                        var lunch = new DiaryLunch();
                        var dinner = new DiaryDinner();
                        var snack1 = new DiarySnack1();
                        var snack2 = new DiarySnack2();
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

        private void DataBaseButton_Click(object sender, RoutedEventArgs e)
        {
            AddCardioExercise addEx = new AddCardioExercise();
            addEx.Show();
            this.Close();
        }
    }
}

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
    
    public partial class AddWater : Window
    {
        MyFitEntities context = new MyFitEntities();

        public AddWater()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity = Int32.Parse(QuantityBox.Text);

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
                    
                    if (DiaryEntryId[k].DiaryDate.ToShortDateString() == DiaryFood.Getdate().ToShortDateString())
                    {
                        found = 1;
                        tmp = (int)DiaryEntryId[k].id_DEntry_DWater;
                        DiaryWater water = context.DiaryWaters.Where(c => c.id_DiaryWater == tmp).FirstOrDefault();
                        water.Quantity_ml = quantity;

                        context.SaveChanges();
                    }
                }
            }

            if(found == 0)
            {
                var breakfast = new DiaryBreakfast();              
                var lunch = new DiaryLunch();
                var dinner = new DiaryDinner();
                var snack1 = new DiarySnack1();
                var snack2 = new DiarySnack2();
                var cardio = new DiaryCardio();
                var strength = new DiaryStrength();
                var water = new DiaryWater() { Quantity_ml= quantity };
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
            this.Close();
        }
    }
}

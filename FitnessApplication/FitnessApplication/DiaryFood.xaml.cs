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
    

    public partial class DiaryFood : Window
    {
        MyFitEntities context = new MyFitEntities();
        System.Windows.Data.CollectionViewSource diaryBreakfastViewSource;
        System.Windows.Data.CollectionViewSource diaryLunchViewSource;
        System.Windows.Data.CollectionViewSource diaryDinnerViewSource;
        System.Windows.Data.CollectionViewSource diarySnack1ViewSource;
        System.Windows.Data.CollectionViewSource diarySnack2ViewSource;
        System.Windows.Data.CollectionViewSource diaryWaterViewSource;

        public static DateTime myDate;
        public static int isSet=0;
        

        public static DateTime Getdate() { return myDate; }

        public DiaryFood()
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
            diaryBreakfastViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diaryBreakfastViewSource")));
            diaryLunchViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diaryLunchViewSource")));
            diaryDinnerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diaryDinnerViewSource")));
            diarySnack1ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diarySnack1ViewSource")));
            diarySnack2ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diarySnack2ViewSource")));
            diaryWaterViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diaryWaterViewSource")));
            DataContext = this;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Account currentID = context.Accounts.Where(i => i.Username == AuthentificationWindow.currentUsername).SingleOrDefault();

            var DiaryId = context.Diaries.Where(c => c.id_Account == currentID.id_Account).ToList();

            for (int j = 0; j < DiaryId.Count(); j++)
            {
                int temp = (int)DiaryId[j].id_Diary_Entry;
                var DiaryEntryId = context.DiaryEntries.Where(c => c.id_DiaryEntry == temp).ToArray();

                int tmp, tmp2, tmp3, tmp4, tmp5,tmp6;
                for (int i = 0; i < DiaryEntryId.Count(); i++)
                {
                    if (DiaryEntryId[i].DiaryDate.ToShortDateString() == CurrentDate.SelectedDate.Value.Date.ToShortDateString())
                    {
                        tmp = (int)DiaryEntryId[i].id_DEntry_DBreakfast;
                        context.DiaryBreakfasts.Where(c => c.id_DiaryBreakfast == tmp).Load();
                        diaryBreakfastViewSource.Source = context.DiaryBreakfasts.Local;

                        tmp2 = (int)DiaryEntryId[i].id_DEntry_DLunch;
                        context.DiaryLunches.Where(c => c.id_DiaryLunch == tmp2).Load();
                        diaryLunchViewSource.Source = context.DiaryLunches.Local;

                        tmp3 = (int)DiaryEntryId[i].id_DEntry_DDinner;
                        context.DiaryDinners.Where(c => c.id_DiaryDinner == tmp3).Load();
                        diaryDinnerViewSource.Source = context.DiaryDinners.Local;

                        tmp4 = (int)DiaryEntryId[i].id_DEntry_DSnack1;
                        context.DiarySnack1.Where(c => c.id_DiarySnack1 == tmp4).Load();
                        diarySnack1ViewSource.Source = context.DiarySnack1.Local;

                        tmp5 = (int)DiaryEntryId[i].id_DEntry_DSnack2;
                        context.DiarySnack2.Where(c => c.id_DiarySnack2 == tmp5).Load();
                        diarySnack2ViewSource.Source = context.DiarySnack2.Local;

                        tmp6 = (int)DiaryEntryId[i].id_DEntry_DWater;
                        context.DiaryWaters.Where(c => c.id_DiaryWater == tmp6).Load();
                        diaryWaterViewSource.Source = context.DiaryWaters.Local;
                    }

                }

            }

      
        }

        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            myDate = CurrentDate.SelectedDate.Value.Date;
            AddFoodDialog addFood = new AddFoodDialog();
            addFood.Show();
            //this.Close();
        }

       

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            myDate = CurrentDate.SelectedDate.Value.Date;
            DiaryFood df = new DiaryFood();
            df.Show();
            this.Close();

        }

        private void diaryBreakfastDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Food_Click(object sender, RoutedEventArgs e)
        {
            Recipes window = new Recipes();
            window.Show();

        }


        private void AddWaterButton_Click(object sender, RoutedEventArgs e)
        {
            myDate = CurrentDate.SelectedDate.Value.Date;
            AddWater addWater = new AddWater();
            addWater.Show();
        }

        private void DiaryExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            DiaryExercise D = new DiaryExercise();
            D.Show();
            this.Close();
        }

        private void NutritionButton_Click(object sender, RoutedEventArgs e)
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

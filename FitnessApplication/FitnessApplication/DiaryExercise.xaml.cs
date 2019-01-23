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

    public partial class DiaryExercise : Window
    {
        MyFitEntities context = new MyFitEntities();

        System.Windows.Data.CollectionViewSource diaryCardioViewSource;
        System.Windows.Data.CollectionViewSource diaryStrengthViewSource;

        public static DateTime myDate;
        public static int isSet = 0;

        public static DateTime Getdate() { return myDate; }

        public DiaryExercise()
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

            diaryCardioViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diaryCardioViewSource")));
            diaryStrengthViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diaryStrengthViewSource")));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Account currentID = context.Accounts.Where(i => i.Username == AuthentificationWindow.currentUsername).SingleOrDefault();

            var DiaryId = context.Diaries.Where(c => c.id_Account == currentID.id_Account).ToList();

            for (int j = 0; j < DiaryId.Count(); j++)
            {
                int temp = (int)DiaryId[j].id_Diary_Entry;
                var DiaryEntryId = context.DiaryEntries.Where(c => c.id_DiaryEntry == temp).ToArray();

                int tmp, tmp2;
                for (int i = 0; i < DiaryEntryId.Count(); i++)
                {
                    if (DiaryEntryId[i].DiaryDate.ToShortDateString() == CurrentDate.SelectedDate.Value.Date.ToShortDateString())
                    {
                        tmp = (int)DiaryEntryId[i].id_DEntry_DCardio;
                        context.DiaryCardios.Where(c => c.id_DiaryCardio == tmp).Load();
                        diaryCardioViewSource.Source = context.DiaryCardios.Local;

                        tmp2 = (int)DiaryEntryId[i].id_DEntry_DStrength;
                        context.DiaryStrengths.Where(c => c.id_DiaryStrength == tmp2).Load();
                        diaryStrengthViewSource.Source = context.DiaryStrengths.Local;


                    }

                }

            }

        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            myDate = CurrentDate.SelectedDate.Value.Date;
            DiaryExercise de = new DiaryExercise();
            de.Show();
            this.Close();

        }

        private void AddCardioButton_Click(object sender, RoutedEventArgs e)
        {
            AddCardioExercise cardioExercise = new AddCardioExercise();
            cardioExercise.Show();
        }

        private void AddStrengthButton_Click(object sender, RoutedEventArgs e)
        {
            AddStrengthExercise strengthExercise = new AddStrengthExercise();
            strengthExercise.Show();
        }

        private void DiaryFood_Click(object sender, RoutedEventArgs e)
        {
            DiaryFood df = new DiaryFood();
            df.Show();
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

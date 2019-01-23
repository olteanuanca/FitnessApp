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
    /// Interaction logic for AddMyStrength.xaml
    /// </summary>
    public partial class AddMyStrength : Window
    {
        public AddMyStrength()
        {
            InitializeComponent();
        }
        public static int idStr=0;
        public static int strengthCount = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFitEntities context = new MyFitEntities();
            Account c1 = (from s in context.Accounts
                          where s.Username == AuthentificationWindow.currentUsername
                          select s).First();

            Accounts_Strength ac = new Accounts_Strength()
            {
                id_Acc_Strength = idStr++,
                id_Account = c1.id_Account,
                id_Strength = strengthCount++
            };

            context.Accounts_Strength.Add(ac);
            MyStrength ms = new MyStrength
            {
                id_myStrength = idStr,
                MyStrength_Description = Description.Text,
                NbOfSets = Int16.Parse(Number.Text),
                RepsPerSet = Int16.Parse(Repetitions.Text),
                WeightPerRep=Int16.Parse(Weight.Text),
                Calories_burned=Int16.Parse(Calories.Text)

            };
            context.MyStrengths.Add(ms);

            context.SaveChanges();

        }
    }
}

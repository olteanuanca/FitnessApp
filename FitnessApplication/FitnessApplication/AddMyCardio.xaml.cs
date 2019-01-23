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
    /// Interaction logic for AddMyCardio.xaml
    /// </summary>
    public partial class AddMyCardio : Window
    {
        public AddMyCardio()
        {
            InitializeComponent();
        }
        public static int idCardio =0;
        public static int cardioCount = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFitEntities context = new MyFitEntities();
             Account c1 = (from s in context.Accounts
                            where s.Username == AuthentificationWindow.currentUsername
                            select s).First();
            /*  var c= (from s in context.Accounts_Cardio
                     where s.id_Account==c1.id_Account
                     select s).First()
                     */
            Accounts_Cardio c = new Accounts_Cardio
            {
                id_Acc_Cardio = idCardio++,
                id_Account = c1.id_Account,
                id_Cardio = cardioCount++ 

            };
            context.Accounts_Cardio.Add(c);
            MyCardio mc = new MyCardio
            {
                id_myCardio = cardioCount,
                Cardio_Description = Description.Text,
                Duration_min = Int16.Parse(Duration.Text),
                Calories_burned=Int16.Parse(Burned.Text)



            };
            context.MyCardios.Add(mc);
            context.SaveChanges();

        }
    }
}

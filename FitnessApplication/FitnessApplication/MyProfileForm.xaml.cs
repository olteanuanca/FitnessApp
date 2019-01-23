using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FitnessApplication
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MyFitEntities c = new MyFitEntities();
        double StartWeight;
        int postId = 0;
       /// private BitmapImage bitmap1;

       public static byte[] binImage1;

        public Window1()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            User.Text = AuthentificationWindow.currentUsername;

            UserImage.Source = NewAccountWindow1.bitmap;
           


            string user = AuthentificationWindow.currentUsername;
            var id = (from s in c.Accounts
                      where s.Username == user
                      select s).FirstOrDefault();
            var fr = (from f in c.Accounts_Friends
                      where f.id_Account == id.id_Account
                      select f).Count();

            if (fr != 0)
            {
                Friends.Text = fr.ToString() + " friends";
            }

            var weight1 = (from goal in c.Goals
                          where goal.id_Goals == id.id_Account_Goals
                          select goal.id_Goals_WeightG).First();

            var startweight = (from goal2 in c.WeightGoals
                               where goal2.id_WeightGoals == weight1
                               select goal2.StartingWeight).First();
                          ;
            StartWeight = (double)startweight;
            var currentweight = (from goal2 in c.WeightGoals
                                where goal2.id_WeightGoals == weight1
                                select goal2.CurrentWeight).First();

            double lostKilos =(double)startweight -(double)currentweight;

            if (lostKilos != 0)
                Weight.Text = lostKilos.ToString() + " kg lost";

            ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // ProgressChart p = new ProgressChart();
            //   p.Show();


            Goals g = new Goals();
            g.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Account c1 = (from s in c.Accounts
                      where s.Username == AuthentificationWindow.currentUsername
                      select s).First();
            Goal c2= (from s in c.Goals
                      where s.id_Goals == c1.id_Account_Goals
                      select s).First();
            NutritionGoal c3 = (from s in c.NutritionGoals
                                where s.id_NutritionGoals == c2.id_Goals_Nutrition
                                select s).First();
            MealGoal m = (from s in c.MealGoals
                          where s.id_MealGoals == c3.id_NutritionG_MealG
                          select s).First();
            DinnerGoal dinner = (from s in c.DinnerGoals
                                 where s.id_Dinner == m.id_DinnerG_MealG
                                 select s).First();
            BreakfastGoal breakfast = (from s in c.BreakfastGoals
                                       where s.id_Breakfast == m.id_BreakfastG_MealG
                                       select s).First();
            LunchGoal lunch=(from s in c.LunchGoals
                             where s.id_Lunch==m.id_LunchG_MealG
                             select s).First();
            Snack1Goals snack=(from s in c.Snack1Goals
                               where s.id_Snack1==m.id_Snack1G_MealG
                               select s).First();
            //BreakfastGoals
            //LunchGoals
            //Snack1Goals

            if (StartWeight<55)
            {
                dinner.Calories = 344;
                dinner.Carbs = 64;
                dinner.Protein = 13;
                dinner.Fat = 2;
                dinner.Cholesterol = 0;
                dinner.Sodium = 2;
                dinner.Potassium = 45;
                dinner.Fiber = 9;
                dinner.Sugars = 3;
                dinner.VitA = 0;
                dinner.VitC = 0;
                dinner.Calcium = 0;
                dinner.Iron = 0;

                //1	Vegetable Hotchpotch	118	17	3	5	0	316	0	0	0	0	0	0	0

                lunch.Calories = 118;
                lunch.Carbs = 17;
                lunch.Protein = 3;
                lunch.Fat = 5;
                lunch.Cholesterol = 0;
                lunch.Sodium = 316;
                lunch.Potassium = 0;
                lunch.Fiber = 0;
                lunch.VitA = 0;
                lunch.VitC = 0;
                lunch.Calcium = 0;
                lunch.Iron = 0;

                //   22  Banana  105 27  1.3 0.4 0   1   422 3.1 14  1   17  0   1
                snack.Calories = 105;
                snack.Carbs = 27;
                snack.Protein = 1.3;
                snack.Fat = 0.4;
                snack.Cholesterol = 0;
                snack.Sodium = 1;
                snack.Potassium = 422;
                snack.Fiber = 3.1;
                snack.Sugars = 14;
                snack.VitA = 1;
                snack.VitC = 17;
                snack.Calcium = 0;
                snack.Iron = 1;

                //  48  Biscuits    230 35  4   8   0   220 85  3   13  0   0   10  10
                breakfast.Calories = 230;
                breakfast.Carbs = 35;
                breakfast.Protein = 4;
                breakfast.Fat = 8;
                breakfast.Cholesterol = 0;
                breakfast.Sodium = 220;
                breakfast.Potassium = 85;
                breakfast.Fiber = 3;
                breakfast.Sugars = 13;
                breakfast.VitA = 0;
                breakfast.VitC = 0;
                breakfast.Calcium = 10;
                breakfast.Iron = 10;

            }
            else if(55<StartWeight && StartWeight < 80)
            {
                //47	Raisins	299	79.2	3.1	0.5	0	749	3.7	59.2	3.1	0	4	5	10
                breakfast.Calories = 299;
                breakfast.Carbs = 79.2;
                breakfast.Protein = 3.1;
                breakfast.Fat = 0.5;
                breakfast.Cholesterol = 0;
                breakfast.Sodium = 749;
                breakfast.Potassium = 3.7;
                breakfast.Fiber = 59.2;
                breakfast.Sugars = 3.1;
                breakfast.VitA = 0;
                breakfast.VitC = 4;
                breakfast.Calcium = 5;
                breakfast.Iron = 10;


               // 46  Figs    47  12.3    0.5 0.2 0   0.6 148.5   1.9 10.4    1.8 2.1 2.2 1.3
                dinner.Calories =47;
                dinner.Carbs = 12.3;
                dinner.Protein = 0.5;
                dinner.Fat = 0.2;
                dinner.Cholesterol = 0;
                dinner.Sodium = 0.6;
                dinner.Potassium = 148.5;
                dinner.Fiber = 1.9;
                dinner.Sugars = 10.4;
                dinner.VitA = 1.8;
                dinner.VitC =2.1;
                dinner.Calcium = 2.2;
                dinner.Iron = 1.3;

                //12	Spinach	7	1.1	0.9	0.1	0	23.7	167.4	0.7	0.1	56.3	14	3	4.5

                lunch.Calories = 7;
                lunch.Carbs = 1.1;
                lunch.Protein = 0.9;
                lunch.Fat = 0.1;
                lunch.Cholesterol = 0;
                lunch.Sodium = 23.7;
                lunch.Potassium = 167.4;
                lunch.Fiber = 0.7;
                lunch.Sugars = 0.1;
                lunch.VitA = 56.3;
                lunch.VitC = 14;
                lunch.Calcium = 3;
                lunch.Iron = 4.5;

                //36	Pears	80	21.3	0.5	0.2	0	1.4	152.4	4.3	13.6	0.7	10	1.3	1.4
                snack.Calories = 80;
                snack.Carbs = 21.3;
                snack.Protein = 0.5;
                snack.Fat = 0.2;
                snack.Cholesterol = 0;
                snack.Sodium = 1.4;
                snack.Potassium = 152.4;
                snack.Fiber = 4.3;
                snack.Sugars = 13.6;
                snack.VitA = 0.7;
                snack.VitC = 10;
                snack.Calcium = 1.3;
                snack.Iron = 1.4;

            }
            else
            {
                //  57  Rye Bread   73  13.7    2.4 0.9 0   186.8   47  1.6 0.1 0   0.2 2.1 4.4
                breakfast.Calories = 73;
                breakfast.Carbs = 13.7;
                breakfast.Protein = 2.4;
                breakfast.Fat = 0.9;
                breakfast.Cholesterol = 0;
                breakfast.Sodium = 186.8;
                breakfast.Potassium = 47;
                breakfast.Fiber = 1.6;
                breakfast.Sugars = 0.1;
                breakfast.VitA = 0;
                breakfast.VitC = 0.2;
                breakfast.Calcium = 2.1;
                breakfast.Iron = 4.4;

                //13  Asparagus Raw   27  5.2 2.9 0.2 0   2.7 270.7   2.8 2.5 20.3    12.5    3.2 15.9
                dinner.Calories = 27;
                dinner.Carbs = 5.2;
                dinner.Protein = 2.9;
                dinner.Fat = 0.2;
                dinner.Cholesterol = 0;
                dinner.Sodium = 2.7;
                dinner.Potassium = 270.7;
                dinner.Fiber = 2.8;
                dinner.Sugars = 2.5;
                dinner.VitA = 20.3;
                dinner.VitC = 12.5;
                dinner.Calcium = 3.2;
                dinner.Iron = 15.9;

                //   17  Red Cabbage 28  6.6 1.3 0.1 0   24  216.3   1.9 3.4 19.9    84.5    4   4

                lunch.Calories = 28;
                lunch.Carbs = 6.6;
                lunch.Protein = 1.3;
                lunch.Fat = 0.1;
                lunch.Cholesterol = 0;
                lunch.Sodium = 24;
                lunch.Potassium = 216.3;
                lunch.Fiber = 1.9;
                lunch.Sugars = 3.4;
                lunch.VitA = 19.9;
                lunch.VitC = 84.5;
                lunch.Calcium = 4;
                lunch.Iron = 4;
                //28	Grapefruit	60	15	1	0	0	0	160	2	11	35	100	4	0

                snack.Calories = 60;
                snack.Carbs = 15;
                snack.Protein = 1;
                snack.Fat = 0;
                snack.Cholesterol = 0;
                snack.Sodium = 0;
                snack.Potassium = 160;
                snack.Fiber = 2;
                snack.Sugars = 11;
                snack.VitA = 35;
                snack.VitC = 100;
                snack.Calcium = 4;
                snack.Iron = 0;
            }

            c.SaveChanges();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

         
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string imageLocation;
            OpenFileDialog browsePicture = new OpenFileDialog();
            browsePicture.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*jpg|All files(*.*)|*.*";

            if (browsePicture.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation = browsePicture.FileName.ToString();

                BitmapImage bitmap1 = new BitmapImage();
                bitmap1.BeginInit();
                bitmap1.UriSource = new Uri(imageLocation);
                bitmap1.EndInit();

                FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader bin = new BinaryReader(stream);
                binImage1 = bin.ReadBytes((int)stream.Length);

                /*
                ProfilePic.Source = bitmap;


                FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader bin = new BinaryReader(stream);
                binImage = bin.ReadBytes((int)stream.Length);
                
                */
            }
        }

        private void Button_Click_P(object sender, RoutedEventArgs e)
        {
            var id = (from s in c.Accounts
                      where s.Username == AuthentificationWindow.currentUsername
                      select s).FirstOrDefault();

            Post value = new Post()
            {
                id_Post = postId++,
                FromId =id.id_Account ,
                PostDate =DateTime.Now,
                Content = PostTxt.Text,
                Photo = binImage1

            };

            c.Posts.Add(value);
            c.SaveChanges();

            PostTxt.Clear();
        }

        private void Button_Click_InCardio(object sender, RoutedEventArgs e)
        {
            AddMyCardio ad = new AddMyCardio();
            ad.ShowDialog();
        }
        private void Button_Click_InStrength(object sender, RoutedEventArgs e)
        {
            AddMyStrength st = new AddMyStrength();
            st.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ProgressChart p = new ProgressChart();
            p.ShowDialog();
        }
    }
}

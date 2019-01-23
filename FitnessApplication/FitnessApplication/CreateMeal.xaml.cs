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
using System.IO;
using System.Windows.Forms;


namespace FitnessApplication
{
    /// <summary>
    /// Interaction logic for CreateMeal.xaml
    /// </summary>
    public partial class CreateMeal : Window
    {
        MyFitEntities context = new MyFitEntities();
        public static byte[] binImage = null;
        public CreateMeal()
        {
            InitializeComponent();
        }


        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            var accountID = (from i in context.Accounts
                             where i.Username == AuthentificationWindow.currentUsername
                             select i).SingleOrDefault();

            var MyMeal = new MyMeal
            {
                Name = Name_TB.Text,
                Photo = binImage,
                Calories = Convert.ToDouble(Calories_TB.Text),
                Carbs = Convert.ToDouble(Carbs_TB.Text),
                Protein = Convert.ToDouble(Protein_TB.Text),
                Fat = Convert.ToDouble(Fat_TB.Text),
                Cholesterol = Convert.ToDouble(Ch_TB.Text),
                Sodium = Convert.ToDouble(Sodium_TB.Text),
                Potassium = Convert.ToDouble(Potassium_TB.Text),
                Fiber = Convert.ToDouble(Fiber_TB.Text),
                Sugars = Convert.ToDouble(Sugars_TB.Text),
                VitA = Convert.ToDouble(VitA_TB.Text),
                VitC = Convert.ToDouble(VitC.Text),
                Calcium = Convert.ToDouble(Calcium_TB.Text),
                Iron = Convert.ToDouble(Iron_TB.Text),
            };

            context.MyMeals.Add(MyMeal);
            context.SaveChanges();

            var Acc_Meal = new Accounts_Meals
            {
                id_Account = accountID.id_Account,
                id_Meals = MyMeal.id_myMeal,

            };

            context.Accounts_Meals.Add(Acc_Meal);
            context.SaveChanges();

            this.Close();
        }

        private void browse_btn_Click(object sender, RoutedEventArgs e)
        {
            string imageLocation;
            OpenFileDialog browsePicture = new OpenFileDialog();
            browsePicture.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*jpg|All files(*.*)|*.*";

            if (browsePicture.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation = browsePicture.FileName.ToString();

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imageLocation);
                bitmap.EndInit();
                Pic.Source = bitmap;


                FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader bin = new BinaryReader(stream);
                binImage = bin.ReadBytes((int)stream.Length);
            }
        }
    }
}

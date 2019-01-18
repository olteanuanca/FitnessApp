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
using System.Windows.Forms;
using System.IO;

namespace FitnessApplication
{
  
    public partial class NewAccountWindow1 : Window
    {

        public static string  EmAdress ;
        public static string LName ;
        public static string FName;
        public static string Username;
        public static byte[] binImage = null;

        public NewAccountWindow1()
        {
           InitializeComponent();
        }
        public static string currentUsername;
        private void Continue_button_Click(object sender, RoutedEventArgs e)
        {
            string Password;
            currentUsername = Username_textbox.Text;

            if (EmailAdress_textbox.Text != "" || FirstName_textbox.Text != "" || LastName_textbox.Text != "" || Username_textbox.Text != "")
            {
                EmAdress = EmailAdress_textbox.Text;
                FName = FirstName_textbox.Text;
                LName = LastName_textbox.Text;
                Username = Username_textbox.Text;
                Password = Password_textbox.Text;
            }
            else
            {
                System.Windows.MessageBox.Show("You forgot something! Try again!");
                return;
            }
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String Passwordhash = System.Text.Encoding.ASCII.GetString(data);

            var context = new MyFitEntities();

            var check = (from c in context.AccountCredentials where c.AccUsername == Username_textbox.Text select c).FirstOrDefault();

            if (check != null)
            {
                if (check.AccUsername != null)
                {
                    System.Windows.MessageBox.Show("This Username is already taken!. Please try anotherone!");
                    return;
                }
                else if (check.AccEmail != null)
                {
                    System.Windows.MessageBox.Show("Email address already registered!");
                }
                else
                {

                    var AccountCredentials = new AccountCredential
                    {
                        AccUsername = Username_textbox.Text,
                        AccPassword = Passwordhash,
                        AccEmail = EmailAdress_textbox.Text,

                    };

                    context.AccountCredentials.Add(AccountCredentials);
                    context.SaveChanges();

                }
            }
            else
            {

                var AccountCredentials = new AccountCredential
                {
                    AccUsername = Username_textbox.Text,
                    AccPassword = Passwordhash,
                    AccEmail = EmailAdress_textbox.Text,

                };

                context.AccountCredentials.Add(AccountCredentials);
                context.SaveChanges();

            }

            this.Close();
            NewAccountWindow2 window = new NewAccountWindow2();
            window.Show();

            
        }

        private void Browse_button_Click(object sender, RoutedEventArgs e)
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
                ProfilePic.Source = bitmap;

               
                FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader bin = new BinaryReader(stream);
                binImage = bin.ReadBytes((int)stream.Length);

                
            }

         

        }
    }
}

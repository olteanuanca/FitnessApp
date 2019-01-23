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
    /// Interaction logic for HeightScale.xaml
    /// </summary>
    public partial class HeightScale : Window
    {
        private static Window2 w = new Window2();

        public HeightScale()
        {
            InitializeComponent();
        }
        public void Show()
        {
            ShowDialog();
            Close();


            MyFitEntities c = new MyFitEntities();
            var id = (from s in c.Accounts
                      where s.Username == AuthentificationWindow.currentUsername
                      select s).FirstOrDefault();

            double value = sliderValue.Value;
            id.Height = (int)value;

            c.SaveChanges();
            w.Height.Text = value.ToString();           
        }

    }
}

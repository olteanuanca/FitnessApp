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
    /// Interaction logic for BirthDialog.xaml
    /// </summary>
    public partial class BirthDialog : Window
    {
        private Window2 w = new Window2();
        public string datestr;
        public DateTime? date;
        public BirthDialog()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            ShowDialog();
        }
        private void DatePicker_SelectedDateChanged(object sender,
                SelectionChangedEventArgs e)
        {
            
                // ... Get DatePicker reference.
                var picker = sender as DatePicker;

                // ... Get nullable DateTime from SelectedDate.
                date = picker.SelectedDate;
                if (date == null)
                {
                    // ... A null object.
                    //this.Title = "No date";
                }
                else
                {
                    // ... No need to display the time.
                  //this.Title = date.Value.ToShortDateString();
                  datestr =date.Value.ToShortDateString();

                w.Birth.Text = datestr;

                }
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFitEntities context = new MyFitEntities();
            var c = (from s in context.Accounts
                     where s.Username == AuthentificationWindow.currentUsername
                     select s).First();
             c.BirthDate =date.Value;

            context.SaveChanges();
            w.Birth.Text = datestr;
            Close();

        }
    }
    }



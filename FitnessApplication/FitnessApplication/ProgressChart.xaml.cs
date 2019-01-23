using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ProgressChart.xaml
    /// </summary>
    ///
    public class MyViewModel
    {
        public ObservableCollection<KeyValuePair<DateTime, int>> MyValue { get; set; }
        public MyViewModel()
        {
            MyValue = new ObservableCollection<KeyValuePair<DateTime, int>>();
          
        }
        public void Add(int x,int y)
        {
            DateTime t = DateTime.Now.AddMonths(1);
            MyValue.Add(new KeyValuePair<DateTime, int>(t, y));
        }

        internal void Add(Func<int, int, int> daysInMonth, int startWeight)
        {
            throw new NotImplementedException();
        }

        
    }
    public partial class ProgressChart : Window
    {
        MyViewModel vm;
        int i=0;
        int currentWeight;
        int startWeight;
        public ProgressChart()
        {
            InitializeComponent();

        


            MyFitEntities context = new MyFitEntities();
            var c = (from s in context.Accounts
                     where s.Username == AuthentificationWindow.currentUsername
                     select s).First();

            var c1 = (from s in context.Goals
                      where s.id_Goals == c.id_Account_Goals
                      select s).First();
            var c2 = (from s in context.WeightGoals
                      where s.id_WeightGoals == c1.id_Goals_WeightG
                      select s).First();

            currentWeight = (int)c2.CurrentWeight;
            startWeight = (int)c2.StartingWeight;
            Linear.DataContext = new ObservableCollection<int> {0,(int)c2.StartingWeight,(int)c2.CurrentWeight};

            vm = new MyViewModel();
            vm.Add(DateTime.Now.Month, startWeight);
                
            chart.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.MyValue.Add(new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(i), currentWeight));
            i++;
        }

        ///*
        //public class Information
        //{
        //    public string Username { get; set; }
        //    public double CurrentWeight { get; set; }
        //    public double StartWeight { get; set; }
        //}
        //public class InformationCollection :
        //    Collection<Information>
        //{

        //}

        //public class ChartData
        //{
        //    public ChartData(string us,double? val)
        //    {
        //        User = us;
        //        Weight = val;
        //    }
        //    public string User ;
        //    public double? Weight;
        //}
        //*/
        //private void showChart()
        //{
        //    MyFitEntities context = new MyFitEntities();
        //    var c = (from s in context.Accounts
        //             where s.Username == AuthentificationWindow.currentUsername
        //             select s).First();

        //    var c1 = (from s in context.Goals
        //              where s.id_Goals == c.id_Account_Goals
        //              select s).First();
        //    var c2 = (from s in context.WeightGoals
        //              where s.id_WeightGoals == c1.id_Goals_WeightG
        //              select s).First();


        //   /* ObservableCollection<ChartData> MyValues = new ObservableCollection<ChartData>
        //    {
        //    //    new ChartData(c.Username, c2.StartingWeight),
        //      //  new ChartData(c.Username, c2.CurrentWeight)
        //      new ChartData("user1", 60),
        //    new ChartData("user1", 50)
        //    };
        //    */
        //    ObservableCollection<KeyValuePair<string, int>> MyValue = new ObservableCollection<KeyValuePair<string, int>>();
        //    MyValue.Add(new KeyValuePair<string, int>("user1", 60));
        //    MyValue.Add(new KeyValuePair<string, int>("user1", 40));

        //    LineChart1.DataContext = MyValue;

        //    //ShowDialog();

        //}
    }
}

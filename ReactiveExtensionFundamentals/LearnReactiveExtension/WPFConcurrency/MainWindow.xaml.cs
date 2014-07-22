using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFConcurrency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Producer query
        private static string StringWait(string str)
        {
            Thread.Sleep(250);
            return str;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var query = from number in Enumerable.Range(1, 25)
                        select StringWait(number.ToString(CultureInfo.InvariantCulture));

            //var observable = query.ToObservable(ThreadPoolScheduler.Instance); --TO make the thread running on thread pool, however, it will run into error coz of wpf thread affinity
            var observable = query.ToObservable(ThreadPoolScheduler.Instance); 
            observable
                .ObserveOn(DispatcherScheduler.Current)
                .Subscribe((x) => Results.AppendText(x + Environment.NewLine),
                            IamDone);

        }

        private void IamDone()
        {
            Results.AppendText("I am Done!");
        }
    }
}

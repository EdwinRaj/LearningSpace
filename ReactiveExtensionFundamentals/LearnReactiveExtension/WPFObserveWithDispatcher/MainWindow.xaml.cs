using System;
using System.Collections.Generic;
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

namespace WPFObserveWithDispatcher
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

        private IDisposable _subscribeDisposable;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TxtSequence.Clear();
            btnGenerate.IsEnabled = false;
            var query = from number in Enumerable.Range(
                int.Parse(TxtStart.Text)
                , int.Parse(TxtCount.Text)
                )
                select Slow(number);

            var observable = query.ToObservable()
                .SubscribeOn(ThreadPoolScheduler.Instance)          //All slow subscription thread runs on the background thread
                .ObserveOn(DispatcherSynchronizationContext.Current)    //OnNext,OnError,OnCompleted and Finally delegates run on dispatcher thread
                .Finally(() =>
                {
                    btnGenerate.IsEnabled = true;
                    btnStop.IsEnabled = false;
                });

            _subscribeDisposable = observable.Subscribe(n => TxtSequence.Text += n + " ");
            btnStop.IsEnabled = true;
        }

        private int Slow(int number)
        {
            Thread.Sleep(500);
            return number;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (_subscribeDisposable != null)
            {
                _subscribeDisposable.Dispose();
            }
            
        }
    }
}

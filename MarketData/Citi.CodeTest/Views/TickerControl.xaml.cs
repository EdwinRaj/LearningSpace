using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Citi.CodeTest.Utilities;
using Citi.CodeTest.ViewModels;

namespace Citi.CodeTest.Views
{
    /// <summary>
    /// Interaction logic for TickerControl.xaml
    /// </summary>
    public partial class TickerControl : UserControl
    {

        [Import]
        public ITickerViewModel TickerViewModel
        {
            get { return this.DataContext as ITickerViewModel; }
            set { this.DataContext = value; }
        }

        public TickerControl()
        {
            InitializeComponent();
            this.RegisterWithContainer();
        }


        public void Initialize(string symbol)
        {
            TickerViewModel.Initialise(symbol);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Citi.CodeTest.Views;

namespace Citi.CodeTest
{
    /// <summary>
    /// Interaction logic for TickerWindow.xaml
    /// </summary>
    public partial class TickerWindow : Window
    {
        public TickerWindow()
        {
            InitializeComponent();
        }

        public void Initialise(string symbol)
        {
            LocalTickerControl.Initialize(symbol);
        }
    }
}

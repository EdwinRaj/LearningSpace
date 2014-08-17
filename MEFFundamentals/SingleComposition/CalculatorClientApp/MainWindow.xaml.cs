using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
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
using MEFFundamentals;

namespace CalculatorClientApp
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

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var helper = new CompositionHelper();
            helper.Compose();

            int i = int.Parse(TxtNumber1.Text);
            int i1 = int.Parse(TxtNumber2.Text);
            int number = helper.CalcPlugin.GetNumber(i,i1);
            TxtResult.Text = number.ToString(CultureInfo.InvariantCulture);
        }

        private void SubtractButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void MultiplyButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void DivideButtonClick(object sender, RoutedEventArgs e)
        {

        }

        
    }
}

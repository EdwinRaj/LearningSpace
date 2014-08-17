using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Documents;
using Citi.CodeTest.Server;
using Citi.CodeTest.Utilities;
using Citi.CodeTest.ViewModels;

namespace Citi.CodeTest.Views
{
    /// <summary>
    /// Interaction logic for LaunchWindow.xaml
    /// </summary>
    public partial class LaunchView : UserControl
    {
        [Import]
        public ILaunchViewModel ViewModel
        {
            get { return this.DataContext as ILaunchViewModel; }
            set { this.DataContext = value; }
        }

        public LaunchView()
        {
            InitializeComponent();
            this.RegisterWithContainer();
        }

        /*
         public List<string> Symbols
        {
            get
            {
                return new List<string>()
                       {
                           "MSFT",
                           "Goog",
                           "yahoo"
                       };
            }
        }
            */
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Citi.CodeTest.ApplicationServices;
using Citi.CodeTest.Common;

namespace Citi.CodeTest.ViewModels
{
    
    public interface ILaunchViewModel
    {
        IEnumerable<string> Symbols { get; }
    }


    [Export(typeof(ILaunchViewModel))]
    public class LaunchViewModel:ILaunchViewModel
    {
        private IStockProviderService _stockProviderService;

        [ImportingConstructor]
        public LaunchViewModel(IStockProviderService stockProviderService)
        {
            this._stockProviderService = stockProviderService;
        }

        public IEnumerable<string> Symbols
        {
            get { return _stockProviderService.GetStockSymbols(); }
        }


        private ICommand _openTickerWindowCommand;

        

        public ICommand OpenTickerWindow
        {
            get
            {
                return _openTickerWindowCommand ?? (_openTickerWindowCommand = new RelayCommand<string>(ApplyOwnTickerWindowCommand));
            }
        }

        private void ApplyOwnTickerWindowCommand(string commandName)
        {
           var window = new TickerWindow();
            window.Initialise(commandName);
            window.Show();
        }
    }
}

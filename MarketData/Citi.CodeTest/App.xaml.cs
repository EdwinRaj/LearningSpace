using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Citi.CodeTest.ApplicationServices;
using Citi.CodeTest.Server;
using Citi.CodeTest.Utilities;
using Citi.CodeTest.ViewModels;

namespace Citi.CodeTest
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        //private static CompositionContainer _container;

        //[Import(typeof(IStockProviderService))]
        //private IStockProviderService _stockProviderService;

        //[Import(typeof(IStockProvider))]
        //private IStockProvider _stockProvider;

        //[Import(typeof(ILaunchViewModel))]
        //private ILaunchViewModel _launchViewModel;

	    protected override void OnStartup(StartupEventArgs e)
	    {
	        base.OnStartup(e);

            CompositionHelper.Compose();

            //var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(new DirectoryCatalog("."));
            //catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            //_container = new CompositionContainer(catalog);

            //try
            //{
            //    _container.ComposeParts(this);
            //}
            //catch (CompositionException compositionException)
            //{
            //    MessageBox.Show(compositionException.ToString());
            //}
	    }
	}


    
}

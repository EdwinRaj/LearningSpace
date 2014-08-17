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
using Citi.CodeTest.Utilities;

namespace Citi.CodeTest
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
	    protected override void OnStartup(StartupEventArgs e)
	    {
	        base.OnStartup(e);

            CompositionHelper.Compose();

           
	    }
	}


    
}

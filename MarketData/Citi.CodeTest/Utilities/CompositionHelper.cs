using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Citi.CodeTest.Utilities
{
    public static class CompositionHelper
    {
        private static CompositionContainer _container;

        internal static CompositionContainer Container
        {
            get
            {
                return _container;
            }
        }

        public static void Compose()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            _container = new CompositionContainer(catalog);
        }

    }
}

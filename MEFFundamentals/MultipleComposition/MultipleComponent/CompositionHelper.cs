using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MEFFundamentals
{
    public class CompositionHelper
    {
        //[Import(typeof(ICalculator))]
        //public ICalculator CalcPlugin { get; set; }

        [ImportMany(typeof(ICalculator))]
        public Lazy<ICalculator, IDictionary<string, object>>[] Plugins { get; set; }


        public ICalculator GetPlugin(string key)
        {
            foreach (var plugin in Plugins)
            {
                if (plugin.Metadata["Operation"].ToString().ToLowerInvariant() == key.ToLowerInvariant())
                {
                    return plugin.Value;
                }
            }
            throw new InstanceNotFoundException("Key is not found");
        }
        
        public void Compose()
        {
            //Step 1: Initializes a new instance of the 
            //        System.ComponentModel.Composition.Hosting.AssemblyCatalog class with the 
            //        current executing assembly.
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

            //Step 2: The assemblies obtained in step 1 are added to the CompositionContainer
            var container = new CompositionContainer(catalog);

            //Step 3: Composable parts are created here i.e. the Import and Export components 
            //        assembles here
            container.ComposeParts(this);
        }


    }
}

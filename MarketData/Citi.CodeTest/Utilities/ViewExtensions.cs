using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Citi.CodeTest.Utilities
{
    public static class ViewExtensions
    {
        public static void RegisterWithContainer(this UserControl viewControl)
        {
            try
            {
                var batch = new CompositionBatch();
                batch.AddPart(viewControl);
                CompositionHelper.Container.Compose(batch);
            }
            catch (CompositionException compositionException)
            {
                
                throw;
            }
        }
    }
}

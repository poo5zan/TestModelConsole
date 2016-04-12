using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole
{
    public static class Initialize
    {
        
        public static void Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            CompositionContainer container = MefLoader.Init(catalog.Catalogs);
            
       }
    }
}

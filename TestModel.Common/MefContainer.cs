using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;


namespace TestModel.Common
{
    public static class MefContainer
    {
        private static CompositionContainer _container;

        public static CompositionContainer Container { get { return _container; }
         }

        /// <summary>
        /// Registers Catalog parts
        /// </summary>
        /// <param name="catalog"></param>
        public static void LoadMefContainer(AggregateCatalog catalog) {

            _container = Init(catalog.Catalogs);
            //_container.ComposeParts(catalog);
            
        }

        /// <summary>
        /// Retrives Implementation Object for Contract
        /// </summary>
        /// <typeparam name="T">Contract(Interface)</typeparam>
        /// <returns></returns>
        public static T GetImplementationObject<T>()
        {            
            return _container.GetExportedValue<T>();
        }

        public static IEnumerable<T> GetImplementationObjects<T>()
        {
            return _container.GetExportedValues<T>();
        }        

        private static CompositionContainer Init(
          ICollection<ComposablePartCatalog> catalogParts)
        {
            AggregateCatalog catalog = new AggregateCatalog();

            if (catalogParts != null)
            {
                foreach (var part in catalogParts)
                {
                    catalog.Catalogs.Add(part);
                }
            }

            return new CompositionContainer(catalog);
        }
    }
}

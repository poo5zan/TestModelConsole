using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.DataAccess.Contracts;

namespace TestModel.DataAccess.Implementation.MongoDb
{
    [Export(typeof(IForSqlServer))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ForSqlDatabase : IForSqlServer
    {
        public string Display()
        {
            throw new NotImplementedException();
        }
    }
}

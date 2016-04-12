using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.DataAccess.Contracts;

namespace TestModel.DataAccess.Implementation.SqlDatabase
{
    [Export(typeof(IForMongoDb))]

    public class ForMongoDb : IForMongoDb
    {
        public string Display()
        {
            throw new NotImplementedException();
        }
    }
}

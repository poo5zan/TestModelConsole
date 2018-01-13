using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.Common.Attributes
{
    public class DbObjectInputParameterAttribute : Attribute
    {
        public string Name { get; set; }
        public DbObjectType DbObjectType { get; set; } = DbObjectType.StoredProcedure;
        public string UserDefinedDataTypeName { get; set; }
    }

    public enum DbObjectType
    {
        None = 0,
        StoredProcedure = 1,
        UserDefinedDataType = 2
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.BusinessLayer.Contracts;

namespace TestModel.BusinessLayer.SecondImplementation
{
    [Export(typeof(IUserManagementBusinessLayer))]
    public class UserManagementBusinessLayerSecond : IUserManagementBusinessLayer
    {
        public bool CreateUserBusinessLayer(string username)
        {
            return true;
        }
    }
}

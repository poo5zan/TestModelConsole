using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.BusinessLayer.Contracts;

namespace TestModel.BusinessLayer.Implementation
{
    [Export(typeof(IUserManagementBusinessLayer))]
    public class UserManagementBusinessLayer : IUserManagementBusinessLayer
    {
        public bool CreateUserBusinessLayer(string username)
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.BusinessLayer.Contracts;
using TestModel.DataAccess.Contracts;

namespace TestModel.BusinessLayer.Implementation
{
    [Export(typeof(IUserManagementBusinessLayer))]
    public class UserManagementBusinessLayer : IUserManagementBusinessLayer
    {


        [Import(typeof(IUserDataAccess))]
        public IUserDataAccess UserDataAccess { get; set; }

        //adding changes
        public bool CreateUserBusinessLayer(string username)
        {
            var p = UserDataAccess;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.BusinessLayer.Contracts;

namespace TestModelConsole
{
    [Export(typeof(IUserManagement))]
    public class UserManagement : IUserManagement
    {
        [Import]
        public IUserManagementBusinessLayer UserMgmtBusiness { get; set; }

        public bool CreateUser(string username)
        {
            var h = UserMgmtBusiness;

            if (String.IsNullOrWhiteSpace(username))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

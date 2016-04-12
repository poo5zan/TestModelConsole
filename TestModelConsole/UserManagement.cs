using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole
{
    [Export(typeof(IUserManagement))]
    public class UserManagement : IUserManagement
    {
        public bool CreateUser(string username)
        {
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

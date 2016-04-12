using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole
{
    [Export]
    public class Person
    {
        [Import(typeof(IUserManagement))]
        IUserManagement u;

        [ImportingConstructor]
        public Person(IUserManagement usr = null)
        {
            var o = 0; 
        }

        public bool CUser(string usr)
        {
            var p = u.CreateUser(usr);
            return p;
        }
    }
}

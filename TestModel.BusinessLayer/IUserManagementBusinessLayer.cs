using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.BusinessLayer.Contracts
{
    public interface IUserManagementBusinessLayer
    {
        bool CreateUserBusinessLayer(string username);
    }
}

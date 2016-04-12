using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.DataAccess.Objects;

namespace TestModel.DataAccess.Contracts
{
    public interface IUserDataAccess
    {
        UserDto GetUserByEmail(string email);
        List<UserDto> GetAllUsers();
    }
}

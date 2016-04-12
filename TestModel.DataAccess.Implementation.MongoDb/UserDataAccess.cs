using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.DataAccess.Contracts;
using TestModel.DataAccess.Objects;

namespace TestModel.DataAccess.Implementation.MongoDb
{
    [Export(typeof(IUserDataAccess))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserDataAccess : IUserDataAccess
    {
        public List<UserDto> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}

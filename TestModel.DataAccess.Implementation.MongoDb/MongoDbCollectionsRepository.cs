using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.DataAccess.Implementation.MongoDb
{
    public class MongoDbCollectionsRepository<T>
    {
        private MongoDbContext _mongoDbContext;
        public MongoDbCollectionsRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext ?? new MongoDbContext();
        }



    }
}

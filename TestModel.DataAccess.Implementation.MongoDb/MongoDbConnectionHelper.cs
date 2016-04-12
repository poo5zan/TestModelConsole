using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.DataAccess.Implementation.MongoDb
{
    public class MongoDbConnectionHelper
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        public MongoDbConnectionHelper()
        {
            _client = new MongoClient();
        }

        //public void ConnectDatabase()
        //{
        //   // _client = new MongoClient();
        //  //  _database = _client.GetDatabase("pujan");
        //}

        public IMongoDatabase GetDatabaseInstance(string databaseName)
        {
            return _client.GetDatabase(databaseName);
        }

    }
}

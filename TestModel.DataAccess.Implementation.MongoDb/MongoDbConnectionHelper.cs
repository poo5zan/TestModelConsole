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
        protected static IMongoClient _mongoClient;
        protected static IMongoDatabase _database;
        //public MongoDbConnectionHelper()
        //{
        //    _mongoClient = new MongoClient();
        //}

        //public void ConnectDatabase()
        //{
        //   // _client = new MongoClient();
        //  //  _database = _client.GetDatabase("pujan");
        //}

        public IMongoClient GetMongoClientInstance(string host,int port = 27017)
        {
             _mongoClient = new MongoClient(new MongoClientSettings()
            {
                Server = new MongoServerAddress(host,port)
            });
            return _mongoClient;
        }

        public IMongoDatabase GetDatabaseInstance(string databaseName)
        {
            return _mongoClient.GetDatabase(databaseName);
        }




    }
}

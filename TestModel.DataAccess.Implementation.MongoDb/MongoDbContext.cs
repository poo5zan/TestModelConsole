using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TestModel.DataAccess.Implementation.MongoDb
{
    public class MongoDbContext
    {
        private IMongoClient Client { get; set; }
        private IMongoDatabase Database { get; set; }
        //private static MongoDbContext _mongoDbContext;


        public MongoDbContext(string host="localhost", int port = 27017
            ,string dataBaseName = "MyDefaultMongoDb")
        {
            if (host == "localhost")
            {
                Client = new MongoClient();
            }
            else
            {
                Client = new MongoClient(new MongoClientSettings()
                {
                    Server = new MongoServerAddress(host,port)
                });
            }

            Database = Client.GetDatabase(dataBaseName);
        }

        public IMongoCollection<T> Collection<T>(string collectionName)
        {
            return Database.GetCollection<T>(collectionName);
        }

    }
}

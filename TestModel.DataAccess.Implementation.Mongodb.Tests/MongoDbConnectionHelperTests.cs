using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using TestModel.DataAccess.Implementation.MongoDb;
using TestModel.DataAccess.Objects;

namespace TestModel.DataAccess.Implementation.Mongodb.Tests
{
    [TestClass]
    public class MongoDbConnectionHelperTests
    {
        [TestMethod]
        public void GetMongoClientInstanceTest()
        {
            var mongoDbConnectionHelper = new MongoDbConnectionHelper();
            var mongoDbInstance = mongoDbConnectionHelper.GetMongoClientInstance(
                "192.168.56.101");
            Assert.IsNotNull(mongoDbInstance);
            Assert.AreEqual(typeof(MongoClient),mongoDbInstance.GetType());
        }

        [TestMethod]
        public void InsertDataTest()
        {
            var mongoDbConnectionHelper = new MongoDbConnectionHelper();
            var mongoDbInstance = mongoDbConnectionHelper.GetMongoClientInstance(
                "192.168.56.101");
            var database = mongoDbInstance.GetDatabase("myProducts");
            var collection = database.GetCollection<Product>("myProductsCollection");
            var product = new Product();
            //product.DocumentId = ObjectId.GenerateNewId();
            product.ProductId = 1;
            product.Sku = "erer-34";
            product.ThirdPartyIds = new List<ThirdPartyId>()
            {
                new ThirdPartyId()
                {
                    Value = "345r",
                    Type = "ASIN",
                    Platform = "Amazon"
                }
            };

            collection.InsertOne(product);

            var prodResponse = collection.Find(r => r.ProductId == 1).FirstOrDefault();
            Assert.IsNotNull(prodResponse);
            Assert.AreEqual(product.ProductId, prodResponse.ProductId);

        }
    }
}

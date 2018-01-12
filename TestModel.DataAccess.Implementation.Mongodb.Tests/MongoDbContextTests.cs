using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using TestModel.DataAccess.Implementation.MongoDb;
using TestModel.DataAccess.Objects;

namespace TestModel.DataAccess.Implementation.Mongodb.Tests
{
    [TestClass]
    public class MongoDbContextTests
    {

        [TestMethod]
        public void ConstructorTest()
        {
            //var mongoDbContext = 
        }

        [TestMethod]
        public void CollectionTest()
        {
            var mongoDbContext = new MongoDbContext("192.168.56.101",27017,"myApplicationDb");
            var productCollection = mongoDbContext.Collection<Product>("myProductsCollection");
            var product = new Product();
            //product.DocumentId = ObjectId.GenerateNewId();
            product.ProductId = 2;
            product.Sku = "hajk-34";
            product.ThirdPartyIds = new List<ThirdPartyId>()
            {
                new ThirdPartyId()
                {
                    Value = "3fda45r",
                    Type = "ASIN",
                    Platform = "Amazon"
                }
            };
            
            productCollection.InsertOne(product);
            var productRetrieved = productCollection.Find(x => x.ProductId == product.ProductId).FirstOrDefault();
            Assert.IsNotNull(productRetrieved);
            Assert.IsNotNull(productRetrieved.DocumentId);
            Assert.AreEqual(product.ProductId,productRetrieved.ProductId);

            var googleProdFilterCondition = Builders<Product>.Filter.ElemMatch(x => x.ThirdPartyIds,
                t => t.Platform == "Google");
            var googleProducts = productCollection.Find(googleProdFilterCondition).ToList();
            Assert.IsNotNull(googleProducts);
            var gp = googleProducts.Where(x => x.ThirdPartyIds.Exists(s => s.Platform == "Google"));
            Assert.IsNotNull(gp);

        }

        [TestMethod]
        public void GetQueriesTest()
        {
            var mongoDbContext = new MongoDbContext("192.168.56.101", 27017, "myApplicationDb");
            var productCollection = mongoDbContext.Collection<Product>("myProductsCollection");

            var allproducts = productCollection.Find(x => x.ProductId > 0).ToList();

        }
    }
}

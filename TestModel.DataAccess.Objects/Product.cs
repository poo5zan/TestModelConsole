using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace TestModel.DataAccess.Objects
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonElement(elementName: "_id")]
        public ObjectId DocumentId { get; set; }

        [BsonElement(elementName:"productId")]
        public Int64 ProductId { get; set; }

        [BsonElement(elementName:"sku")]
        public string Sku { get; set; }

        [BsonElement(elementName:"thirdPartyId")]
        public List<ThirdPartyId> ThirdPartyIds { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    [BsonIgnoreExtraElements]
    public class ThirdPartyId
    {
        [BsonElement(elementName:"platform")]
        public string Platform { get; set; }
        [BsonElement(elementName:"type")]
        public string Type { get; set; }
        [BsonElement(elementName:"value")]
        public string Value { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}

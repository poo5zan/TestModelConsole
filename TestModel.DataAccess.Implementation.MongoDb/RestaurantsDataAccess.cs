using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestModel.Common;
using TestModel.DataAccess.Objects;

namespace TestModel.DataAccess.Implementation.MongoDb
{
    public class RestaurantsDataAccess
    {
        private BsonDocument AddBsonDocumentForPrimitiveDataType(BsonDocument bsonDocument, PropertyInfo propertyInfo,Object sourceObject)
        {
            if (propertyInfo.PropertyType.FullName == "System.String")
            {
                bsonDocument.Add(propertyInfo.Name, propertyInfo.GetValue(sourceObject, null).ToString());
            }
            else if (propertyInfo.PropertyType.FullName == "System.Double")
            {
                bsonDocument.Add(propertyInfo.Name, Convert.ToDouble(propertyInfo.GetValue(sourceObject, null)));
            }
            else if (propertyInfo.PropertyType.FullName == "System.Int32")
            {
                bsonDocument.Add(propertyInfo.Name, Convert.ToInt32(propertyInfo.GetValue(sourceObject, null)));
            }
            return bsonDocument;
        }

        private BsonDocument AddBsonArrayForListDataType(BsonDocument bsonDocument, PropertyInfo propertyInfo, Object sourceObject)
        {
            if (propertyInfo.PropertyType.FullName.Contains("[System.String"))
            {
                List<string> values = (List<string>)propertyInfo.GetValue(sourceObject, null);
                bsonDocument.Add(propertyInfo.Name, new BsonArray(values));
            }
            else if (propertyInfo.PropertyType.FullName.Contains("[System.Double"))
            {
                List<Double> values = (List<Double>)propertyInfo.GetValue(sourceObject, null);
                bsonDocument.Add(propertyInfo.Name, new BsonArray(values));
            }
            else if (propertyInfo.PropertyType.FullName.Contains("[System.Int32"))
            {
                List<Int32> values = (List<Int32>)propertyInfo.GetValue(sourceObject, null);
                bsonDocument.Add(propertyInfo.Name, new BsonArray(values));
            }
            else if (propertyInfo.PropertyType.FullName.Contains("[System.Object"))
            {
                List<Object> values = (List<Object>)propertyInfo.GetValue(sourceObject, null);
                bsonDocument.Add(propertyInfo.Name, new BsonArray(values));
            }

            return bsonDocument;
        }

        public void CreateRestaurant(RestaurantDto rest)
        {
            var d = new BsonDocument();
            var r = GetBson(rest);
            Console.WriteLine(r);
            var o = 0;
        }

        //public void CreateRestaurant(RestaurantDto restaurantDto = null)
        //{
        //    List<PropertyInfo> sourceObjectProperties = restaurantDto.GetType().GetProperties().ToList<PropertyInfo>();
        //    var document = new BsonDocument();
        //    foreach (var propInfo in sourceObjectProperties)
        //    {
        //        //first separate system defined primitive types and custom objects
        //        if (propInfo.PropertyType.FullName.Contains("System."))
        //        {
        //            if (propInfo.PropertyType.FullName.Contains("System.Collections.Generic.List"))
        //            {
        //                //check if the list is of system defined
        //                if (propInfo.PropertyType.FullName.Contains("[System."))
        //                {
        //                    ////add the list as bson array to parent doc
        //                    AddBsonArrayForListDataType(document, propInfo, restaurantDto);
        //                    // Console.WriteLine(r.PropertyType.FullName + " dot net framework list System");
        //                }
        //                else
        //                {
        //                    //do nothing here, as the function will be called again
        //                    //for each element in list,create bsondocument
        //                    //recursive call
        //                    Console.WriteLine(propInfo.PropertyType.FullName + " user defined");
        //                    List<PropertyInfo> propertyInfos = propInfo.GetValue(restaurantDto, null).GetType().GetProperties().ToList<PropertyInfo>();
        //                    var childDoc1 = new BsonDocument();
        //                    foreach (var pro in propertyInfos)
        //                    {
        //                        if (pro.PropertyType.FullName.Contains("System."))
        //                        {
        //                            if (pro.PropertyType.FullName.Contains("System.Collections.Generic.List"))
        //                            {
        //                                if (pro.PropertyType.FullName.Contains("[System."))
        //                                {
        //                                    ////add the list as bson array to parent doc
        //                                    AddBsonArrayForListDataType(childDoc1, pro, propInfo.GetValue(restaurantDto, null));
        //                                    // Console.WriteLine(r.PropertyType.FullName + " dot net framework list System");
        //                                }
        //                                else
        //                                {
        //                                    //user defined
        //                                }
        //                            }
        //                            else
        //                            {
        //                                AddBsonDocumentForPrimitiveDataType(childDoc1, pro, propInfo.GetValue(restaurantDto, null));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            //again another user defined
        //                        }
        //                    }

        //                    document.Add(propInfo.Name, childDoc1);
        //                    Console.WriteLine(propInfo.PropertyType.FullName + "dot net framework list user defined");
        //                }
        //            }
        //            else
        //            {
        //                AddBsonDocumentForPrimitiveDataType(document, propInfo, restaurantDto);
        //                // Console.WriteLine(r.PropertyType.FullName + " dot net framework");
        //            }
        //        }
        //        else
        //        {
        //            //do nothing , call the function recursively
        //            Console.WriteLine(propInfo.PropertyType.FullName + " user defined");
        //            List<PropertyInfo> propertyInfos = propInfo.GetValue(restaurantDto,null).GetType().GetProperties().ToList<PropertyInfo>();
        //            var childDoc1 = new BsonDocument();
        //            foreach (var pro in propertyInfos)
        //            {
        //                if (pro.PropertyType.FullName.Contains("System."))
        //                {
        //                    if (pro.PropertyType.FullName.Contains("System.Collections.Generic.List"))
        //                    {
        //                        if (pro.PropertyType.FullName.Contains("[System."))
        //                        {
        //                            ////add the list as bson array to parent doc
        //                            AddBsonArrayForListDataType(childDoc1, pro, propInfo.GetValue(restaurantDto, null));
        //                            // Console.WriteLine(r.PropertyType.FullName + " dot net framework list System");
        //                        }
        //                        else {
        //                            //user defined
        //                            ///
        //                            Console.WriteLine(propInfo.PropertyType.FullName + " user defined");
        //                            List<PropertyInfo> propertyInfos2 = propInfo.GetValue(restaurantDto, null).GetType().GetProperties().ToList<PropertyInfo>();
        //                            var childDoc2 = new BsonDocument();
        //                            foreach (var pro2 in propertyInfos)
        //                            {
        //                                if (pro2.PropertyType.FullName.Contains("System."))
        //                                {
        //                                    if (pro2.PropertyType.FullName.Contains("System.Collections.Generic.List"))
        //                                    {
        //                                        if (pro2.PropertyType.FullName.Contains("[System."))
        //                                        {
        //                                            ////add the list as bson array to parent doc
        //                                            AddBsonArrayForListDataType(childDoc1, pro2, propInfo.GetValue(restaurantDto, null));
        //                                            // Console.WriteLine(r.PropertyType.FullName + " dot net framework list System");
        //                                        }
        //                                        else
        //                                        {
        //                                            //user defined
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        AddBsonDocumentForPrimitiveDataType(childDoc1, pro2, propInfo.GetValue(restaurantDto, null));
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    //again another user defined
        //                                }
        //                            }

        //                            document.Add(propInfo.Name, childDoc2);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        AddBsonDocumentForPrimitiveDataType(childDoc1, pro, propInfo.GetValue(restaurantDto,null));
        //                    }
        //                }
        //                else {
        //                    //again another user defined
        //                }
        //            }

        //            document.Add(propInfo.Name, childDoc1);
        //        }
        //    }

        //    Console.WriteLine(document);

        //    //var restDoc = new BsonDocument() {
        //    //    { PropertySupport.ExtractPropertyName(() => restaurantDto.Address).ToString(),restaurantDto.Address.ToString()}
        //    //};

        //    //var document = new BsonDocument {
        //    //    { "address",new BsonDocument {
        //    //        { "street","patan" },
        //    //        { "building","pujan"},
        //    //        { "coord",new BsonArray { 73.3,89.3,"pujan"} }
        //    //    } },
        //    //    { "name","my rest"},
        //    //    { "grades",new BsonArray {
        //    //        new BsonDocument {
        //    //            { "date",new DateTime(2016,3,4,0,0,0,DateTimeKind.Utc)},
        //    //            {"grade","A" },
        //    //            { "score",44}
        //    //        },
        //    //        new BsonDocument {
        //    //            { "date",new DateTime(2014,4,4,4,4,4,DateTimeKind.Utc)}
        //    //        }
        //    //    } }
        //    //};

        //    //var d = new BsonDocument();
        //    //d.Add(new BsonElement("address",new BsonDocument() {
        //    //    new BsonElement("street", "patan"),
        //    //    new BsonElement("name","pujan")
        //    //}));
        //    //d.Add(new BsonElement("mobile","889889"));
            
        //    //var li = new List<object>() { 34,"4545","89.3434","pujan"};
        //    //var bar = new BsonArray(li);
        //    //d.Add("hel", bar);
           
        //    //var doc = new BsonDocument("haha","beauty");

        //    var p = 3;


        //    //var doc = new BsonDocument() {
        //    //    { "name","[{1,2}]"}
        //    //};

        //    //var collection = new MongoDbConnectionHelper().GetDatabaseInstance("pujan").GetCollection<BsonDocument>("restaurants");
        //   // collection.InsertOne(d);

        //}

        private BsonDocument GetBson(Object sourceObject,BsonDocument document = null)
        {
            if (document == null) { document = new BsonDocument(); }
            List<PropertyInfo> sourceObjectProperties = sourceObject.GetType().GetProperties().ToList<PropertyInfo>();
            //var document = new BsonDocument();
            foreach (var propInfo in sourceObjectProperties)
            {
                //first separate system defined primitive types and custom objects
                if (propInfo.PropertyType.FullName.Contains("System."))
                {
                    if (propInfo.PropertyType.FullName.Contains("System.Collections.Generic.List"))
                    {
                        //check if the list is of system defined
                        if (propInfo.PropertyType.FullName.Contains("[System."))
                        {
                            ////add the list as bson array to parent doc
                            AddBsonArrayForListDataType(document, propInfo, sourceObject);
                            // Console.WriteLine(r.PropertyType.FullName + " dot net framework list System");
                        }
                        else
                        {
                            //do nothing here, as the function will be called again
                            //for each element in list,create bsondocument
                            //recursive call
                            Console.WriteLine(propInfo.PropertyType.FullName + " user defined");
                            //List<PropertyInfo> propertyInfos = propInfo.GetValue(sourceObject, null).GetType().GetProperties().ToList<PropertyInfo>();
                           // var childDoc2 = new BsonDocument();
                            GetBson(propInfo.GetValue(sourceObject, null), document);
                           // document.Add(propInfo.Name, childDoc2);
                                                       
                        }
                    }
                    else
                    {
                        AddBsonDocumentForPrimitiveDataType(document, propInfo, sourceObject);
                       // Console.WriteLine(propInfo.PropertyType.FullName + " dot net framework");
                    }
                }
                else
                {
                    //do nothing , call the function recursively
                    Console.WriteLine(propInfo.PropertyType.FullName + " user defined");
                    // List<PropertyInfo> propertyInfos = propInfo.GetValue(restaurantDto, null).GetType().GetProperties().ToList<PropertyInfo>();
                   // var childDoc = new BsonDocument();
                    GetBson(propInfo.GetValue(sourceObject, null), document);
                   // document.Add(propInfo.Name, childDoc);

                   // document.Add(propInfo.Name, childDoc1);
                }
            }
            return document;
        }

    }
}

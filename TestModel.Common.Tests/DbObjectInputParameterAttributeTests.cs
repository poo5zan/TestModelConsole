﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestModel.Common.Tests.Extensions;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using TestModel.Common.Attributes;
using TestModel.Common.Extensions;

namespace TestModel.Common.Tests
{   
    public class Person
    {
        [DbObjectInputParameter]
        public string Name { get; set; }
        public int Age { get; set; }
        [DbObjectInputParameter(Name = "DOB")]
        public DateTime DateOfBirth { get; set; }
        
        [DbObjectInputParameter(Name = "AnotherPersonParam", DbObjectType = DbObjectType.UserDefinedDataType, UserDefinedDataTypeName = "AnotherPersonUdt")]
        public List<AnotherPerson> ArkoPerson { get; set; }
    }

    public class AnotherPerson
    {
        public int Id { get; set; }
        public string NewParam { get; set; }
    }

    [TestClass]
    public class DbObjectInputParameterAttributeTests
    {
        [TestMethod]
        public void CheckProperties()
        {
            var person = new Person()
            {
                Name = "pujan",
                Age = -13,
                DateOfBirth = DateTime.Now,
                ArkoPerson = new List<AnotherPerson>()
                { new AnotherPerson() { Id = 4, NewParam = "Lov" },
                new AnotherPerson(){ NewParam = "helo"} }
            };

            var param = person.ToDbObjectInputParameters();
            //var p = GetDbObjectInputParameters(person);
            var s = 0;
        }
        
        public Dictionary<string, object> GetDbObjectInputParameters(Object obj)
        {
            if (obj == null) { throw new ArgumentNullException(); }
            var parameters = new Dictionary<string, object>();
            var propertiesWithDbObjInputParam = from p in obj.GetType().GetProperties()
                                                let attr = p.GetCustomAttributes(typeof(DbObjectInputParameterAttribute), true)
                                                where attr.Length == 1
                                                select new { Property = p, Attribute = attr.First() as DbObjectInputParameterAttribute };

            if (propertiesWithDbObjInputParam == null ||
                !propertiesWithDbObjInputParam.Any())
            {
                return parameters;
            }

            foreach (var property in propertiesWithDbObjInputParam)
            {
                var parameterName = "";
                if (!String.IsNullOrWhiteSpace(property?.Attribute?.Name))
                {
                    parameterName = property?.Attribute?.Name;
                }
                else
                {
                    parameterName = property.Property.Name;
                }
                object parameterValue = null;
                if (property.Attribute.DbObjectType == DbObjectType.StoredProcedure)
                {
                    parameterValue = property.Property.GetValue(obj);
                }
                else if (property.Attribute.DbObjectType == DbObjectType.UserDefinedDataType)
                {
                    var objEnumerable = (IEnumerable<Object>)property.Property.GetValue(obj);
                    parameterValue = objEnumerable?.ToDataTable(property.Attribute.UserDefinedDataTypeName) ;
                }
                parameters.Add("@" + parameterName, parameterValue);
            }

            return parameters;
        }
               
    }
}

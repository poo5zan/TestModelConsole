using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using PapaParse.Net;
using System.Collections.Generic;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class FileParserTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string filename = @"\\manaslu\WebApp\testcsv\sulabh\secondbackup\sambridhi_ProductExport06052017.csv";//@"D:\asinupdate.txt";
            // Parse single file
            using (FileStream stream = File.OpenRead(filename))
            {
                Papa.parse(stream, new Config()
                {
                    complete = (parsed) =>
                    {
                        List<List<string>> rows = parsed.data;
                        var p = 0;
                    },
                    error = (e) => {
                        var errr = 0;
                    }                    
                });
            }
        }
    }
}

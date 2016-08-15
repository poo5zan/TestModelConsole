﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModule.Logging.Tests
{
    [TestClass]
    public class LoggingServiceTests
    {
        [TestMethod]
        public void Write_should_write_log()
        {
            string directoryPath = @"c:\SomeLogs";
            string filePath = @"c:\SomeLogs\myLog";
           
            //clear the file and directory
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath,true);
            }

            ILoggingService loggingService = new LoggingService(filePath);

            loggingService.Write(new ObjectToWriteInLog()
            {
                Id = 1,
                Name = "Pujan"
            },LogLevel.Info,typeof(LoggingServiceTests),true);

            if (!Directory.Exists(directoryPath))
            {
                Assert.Fail("Directory not created");
            }
            //TODO: read file and verify but will do later
            //manually check if file exists, as filename would be dynamic

            loggingService.Write("me",LogLevel.Debug,typeof(LoggingServiceTests),true);
            loggingService.Write(123,LogLevel.Debug,typeof(LoggingServiceTests),true);
            loggingService.Write(34.34,LogLevel.Error,typeof(LoggingServiceTests),true);
            loggingService.Write("me", LogLevel.Debug, typeof(LoggingServiceTests));
            loggingService.Write(123, LogLevel.Debug, typeof(LoggingServiceTests));
            loggingService.Write(34.34, LogLevel.Error, typeof(LoggingServiceTests));
        }

        public class ObjectToWriteInLog
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}

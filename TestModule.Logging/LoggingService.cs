﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace TestModule.Logging
{
    public class LoggingService : ILoggingService
    {
        private PatternLayout _layout = new PatternLayout();
        private const string LogPattern = "%d %c -- %m%n";
        private static string DefaultFilePath = @"C:\AppLogs\appLog";
        private static List<string> _defaultDotnetTypes;


        public string DefaultPattern => LogPattern;

        //public LoggingService()
        //{
        //    _layout.ConversionPattern = DefaultPattern;
        //    _layout.ActivateOptions();
        //}

        public PatternLayout DefaultLayout => _layout;

        public void AddAppender(IAppender appender)
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.AddAppender(appender);
        }

        public LoggingService(string filePathToSaveLog = "")
        {
            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = LogPattern;
            // patternLayout.Header = "[Header]\\r\\n";
            // patternLayout.Footer = "[Footer]\\r\\n";
            patternLayout.ActivateOptions();

            TraceAppender tracer = new TraceAppender();
            tracer.Layout = patternLayout;
            tracer.ActivateOptions();

            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.AddAppender(tracer);

            RollingFileAppender roller = new RollingFileAppender();
            //roller.LockingModel = 
            roller.File = string.IsNullOrWhiteSpace(filePathToSaveLog) ? DefaultFilePath : filePathToSaveLog;
            roller.AppendToFile = true;
            roller.DatePattern = ".yyyyMMdd.lo\\g";
            roller.RollingStyle = RollingFileAppender.RollingMode.Date;
            roller.StaticLogFileName = false;
            roller.Layout = patternLayout;
            roller.AppendToFile = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;

            _layout.ConversionPattern = DefaultPattern;
            _layout.ActivateOptions();

            LoadDefaultDotNetTypes();

        }


        public static ILog Create(Type type = null)
        {
            if (type != null)
            {
                return LogManager.GetLogger(type);
            }
            else
            {
                return LogManager.GetLogger(typeof(LoggingService));
            }
        }

        /// <summary>
        /// Writes Log to file
        /// </summary>
        /// <param name="message">Message to Log</param>
        /// <param name="writeAllObjectProperties"></param>
        /// <param name="exception">Exception</param>
        /// <param name="logLevel">LogLevel 
        /// </param>
        /// <param name="type">Type of Logger , simply Class Name of calling code</param>
        public void Write(object message,
            LogLevel logLevel = LogLevel.None,
            Type type = null,
            bool writeAllObjectProperties = false,
            Exception exception = null)
        {
            ILog log = Create(type);

            StringBuilder stringBuilder = new StringBuilder();
            if (writeAllObjectProperties &&
                !_defaultDotnetTypes.Contains(message.GetType().Name))
            {
                //if(message.GetType().Name)
                
                List<PropertyInfo> propertyInfos =
                    message.GetType().GetProperties().ToList<PropertyInfo>();
                
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    stringBuilder.Append(propertyInfo.Name);
                    stringBuilder.Append("=");
                    stringBuilder.Append(propertyInfo.GetValue(message, null));
                    stringBuilder.Append(",");
                }
                message += " ,Object Values:" + stringBuilder.ToString();
            }

            switch (logLevel)
            {
                case LogLevel.Debug:
                    log.Debug(message, exception);
                    break;
                case LogLevel.Info:
                    log.Info(message, exception);
                    break;
                case LogLevel.Warn:
                    log.Warn(message, exception);
                    break;
                case LogLevel.Error:
                    log.Error(message, exception);
                    break;
                case LogLevel.Fatal:
                    log.Fatal(message, exception);
                    break;
                case LogLevel.None:
                    log.Error(message);
                    break;
                default:
                    log.Info(message);
                    break;
            }
        }

        void LoadDefaultDotNetTypes()
        {
            if (_defaultDotnetTypes == null)
            {
                _defaultDotnetTypes = new List<string>() {"String","Int32",
                    "Int64","Decimal","Double" };
                
            }

        }

    }
}

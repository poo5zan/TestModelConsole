using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModule.Logging
{
    public interface ILoggingService
    {
        /// <summary>
        /// Writes Log to file
        /// </summary>
        /// <param name="message">Message to Log</param>
        /// <param name="writeAllObjectProperties">true:writes all the values of object</param>
        /// <param name="exception">Exception</param>
        /// <param name="logLevel">LogLevel 
        /// </param>
        /// <param name="type">Type of Logger , simply Class Name of calling code</param>
        void Write(object message,
            LogLevel logLevel = LogLevel.None,
            Type type = null,
            bool writeAllObjectProperties = false,
            Exception exception = null);
    }
}

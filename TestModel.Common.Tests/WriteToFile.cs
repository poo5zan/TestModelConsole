using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class WriteToFile
    {
        [TestMethod]
        public void Write()
        {
            string path = @"C:\AppLogs\log.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("hahahah");
            }
        }

    }
}

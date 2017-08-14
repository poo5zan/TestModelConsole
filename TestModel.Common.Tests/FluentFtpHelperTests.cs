using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestModule.Ftp;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class FluentFtpHelperTests
    {
        [TestMethod]
        public void GetLists()
        {
            FluentFtpHelper f = new FluentFtpHelper();
            f.GetFtpList();
        }
    }
}

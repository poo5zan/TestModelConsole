using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole.Test
{
    [TestClass]
    public class DownloadHelperTest
    {
        [TestMethod]
        public void DownloadFileInChunk()
        {
            StringBuilder outputString = new StringBuilder();
            string url = @"http://www.greekgear.com/inarush/catalog.xml";
            var req = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                using (var resp = req.GetResponse())
                {
                    using (var stream = resp.GetResponseStream())
                    {
                        //100KB
                        byte[] buffer = new byte[102400];
                        int len;
                       
                        while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            //var p = 0;
                            var readString = Encoding.UTF8.GetString(buffer);
                            outputString.Append(readString);
                            Debug.WriteLine(readString);
                            if (readString.Contains("<Item ID=")) {
                                //supposedly end of table schema
                                throw new Exception("End this");
                            }                           
                            //exit operation if table end tag is found                             
                        }
                    }
                }
            }
            catch (Exception)
            {
                //just engulf the exception
                //throw;
            }

            //will complete the xml with </catalog> end tag
            Debug.WriteLine(outputString.ToString());

        }
    }
}

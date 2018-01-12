using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Framework.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class EdiParserTests
    {
        [TestMethod]
        public void LetsTestEdiParser()
        {

            var filePath = @"D:\EDI 846 Sample(1).txt";
            List<string> columns = new List<string>()
            {
                "LIN_SerialNumber","LIN_SK","LIN_UP","PID_F","QTY_SQ","QTY_SQ_UNIT","DTM_CODE","DTM_DATE"
            };
            List<string> segments = new List<string>()
            {
                "LIN","PID","QTY","DTM"
            };

            DataTable dt = new DataTable("someTable");
            columns.Distinct().ToList().ForEach(x => dt.Columns.Add(x));

            string rootNode = "LIN";
            string line = "";
            StreamReader reader = new StreamReader(filePath);
            DataRow dr = null;
            line = reader.ReadLine();
            while (line != null)
            {
                var segmentInLine = segments.FirstOrDefault(x => line.Contains(x));
                if (segmentInLine != null)
                {
                    var dataArray = line.Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
                    switch (segmentInLine)
                    {
                        case "LIN":
                            if (dr != null)
                            {
                                //add previous LIN to row
                                dt.Rows.Add(dr);
                                //dr = null;
                            }
                            //Create new row for LIN
                            dr = dt.NewRow();
                            for (int i = 0; i < dataArray.Length; i += 2)
                            {
                                if (dataArray[i] == "LIN")
                                {
                                    if (dt.Columns.Contains("LIN_SerialNumber"))
                                    {
                                        dr["LIN_SerialNumber"] = dataArray[i + 1];
                                    }
                                }
                                else
                                {
                                    if (dt.Columns.Contains("LIN_" + dataArray[i]))
                                    {
                                        dr["LIN_" + dataArray[i]] = dataArray[i + 1];
                                    }
                                }
                            }
                            break;

                        case "PID":
                            for (int i = 1; i < dataArray.Length; i += 2)
                            {
                                if (dt.Columns.Contains("PID_" + dataArray[i]))
                                {
                                    dr["PID_" + dataArray[i]] = dataArray[i + 1];
                                }
                            }
                            break;

                        case "QTY":
                            if (dt.Columns.Contains("QTY_SQ"))
                            {
                                dr["QTY_SQ"] = dataArray[2];
                            }
                            if (dt.Columns.Contains("QTY_SQ_UNIT"))
                            {
                                dr["QTY_SQ_UNIT"] = dataArray[3];
                            }
                            break;
                            
                        case "DTM":
                            if (dt.Columns.Contains("DTM_CODE"))
                            {
                                dr["DTM_CODE"] = dataArray[1];
                            }
                            DateTime d2 = default(DateTime);
                            DateTime.TryParseExact(dataArray[2], "yyyyMMdd",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out d2);
                            if (dt.Columns.Contains("DTM_DATE"))
                            {
                                dr["DTM_DATE"] = d2;
                            }
                            break;
                    }
                }
                line = reader.ReadLine();
                if (line == null)
                {
                    if (dr != null)
                    {
                        //add previous LIN to row
                        dt.Rows.Add(dr);
                    }
                }
            }

            var p = 0;
          
        }

    }
}

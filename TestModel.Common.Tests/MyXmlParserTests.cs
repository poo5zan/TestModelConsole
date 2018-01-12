using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class MyXmlParserTests
    {

        [TestMethod]
        public void ReadXmlTests()
        {
            //etlConfiguration
            string tableNameInitials = "iAmTable";
            //if google as import and rss feed, then
            // replace : with _ in columnname
            bool isGoogleProductAsImport = false;
            bool isGooglePromotionShipmentLevelCharges = true;
            var guid = Guid.NewGuid().ToString();

            bool useAttributeNameAsColumnName = true; //else use attributeValueAsColumnName
            
            string tableName = tableNameInitials + "_" + guid.Replace('-', '_');
            string xmlFile = @"D:\ClientOnboarding\NeimanMarcus\nmarcus\1_LC_pricing_active_promo_full_20170120_001815.xml\1_LC_pricing_active_promo_full_20170120_001815.xml";
                //@"D:\ClientOnboarding\NeimanMarcus\nmarcus\1_LC_google_sku_catalog_20170120_001815.xml\1_LC_google_sku_catalog_20170120_001815.xml";
                //@"\\langtang\UDH\ClientOnboarding\NeimanMarcus\1_LC_google_sku_catalog_20170120_001815.xml";
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Async = true;
            string rowLevelRootNode = "item";
            //product catalog
            //var columns = new List<string>()
            //{
            //    "g_id","g_title","g_description",
            //    "c_flg_sr_eligible","c_nmg_order_management_id",
            //    "g_color","g_size"
            //};

            //pricing/promotion
            var columns = new List<string>()
            {
                "item_id","delivery_processing_charges",
                "shipment_level_charges_SL1","shipment_level_charges_SL3",
                "currency","currency_code",
                "regular_price","sale_price","promotion",
                "promo_key","promo_code","product_page_html"
            };

            DataTable dt = new DataTable("pgoogle");
            foreach (var column in columns)
            {
                //if google as import (RSS feeed)
                if (isGoogleProductAsImport)
                {
                    dt.Columns.Add(column.Replace(":", "_"), typeof(string));
                }
                else
                {
                    dt.Columns.Add(column, typeof(string));
                }
            }
            
            //create table
            string connectionString = @"Data Source=.; Initial Catalog=Pujan; Integrated Security=True;MultipleActiveResultSets=True;";
            // @"Data Source=langtang\sql12; Initial Catalog= DEV_GBD_UDH_REARCH; Integrated Security=False; User ID=dh_admin;Password=GBD@dh_ad; MultipleActiveResultSets=True;";

            string name = "";
            string value = "";
            string attributeName = "";
            string attributeValue = "";
            DataRow row = null;
            bool isColumnAvailable = false;

            Trace.WriteLine("Start Xml Reader " + DateTime.Now);

           
            using (XmlReader reader = XmlReader.Create(xmlFile))
            {
                while (reader.Read())//reader.MoveToNextAttribute() || 
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == rowLevelRootNode)
                        {
                            row = dt.NewRow();
                        }
                        if (isGoogleProductAsImport)
                        {
                            name = reader.Name.Replace(":", "_");
                        }
                        else
                        {
                            name = reader.Name;
                        }
                        if (columns.Contains(name))
                        {
                            isColumnAvailable = true;
                        }

                        //attributes
                        if (reader.HasAttributes)
                        {
                            var attributeNames = new Dictionary<string,string>();

                            for (int i = 0; i < reader.AttributeCount; i ++)
                            {
                                reader.MoveToAttribute(i);
                                attributeName = reader.Name;
                                attributeValue = reader.Value;
                                attributeNames.Add(attributeName,attributeValue);
                            }

                            //construct column name// for googlePromotionShipmentLevelCharges
                            if (isGooglePromotionShipmentLevelCharges)
                            {
                                string columnName = name + "_" + (attributeNames.ContainsKey("LEVEL") 
                                    ? attributeNames["LEVEL"]: "");

                                if (columns.Contains(columnName))
                                {
                                    isColumnAvailable = true;
                                }

                                if (isColumnAvailable)
                                {
                                    if (row != null)
                                    {
                                        row[columnName] = attributeValue;
                                        isColumnAvailable = false;
                                    }
                                }
                            }

                        }
                        reader.Read();
                        if (reader.NodeType == XmlNodeType.CDATA)
                        {
                            value = "<![CDATA[" + reader.Value + "]]>";
                        }
                        else
                        {
                            value = reader.Value;
                        }

                        if (isColumnAvailable)
                        {
                            if (row != null)
                            {
                                row[name] = value;
                                isColumnAvailable = false;
                            }
                        }
                    }

                    //if (reader.NodeType == XmlNodeType.Attribute)
                    //{
                    //    name = reader.Name;
                        
                    //    if (columns.Contains(name))
                    //    {
                    //        isColumnAvailable = true;
                    //    }

                    //   // reader.Read();
                    //    if (reader.NodeType == XmlNodeType.CDATA)
                    //    {
                    //        value = "<![CDATA[" + reader.Value + "]]>";
                    //    }
                    //    else
                    //    {
                    //        value = reader.Value;
                    //    }

                    //    if (isColumnAvailable)
                    //    {
                    //        if (row != null)
                    //        {
                    //            row[name] = value;
                    //            isColumnAvailable = false;
                    //        }
                    //    }
                    //}

                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == rowLevelRootNode)
                        {
                            if (row != null)
                            {
                                dt.Rows.Add(row);
                            }
                        }
                    }

                }
            }
            Trace.WriteLine("End Xml Reader " + DateTime.Now);
            //hello pujan
            var p = 0;


            Trace.WriteLine("Start Bulk Copy " + DateTime.Now);
            try
            {
                //just skip for other xml testing
                //using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
                //{
                //    bulkCopy.DestinationTableName = "dbo.pgoogle";
                //    bulkCopy.BatchSize = 2000;
                //    bulkCopy.WriteToServer(dt);

                //}

            }
            catch (Exception ex)
            {
                var i = 0;
                throw;
            }

            Trace.WriteLine("End Bulk Copy " + DateTime.Now);

        }

    }
}

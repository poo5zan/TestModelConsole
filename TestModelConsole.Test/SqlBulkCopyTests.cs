using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TestModelConsole.Test
{
    [TestClass]
    public class SqlBulkCopyTests
    {
        [TestMethod]
        public void SqlBulkCopyToDumpCsvToTable()
        {
            try
            {
                Debug.WriteLine("Starting");
                string filename = @"\\langtang\UDH\puj\pimproduct_sep_5_2017.csv";
                string connectionString = @"Data Source=langtang\sql12; Initial Catalog= DEV_GBD_UDH_REARCH; Integrated Security=False; User ID=dh_admin;Password=GBD@dh_ad; MultipleActiveResultSets=True;";

                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                //SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (StreamReader file = new StreamReader(filename))
                    {
                        CsvReader csv = new CsvReader(file, true,',');

                        using (SqlBulkCopy copy = new SqlBulkCopy(conn))
                        {
                            //, SqlBulkCopyOptions.KeepIdentity, transaction);
                            copy.DestinationTableName = "pujan";
                            copy.BulkCopyTimeout = 0;
                            Debug.WriteLine("Bulkcopy started = " + DateTime.Now);
                            copy.BatchSize = 2000;
                            copy.WriteToServer(csv);
                            //transaction.Commit();
                            Debug.WriteLine("Bulkcopy ended = " + DateTime.Now);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                   // transaction.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                var p = 0;
                throw;
            }
        }
    }
}

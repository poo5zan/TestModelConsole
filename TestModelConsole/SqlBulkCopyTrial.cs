using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole
{
    public class SqlBulkCopyTrial
    {
        public void SqlBulkCopyToDumpCsvToTable()
        {
            Console.WriteLine("Starting");
            string filename = @"\\langtang\UDH\puj\pimproduct_sep_5_2017.csv";
            string connectionString = @"Data Source=langtang\sql12; Initial Catalog= DEV_GBD_UDH_REARCH; Integrated Security=False; User ID=dh_admin;Password=GBD@dh_ad; MultipleActiveResultSets=True;";

            //SqlConnection conn = new SqlConnection(connectionString);
            // conn.Open();

            //SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (StreamReader file = new StreamReader(filename))
                    {
                        CsvReader csv = new CsvReader(file, true, ',');

                        using (SqlBulkCopy copy = new SqlBulkCopy(conn))
                        {
                            //, SqlBulkCopyOptions.KeepIdentity, transaction);
                            copy.DestinationTableName = "pujan";
                            copy.BulkCopyTimeout = 0;
                            //copy.NotifyAfter = 2000;
                            //copy.SqlRowsCopied += Copy_SqlRowsCopied;                            
                            Console.WriteLine("Bulkcopy started = " + DateTime.Now);
                            copy.BatchSize = 2000;
                            copy.WriteToServer(csv);
                            //transaction.Commit();
                            Console.WriteLine("Bulkcopy ended = " + DateTime.Now);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // transaction.Rollback();
            }
            finally
            {
                //conn.Close();
            }
        }

        private void Copy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine("Rows copied = " + e.RowsCopied + ", time = " + DateTime.Now);
            //throw new NotImplementedException();
        }
    }
}


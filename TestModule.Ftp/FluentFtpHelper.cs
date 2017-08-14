using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace TestModule.Ftp
{
    public class FluentFtpHelper
    {

        public void GetFtpList()
        {
            FtpClient client = new FtpClient("bi.exclusiveconcepts.com");

            // if you don't specify login credentials, we use the "anonymous" user account
            client.Credentials = new NetworkCredential("gbd", "`Gbd!230$");
            try
            {
                client.EncryptionMode = FtpEncryptionMode.Explicit;
                client.SslProtocols = SslProtocols.Tls;
                client.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);
                // begin connecting to the server
                client.Connect();

                
                // upload a file
                //client.UploadFile(@"\\annapurna\Public\Pujan\!!SF!!0015000000b1NZt!!SF!!!!D!!2017-07-26-12-08-35!!D!!.tsv", "jptFolder/pujan22",createRemoteDir:true);
               // client.UploadFile(@"\\annapurna\Public\Pujan\!!SF!!0015000000bw6Jd!!SF!!!!D!!2017-07-25-11-57-38!!D!!.tsv", "!!SF!!0015000000bw6Jd!!SF!!!!D!!2017-07-25-11-57-38!!D!!.tsv");
                //client.UploadFile(@"\\annapurna\Public\Pujan\!!SF!!0015000000iKUac!!SF!!!!D!!2017-07-25-11-20-05!!D!!.tsv", "!!SF!!0015000000iKUac!!SF!!!!D!!2017-07-25-11-20-05!!D!!.tsv");
               // client.UploadFile(@"\\annapurna\Public\Pujan\!!SF!!0015000000Q9YJF!!SF!!!!D!!2017-07-25-11-22-11!!D!!.tsv", "!!SF!!0015000000Q9YJF!!SF!!!!D!!2017-07-25-11-22-11!!D!!.tsv");
               // client.UploadFile(@"\\annapurna\Public\Pujan\!!SF!!0015000000Yctd7!!SF!!!!D!!2017-07-25-11-25-40!!D!!.tsv", "!!SF!!0015000000Yctd7!!SF!!!!D!!2017-07-25-11-25-40!!D!!.tsv");

                //download file
                client.DownloadFile(
                    @"\\annapurna\Public\Pujan\pujaDownloaded.tsv",
                    "jptFolder/pujan22");

            }
            catch (Exception ex)
            {
                
                throw;
            }
            

            //var p = client.GetListing("/");

        }

        void OnValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
        {
            // add logic to test if certificate is valid here
            e.Accept = true;
        }

       
    }
}

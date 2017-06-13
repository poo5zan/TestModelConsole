using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole
{
    public class DownloadFiles
    {

        public void DownloadAllFiles()
        {

            var urls = new List<string>()
            {

            };

            string url = "http://store.thesharperknife.com/yhst-5698391348794/catalog.xml";
            string dateInInt = DateTime.Now.Ticks.ToString();
            string filename = @"D:\Downloadedfiles\" + dateInInt;
            Console.WriteLine("DownloadAll Started");
            var prog = new Progress<int>(percent => {
                Console.WriteLine(percent + "%");
            });
            Task.Run(async () => await DownloadFIle(url, filename, prog));
            
            Console.WriteLine("DownloadAll Ended");
        }


        public async Task DownloadFIle(string url, string path, IProgress<int> progress = null)
        {
            using (WebClient client = new WebClient())
            {
                Console.WriteLine("s");
                client.DownloadProgressChanged += (s, e) =>
                {
                    if (progress != null)
                    {
                        progress.Report(e.ProgressPercentage);                       
                    }
                };

                await client.DownloadFileTaskAsync(url, path);
                Console.WriteLine("p");
            }
        }

        //public async void Download(string url)
        //{
        //    Console.WriteLine("Started");
        //    //string url = "http://store.thesharperknife.com/yhst-5698391348794/catalog.xml";

        //    WebClient client = new WebClient();
        //    client.DownloadProgressChanged += Client_DownloadProgressChanged;
        //    client.DownloadFileCompleted += Client_DownloadFileCompleted;
            
        //    Uri uri = new Uri(url);
        //    string dateInInt = DateTime.Now.Ticks.ToString();
        //    string filename = @"D:\Downloadedfiles\" + dateInInt;
        //    client.DownloadFileAsync(uri, filename);
        //    //client.DownloadFile(uri,filename);
        //    Console.WriteLine("Completed");
        //    var p = 0;
        //}

        //private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    Console.WriteLine("Download File Completed " + sender.GetType());
        //    //throw new NotImplementedException();
        //}

        //private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    double bytesIn = double.Parse(e.BytesReceived.ToString());
        //    double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
        //    double percentage = bytesIn / totalBytes * 100;
        //    var p = int.Parse(Math.Truncate(percentage).ToString());
        //    Console.WriteLine(p);
        //    //throw new NotImplementedException();
        //}
    }
}

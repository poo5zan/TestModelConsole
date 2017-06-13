using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace ApiShopify
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var r = new Me();
            r.name = "haha";
            r.somevirtualint = 9;

            var rs = JsonConvert.SerializeObject(r);
            var p = 0;

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://pujandevstore.myshopify.com/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            //Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "29fcf81bb568dabe33b0402b0b8e20c8", "533731620e4b2e4a92eb811c8dc26c36"))));

            //HttpResponseMessage response = client.
            //if (response.IsSuccessStatusCode)
            //{
            //    product = await response.Content.ReadAsAsync<Product>();
            //}
        }


        public class Me {
            public int id { get; set; }
            public string name { get; set; }
            public virtual string somevirtualstring { get; set; }
            public virtual int somevirtualint { get; set; }
        }

    }
}

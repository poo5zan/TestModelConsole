using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TestModel.Common
{
    public static class JsonHelper
    {

        private static int countOuter = 0;
        private static int countInner = 0;
        public static void GetJObjectKeyValue(JObject jObject, string namePrefix)
        {
            countOuter++;
            Console.WriteLine("--CountOuter = " + countOuter);
            foreach (var uj in jObject.Properties())
            {
                //Console.Write("PropertyType=" + uj.GetType().Name);
                Console.Write("ValueType=" + uj.Value.Type);

                if (uj.Value.Type == JTokenType.Array)
                {

                    Console.Write(",Name=" + namePrefix + "." + uj.Name);
                    countInner++;
                    Console.WriteLine("------CountInner = " + countInner);
                    var nest0Array = uj.Value as JArray;

                    foreach (var nest1JObject in nest0Array.Children<JObject>())
                    {
                        int arrayCounter = 0;
                        GetJObjectKeyValue(nest1JObject,
                            namePrefix
                            + "." + uj.Name +
                            "[" + arrayCounter + "]"
                            );
                        arrayCounter++;
                    }
                }
                else
                {
                    Console.Write(",Key=" + namePrefix + "." + uj.Name);
                    Console.WriteLine(",Value=" + uj.Value);
                }
            }
        }

    }
}

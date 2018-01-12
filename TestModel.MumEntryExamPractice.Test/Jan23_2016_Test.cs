using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.MumEntryExamPractice.Test
{
    [TestClass]
    public class Jan23_2016_Test
    {

        [TestMethod]
        public void IsFancy() {

            var jan23_2016 = new Jan23_2016();

            var result1 = jan23_2016.IsFancy(1);
            Assert.AreEqual(1, result1);

            var result2 = jan23_2016.IsFancy(2);
            Assert.AreEqual(0, result2);

            var result5 = jan23_2016.IsFancy(5);
            Assert.AreEqual(1, result5);

            var result17 = jan23_2016.IsFancy(17);
            Assert.AreEqual(1, result17);

            var result61 = jan23_2016.IsFancy(61);
            Assert.AreEqual(1, result61);

            var result217 = jan23_2016.IsFancy(217);
            Assert.AreEqual(1, result217);

            var result200 = jan23_2016.IsFancy(200);
            Assert.AreEqual(0, result200);


        }

        [TestMethod]
        public void IsMeera()
        {
            var jan23_2016 = new Jan23_2016();

            var result1 = jan23_2016.IsMeera(new int[] { 7, 9, 0, 10, 1 });
            Assert.AreEqual(1,result1);

            var result2 = jan23_2016.IsMeera(new int[] { 6, 10, 8 } );
            Assert.AreEqual(1,result2);

            var result3 = jan23_2016.IsMeera(new int[] { 7, 6, 1 });
            Assert.AreEqual(0,result3);

            var result4 = jan23_2016.IsMeera(new int[] { 9, 10, 0 });
            Assert.AreEqual(0,result3);

            var result5 = jan23_2016.IsMeera(new int[] { 1, 1, 0, 8, 0, 9, 9, 1 });
            Assert.AreEqual(1,result5);
        }

        [TestMethod]
        public void IsBean()
        {
            var jan23_2016 = new Jan23_2016();

            var result1 = jan23_2016.IsBean(new int[] { 4, 9, 8 });
            Assert.AreEqual(1,result1);

            var result2 = jan23_2016.IsBean(new int[] { 2, 2, 5, 11, 23 });
            Assert.AreEqual(1,result2);

            var result3 = jan23_2016.IsBean(new int[] { 7, 7, 3, 6 });
            Assert.AreEqual(1,result3);

            var result4 = jan23_2016.IsBean(new int[] {0 });
            Assert.AreEqual(1,result4);

            var result5 = jan23_2016.IsBean(new int[] { 3, 8, 4 });
            Assert.AreEqual(0,result5);
        }

    }
}

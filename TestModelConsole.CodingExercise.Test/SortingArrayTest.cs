using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole.CodingExercise.Test
{
    [TestClass]
    public class SortingArrayTest
    {
        [TestMethod]
        public void Sort() {
            var sortingArray = new SortingArray();

            var result = sortingArray.Sort(new int[] { 2, 1, 2, 5, 2, 1, 5, 9,1 });
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void FindMaximumCountInArray()
        {
            var sortingArray = new SortingArray();
            var result = sortingArray.FindMaximumCountInArray(new int[] { 2, 1, 2, 5, 2, 1, 5, 9, 1,1 });
            Assert.AreEqual(4, result);
        }

    }
}

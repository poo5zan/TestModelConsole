using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class FileSplitterTests
    {
        [TestMethod]
        public void SplitFile_Tests()
        {
            // string sourceFile = @"D:\Files\bigfile.csv";
            string sourceFile = @"D:\Files\smallfile";
            string destinationPath = @"D:\Files";
            int fileSize = 1024*1024*2; // 2 MB

            new FileSplitter().SplitFile(sourceFile, fileSize, destinationPath);

        }

        //[TestMethod]
        //public void GetFileExtension_Tests()
        //{
        //    string fileName = "haha.two";

        //    string extension = new FileSplitter().GetFileExtension(fileName);
        //    Assert.AreEqual("two",extension);

        //    string fileName2 = "haha.two.three.four";

        //    string extension2 = new FileSplitter().GetFileExtension(fileName2);
        //    Assert.AreEqual("four", extension2);

        //    string fileNameDefault = "haha";

        //    string extensionDefault = new FileSplitter().GetFileExtension(fileNameDefault);
        //    Assert.AreEqual("txt", extensionDefault);
        //}
    }
}

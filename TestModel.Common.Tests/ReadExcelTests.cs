using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestModel.Common.FilesModule;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class ReadExcelTests
    {
        [TestMethod]
        public void ReadExcel()
        {
            IFileService fileService = new FileService();
            string filePath = @"../../read_excel_files/random_data.xls";
            var dt = fileService.ReadExcel(filePath);
            var columns = dt.Columns;
        }
    }       
}





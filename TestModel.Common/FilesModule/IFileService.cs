using System.Data;

namespace TestModel.Common.FilesModule
{
    public interface IFileService
    {
        DataTable ReadExcel(string filePath);
    }
}

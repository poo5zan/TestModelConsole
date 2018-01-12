using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.Common
{
    public class FileSplitter
    {
        public void SplitFile(string inputFile, int chunkSize, string path)
        {
            byte[] buffer = new byte[chunkSize];
            List<byte> extraBuffer = new List<byte>();
            string fileExtension = Path.GetExtension(inputFile);
            string fileName = Path.GetFileNameWithoutExtension(inputFile);
            var fileInfo = new FileInfo(inputFile);
            var fileSize = fileInfo.Length;
            //var filen = fileInfo.Name;

            if (fileSize <= chunkSize)
            {
                //no need to split
                return;
            }

            try
            {
                using (Stream input = File.OpenRead(inputFile))
                {
                    int index = 0;
                    while (input.Position < input.Length)
                    {
                        using (Stream output = File.Create(path + "\\" + fileName + "_" + index + fileExtension))
                        {
                            int chunkBytesRead = 0;
                            while (chunkBytesRead < chunkSize)
                            {
                                int bytesRead = input.Read(buffer,
                                                           chunkBytesRead,
                                                           chunkSize - chunkBytesRead);

                                if (bytesRead == 0)
                                {
                                    break;
                                }

                                chunkBytesRead += bytesRead;
                            }

                            byte extraByte = buffer[chunkSize - 1];
                            while (extraByte != '\n')
                            {
                                int flag = input.ReadByte();
                                if (flag == -1)
                                    break;
                                extraByte = (byte)flag;
                                extraBuffer.Add(extraByte);
                            }

                            output.Write(buffer, 0, chunkBytesRead);
                            if (extraBuffer.Count > 0)
                                output.Write(extraBuffer.ToArray(), 0, extraBuffer.Count);

                            extraBuffer.Clear();
                        }
                        index++;
                    }
                }

            }
            catch (FileNotFoundException fe)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }


        }

        //public string GetFileExtension(string file)
        //{
        //    if (!file.Contains("."))
        //    {
        //        return "txt";
        //    }

        //    var splittedText = file.Split('.');
        //    var length = splittedText.Length;
        //    var ext = splittedText[length - 1];
        //    return ext;
        //}


        //public  void SplitFile(string inputFile, int chunkSize, string path)
        //{
        //    byte[] buffer = new byte[chunkSize];

        //    using (Stream input = File.OpenRead(inputFile))
        //    {
        //        int index = 0;
        //        while (input.Position < input.Length)
        //        {
        //            using (Stream output = File.Create(path + "\\" + index))
        //            {
        //                int chunkBytesRead = 0;
        //                while (chunkBytesRead < chunkSize)
        //                {
        //                    int bytesRead = input.Read(buffer,
        //                                               chunkBytesRead,
        //                                               chunkSize - chunkBytesRead);

        //                    if (bytesRead == 0)
        //                    {
        //                        break;
        //                    }
        //                    chunkBytesRead += bytesRead;
        //                }
        //                output.Write(buffer, 0, chunkBytesRead);
        //            }
        //            index++;
        //        }
        //    }
        //}

    }
}

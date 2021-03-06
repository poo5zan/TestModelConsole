﻿using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.Common.FilesModule
{
    public class FileService : IFileService
    {
        public DataTable ReadExcel(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("File Not Found");
            }
            FileInfo fileInfo = new FileInfo(filePath);
            XSSFWorkbook xssfWorkBook = null;
            HSSFWorkbook hssfWorkBook = null;
            int sheetIndex = 0;
            ISheet sheet = null;

            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (fileInfo.Extension == ".xlsx")
                {
                    xssfWorkBook = new XSSFWorkbook(file);
                    sheetIndex = xssfWorkBook.ActiveSheetIndex;
                    sheet = xssfWorkBook.GetSheetAt(sheetIndex);
                }
                else if (fileInfo.Extension == ".xls")
                {
                    hssfWorkBook = new HSSFWorkbook(file);
                    sheetIndex = hssfWorkBook.ActiveSheetIndex;
                    sheet = hssfWorkBook.GetSheetAt(sheetIndex);
                }
                else
                {
                    throw new Exception("Not a valid Excel extension. Supported Extensions are xls and xlsx");
                }
            }

            return ConvertExcelSheetToDataTable(sheet);
        }

        private DataTable ConvertExcelSheetToDataTable(ISheet sheet)
        {
            if (sheet == null)
            {
                return null;
            }

            DataTable dt = new DataTable();
            for (int rowIndex = sheet.FirstRowNum; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                //the first row found is treated as header
                if (rowIndex == sheet.FirstRowNum)
                {
                    IRow headerRow = sheet.GetRow(rowIndex);
                    if (headerRow != null)
                    {
                        for (int columnIndex = headerRow.FirstCellNum; columnIndex < headerRow.LastCellNum; columnIndex++)
                        {
                            string headerName = headerRow.GetCell(columnIndex)?.StringCellValue;
                            dt.Columns.Add(headerName);
                        }
                    }
                }

                IRow row = sheet.GetRow(rowIndex);
                if (row == null) { continue; }

                DataRow dtRow = dt.NewRow();
                int dtRowIndex = 0;
                for (int columnIndex = row.FirstCellNum; columnIndex < row.LastCellNum; columnIndex++)
                {
                    var cellValue = row.GetCell(columnIndex);
                    object cellValueObj = null;
                    if (cellValue == null)
                    {
                        dtRow[dtRowIndex] = cellValueObj;
                        dtRowIndex++;
                        continue;
                    }
                    switch (cellValue?.CellType)
                    {
                        case CellType.Unknown:
                            break;
                        case CellType.Numeric:
                            cellValueObj = cellValue.NumericCellValue;
                            break;
                        case CellType.String:
                            cellValueObj = cellValue.StringCellValue;
                            break;
                        case CellType.Formula:
                            cellValueObj = cellValue.CellFormula;
                            break;
                        case CellType.Blank:
                            cellValueObj = null;
                            break;
                        case CellType.Boolean:
                            cellValueObj = cellValue.BooleanCellValue;
                            break;
                        case CellType.Error:
                            cellValueObj = cellValue.ErrorCellValue;
                            break;
                        default:
                            dtRow[dtRowIndex] = null;
                            break;
                    }

                    dtRow[dtRowIndex] = cellValueObj;
                    dtRowIndex++;
                }
                dt.Rows.Add(dtRow);

            }
            return dt;
        }
    }

}


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace AutomationFramework.Utilities
{
    class LibExcel
    {

        private static Excel.Application excel;
        private static Excel.Workbook workbook;
        private static Excel.Worksheet worksheet;
        private static Excel.Range range;

        private static string _FilePath;

        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }

        private static bool WorkBookExist(string pFilePath)
        {
            if (File.Exists(pFilePath))
            {
                return true;
            }
            else
            {
                Console.WriteLine("The workbook not exist in: " + pFilePath);
                return false;
            }
        }

        private static bool WorkSheetExist(Excel.Workbook pworkbook, string psheet)
        {
            bool bfound = false;
            foreach (Excel.Worksheet sheet in pworkbook.Sheets)
            {
                if (sheet.Name == psheet)
                {
                    bfound = true;
                    break;
                }
            }
            return bfound;
        }

        private static void Close()
        {
            workbook.Close();
            excel.Quit();
            foreach (var process in Process.GetProcessesByName("EXCEL"))
            {
                process.Kill();
            }
            workbook = null;
            excel = null;
        }

        private static Excel.Workbook OpenWorkBook(Excel.Application pExcel, string pFilePath)
        {
            workbook = pExcel.Workbooks.Open(pFilePath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            return workbook;
        }

        private static Excel.Application GetExcelApp()
        {
            if (excel == null)
            {
                excel = new Excel.Application();
            }
            return excel;
        }

        public void ReadAllExcel(string psheet)
        {
            try
            {
                if (WorkBookExist(_FilePath))
                {
                    excel = GetExcelApp();
                    workbook = OpenWorkBook(excel, _FilePath);
                    if (WorkSheetExist(workbook, psheet))
                    {
                        worksheet = workbook.Sheets[psheet];
                        range = worksheet.UsedRange;
                        int rowCount = range.Rows.Count;
                        int colCount = range.Columns.Count;

                        for (int i = 1; i <= rowCount; i++)
                        {
                            for (int j = 1; j <= colCount; j++)
                            {
                                range = (worksheet.Cells[i, j] as Excel.Range);
                                string cellValue = range.Value.ToString() + "\t";
                                Console.Write(cellValue);
                            }
                            Console.WriteLine();
                        }
                    }
                    Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Read Excel: Error: " + e);
                Close();
            }
        }

        public string ReadExcelByIndex(string psheet, string pcolumn, string pRowSet)
        {
            string xlValue = "";
            string rowValue;

            try
            {
                if (WorkBookExist(_FilePath))
                {
                    excel = GetExcelApp();
                    workbook = OpenWorkBook(excel, _FilePath);
                    if (WorkSheetExist(workbook, psheet))
                    {
                        worksheet = workbook.Sheets[psheet];
                        range = worksheet.UsedRange;
                        int rowCount = range.Rows.Count;
                        int intCol = FindColumn(worksheet, pcolumn);
                        if (intCol > -1)
                        {
                            for (int row = 1; row <= rowCount; row++)
                            {
                                rowValue = worksheet.Cells[row, 1].Value2.ToString();
                                if (rowValue.ToString() == pRowSet)
                                {
                                    xlValue = worksheet.Cells[pRowSet.ToString(), intCol].Value;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("The column not exist: " + pcolumn);
                        }
                    }
                    Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Read Excel: Error: " + e);
                Close();

            }
            return xlValue;
        }

        private static int FindColumn(Excel.Worksheet pSheet, string pcolName)
        {
            int column = -1;
            range = pSheet.UsedRange;
            int colCount = range.Columns.Count;

            for (int j = 1; j <= colCount; j++)
            {
                string name = pSheet.Cells[1, j].Value2;

                if (pcolName == name)
                {
                    column = j;
                    break;
                }

            }
            return column;
        }



    }
}

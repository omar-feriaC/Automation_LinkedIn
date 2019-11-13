using AutomationFramework.BaseFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"C:\LinkedIn\ExportedResults.txt";

            using (StreamWriter outputFile = new StreamWriter(FilePath, true))
            {
                outputFile.WriteLine("Fourth Line");
            }

        }
    }
}

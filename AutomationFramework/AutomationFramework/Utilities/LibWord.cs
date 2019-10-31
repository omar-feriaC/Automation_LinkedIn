using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Utilities
{
    class LibWord
    {

        Application _word = new Application();
        Document _doc = new Document();
        private object _word_path;

        /*Get Object instance*/
        public object File_Path
        {
            get { return _word_path; }
            set { _word_path = value; }
        }

        /*Close and Quit the MS Word Intance*/
        public void QuitWordDocument()
        {
            ((_Document)_doc).Close();
            ((_Application)_word).Quit();
        }

        /*Open the MS Word Document and return the document*/
        public Document OpenDocument(object pfileName)
        {
            object missing = System.Type.Missing;
            _doc = _word.Documents.Open(ref pfileName,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);
            return _doc;
        }

        /*Read and return a list with the line readed*/
        public List<string> ReadWordDocument(object pfileNam)
        {
            OpenDocument(pfileNam);
            String read = string.Empty;
            List<string> data = new List<string>();
            for (int i = 0; i < _doc.Paragraphs.Count; i++)
            {
                string temp = _doc.Paragraphs[i + 1].Range.Text.Trim();
                if (temp != string.Empty)
                    data.Add(temp);
            }

            /* foreach (var value in data)
             {
                 Console.WriteLine("line readed: " + value.ToString());
             }*/
            QuitWordDocument();
            return data;
        }

    }
}

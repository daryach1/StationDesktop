using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.Office.Interop;

namespace StationDesktop.Services
{
    internal class WordHelper
    {
        private FileInfo _fileInfo;

        public WordHelper(string fileName)
        {
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else MessageBox.Show("Файл не найден");
        }

        internal bool Process(Dictionary<string, string> items)
        {
            Microsoft.Office.Interop.Word.Application app = null;
                app = new Microsoft.Office.Interop.Word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;

                app.Documents.Open(file);
                foreach(var item in items)
                {
                    Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = WdFindWrap.wdFindContinue;
                    Object replace = WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord:false,
                        MatchWildcards:false,
                        MatchSoundsLike:missing,
                        MatchAllWordForms:false,
                        Forward:true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }
                Object newFileName = Path.Combine(_fileInfo.DirectoryName, DateTime.Now.ToString("ddMMyyyy") + _fileInfo.Name);
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
                return true;
            return false;
        }
    }
}

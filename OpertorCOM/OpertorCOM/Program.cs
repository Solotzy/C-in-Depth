/*
 * COM互操作
 * Word
 */
using System;
using Microsoft.Office.Interop.Word;

namespace OpertorCOM
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application {Visible = false};
            app.Documents.Add();
            Document doc = app.ActiveDocument;
            Paragraph para = doc.Paragraphs.Add();
            para.Range.Text = "Thank goodnes for C# 4";
            doc.SaveAs(FileName: "d:\\myWord.doc", FileFormat: WdSaveFormat.wdFormatDocument97);
            Console.WriteLine();
            doc.Close();
            app.Application.Quit();
        }
    }
}

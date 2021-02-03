using System;
using System.IO;
using System.Text;
using Notebook.Model;

namespace Notebook.Action
{
    public class ExportAction : ConsoleActions, IAction
    {
        private readonly Store.Notebook NoteBook;
        public string Name => "Create";

        public ExportAction(Store.Notebook memo)
        {
            NoteBook = memo;
        }

        public void Run()
        {
            var fileName = ReadLineLimited("Введите путь и имя экспортируемого файла: \nЕсли такой файл существует, он будет перезаписан");
                fileName += ".csv";
            WriteInFile(fileName, NoteBook);
        }

    }
}
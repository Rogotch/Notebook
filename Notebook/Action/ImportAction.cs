using System;
using System.IO;
using System.Text;

namespace Notebook.Action
{
    public class ImportAction : ConsoleActions, IAction
    {
        private readonly Store.Notebook NoteBook;
        public string Name => "Create";

        public ImportAction(Store.Notebook memo)
        {
            NoteBook = memo;
        }

        public void Run()
        {
            var fileName = ReadLineLimited("Введите путь и имя файла для импорта записей:");
                fileName += ".csv";
                NoteBook.Add(ReadInFile(fileName));
        }

        protected Store.Notebook ReadInFile(string path)
        {
            Store.Notebook newNotebook = new Store.Notebook();
            using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('\t');
                    var text = data[0];
                    var title = data[1];
                    var tags = SplitTags(data[2]);
                    var date = DateTime.Parse(data[3]);

                    newNotebook.Add(text, title, tags, date);
                }
            }
            return newNotebook;
        }
    }
}
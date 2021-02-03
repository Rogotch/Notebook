using System;

namespace Notebook.Action
{
    public class SaveAction : ConsoleActions, IAction
    {
        private readonly Store.Notebook NoteBook;
        public string Name => "Create";

        public SaveAction(Store.Notebook memo)
        {
            NoteBook = memo;
        }

        public void Run()
        {
            WriteInFile(savePath, NoteBook);
            Console.WriteLine("Заметки сохранены!");
        }
    }
}
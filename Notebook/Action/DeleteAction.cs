using System;
using Notebook.Store;

namespace Notebook.Action
{
    public class DeleteAction : ConsoleActions, IAction
    {
        private readonly Store.Notebook NoteBook;
        public string Name => "Create";

        public DeleteAction(Store.Notebook memo)
        {
            NoteBook = memo;
        }

        public void Run()
        {
            int index = ReadIntRange("Введите номер заметки, которую хотите удалить:", 1, NoteBook.Length());
            NoteBook.Remove(NoteBook[index-1]);
        }
    }
}
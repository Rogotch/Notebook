using System;
using Notebook.Model;

namespace Notebook.Action
{
    public class CreateAction : ConsoleActions, IAction
    {
        private readonly Store.Notebook NoteBook;
        public string Name => "Create";

        public CreateAction(Store.Notebook memo)
        {
            NoteBook = memo;
        }

        public void Run()
        {
            var title = ReadLineLimited("Заголовок заметки:");
            var text = ReadLineLimited("Текст заметки:", 0);
            var tags = SplitTags(ReadLineLimited("Введите через пробел чувствительные к регистру теги:", 0));
            var date = DateTime.Now;

            Note memo = new Note(text, title, tags, date);

            NoteBook.Add(memo);
        }
    }
}
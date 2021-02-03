using System;
using Notebook.Model;

namespace Notebook.Action
{
    public class ReadAction : ConsoleActions, IAction
    {
        private readonly Store.Notebook NoteBook;
        public string Name => "Прочитать заметку";

        public ReadAction(Store.Notebook memo)
        {
            NoteBook = memo;
        }

        public void Run()
        {
            int index = ReadIntRange("Введите номер заметки, которую хотите прочитать:", 1, NoteBook.Length());
            Note memo = NoteBook[index - 1];
            Console.WriteLine(
                $"Название заметки: {memo.Title, 20}" +
                $"\tВремя создания:{memo.DateCreate}");
            Console.WriteLine(memo.TextNote);
            Console.WriteLine($"Теги: {JoinTags(memo.Tags)}");
        }
    }
}
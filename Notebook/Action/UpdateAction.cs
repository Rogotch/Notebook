using System;
using Notebook.Model;

namespace Notebook.Action
{
    public class UpdateAction : ConsoleActions, IAction
    {
        private readonly Store.Notebook NoteBook;
        public string Name => "Create";

        public UpdateAction(Store.Notebook memo)
        {
            NoteBook = memo;
        }

        public void Run()
        {
            bool flag = true;
            int index = ReadIntRange("Введите номер заметки, которую хотите изменить:", 1, NoteBook.Length());
            while (flag)
            {
                Console.Clear();
                Note memo = NoteBook[index - 1];
                Console.WriteLine(
                    $"Название заметки: {memo.Title,20}" +
                    $"\tВремя создания:{memo.DateCreate}");
                Console.WriteLine(memo.TextNote);
                Console.WriteLine($"Теги: {JoinTags(memo.Tags)}");

                var operation = ReadIntRange("Укажите, что именно вы хотите в заметке изменить:" +
                                             "\n1 - Заголовок" +
                                             "\n2 - Содержание" +
                                             "\n3 - Теги" +
                                             "\n4 - Выход", 1, 4);

                switch (operation)
                {
                    case 1:
                        memo.Title = ReadLineLimited("Введите новый заголовок:");
                        break;
                    case 2:
                        memo.TextNote = ReadLineLimited("Новый текст заметки:", 0);
                        break;
                    case 3:
                        memo.Tags = SplitTags(ReadLineLimited("Введите через пробел чувствительные к регистру теги:", 0));
                        break;
                    case 4:
                        flag = false;
                        break;
                }
                NoteBook[index - 1] = memo;
            }
        }
    }
}
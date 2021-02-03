using System;

namespace Notebook.Action
{
    public class ConsoleActions : Action
    {
        public override string ReadLineLimited(string title, int maxLength = 20)
        {
            Console.WriteLine(title);
            string line;
            while (true)
            {
                line = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrEmpty(line)) break;
                Console.WriteLine($"Неверное значение, ваша строка пуста");
            }
            return base.ReadLineLimited(line, maxLength);
        }

        protected DateTime ReadDataTime(string title)
        {
            Console.WriteLine(title);
            DateTime date;
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out date)) break;
                Console.WriteLine("Неверное значение, введите дату и время в формате ДД.ММ.ГГ ЧЧ:ММ");
            }

            return date;
        }
        protected int ReadIntRange(string title, int minValue, int maxValue)
        {
            Console.WriteLine(title);
            int value;
            while (true)
            {
                var result = Int32.TryParse(Console.ReadLine(), out value);
                if (result && minValue <= value && value <= maxValue) break;
                Console.WriteLine($"Неверный ввод! Введите число от {minValue} до {maxValue}");
            }

            return value;
        }

    }
}
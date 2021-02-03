using System;
using Notebook.OtherOperations;

namespace Notebook.Model
{
    public class Note
    {
        /// <summary>
        /// Заголовок заметки
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст заметки
        /// </summary>
        public string TextNote { get; set; }

        /// <summary>
        /// Теги заметки
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Дата создания или обновления заметки
        /// </summary>
        public DateTime DateCreate { get; private set; }




        /// <summary>
        /// Конструктор создания заметок
        /// </summary>
        /// <param name="textNote">Текст заметки</param>
        /// <param name="title">Заголовок заметки</param>
        /// <param name="tags">Теги заметки</param>
        /// <param name="time">Время создания или редактирования</param>
        public Note(string textNote, string title, string[] tags, DateTime time)
        {
            this.Tags = tags;
            this.Title = title;
            this.DateCreate = time;
            this.TextNote = textNote;
        }

    }
}
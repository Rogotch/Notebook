using System;
using System.Collections.Generic;
using Notebook.Model;

namespace Notebook.Store
{
    public class Notebook
    {

        /// <summary>
        /// Лист заметок в ежедневнике
        /// </summary>
        private List<Note> Notes;

        /// <summary>
        /// Индексатор ежедневника
        /// </summary>
        /// <param name="index">Положение заметки в архиве</param>
        /// <returns>Заметка</returns>
        public Note this[int index]
        {
            get { return Notes[index]; }
            set { Notes[index] = value; }
        }

        public void Add(string textNote, string title, string[] tags, DateTime time)
        { Notes.Add(new Note(textNote, title, tags, time)); }
        public void Add(Note memo)
        { Notes.Add(memo); }

        public void Add(Notebook importNotebook)
        {
            for (int i = 0; i < importNotebook.Length(); i++)
            {
                Notes.Add(importNotebook[i]);
            }
        }
        public void Remove(Note removedNote)
        { Notes.Remove(removedNote); }

        public int Length()
        {
            return Notes.Count;
        }
    }
}
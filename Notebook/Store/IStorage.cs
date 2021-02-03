using System;
using System.Collections.Generic;
using Notebook.Model;

namespace Notebook.Store
{
    public enum SortMode
    { Todo, Deadline, Priority }

    public interface IStorage
    {
        void Open();
        void Close();
        IEnumerable<Note> Find(SortMode mode = SortMode.Deadline);
        IEnumerable<Note> Find(DateTime begin, DateTime end, SortMode mode = SortMode.Deadline);
        bool Create(Note entity);
        bool Delete(Note entity);
        bool Update(Note entity);
        int Merge(IEnumerable<Note> entity);
    }
}
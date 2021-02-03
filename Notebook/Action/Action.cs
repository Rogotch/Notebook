using System;
using System.IO;
using System.Text;
using Notebook.Model;

namespace Notebook.Action
{
    public abstract class Action
    {
        protected readonly string savePath = "mainBase.csv";
        public virtual string ReadLineLimited(string text, int maxLength = 20)
        {
            if (maxLength == 0)
                return text;

            int found = 0;
            string firstWords;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    if (i >= maxLength) break;
                    found = i;
                }
            }

            if (found == 0) firstWords = text.Substring(maxLength);
            else            firstWords = text.Substring(0, found);

            return firstWords;
        }

        protected string[] SplitTags(string tagsLine)
        {
            char[] separators = new char[] { ' ', ',', '!', '?', '.'};
            string[] tags = tagsLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return tags;
        }

        protected string JoinTags(string[] tags)
        {
            string separator = ", ";
            string tagsLine = String.Join(separator, tags);
            return tagsLine;
        }

        protected void WriteInFile(string path, Store.Notebook noteBook)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode))
            {
                for (int i = 0; i < noteBook.Length(); i++)
                {
                    string tags;
                    if (noteBook[i].Tags == null)
                    {
                        tags = "";
                    }
                    else
                    {
                        tags = JoinTags(noteBook[i].Tags);
                    }
                    sw.WriteLine($"{noteBook[i].Title}\t" +
                                 $"{noteBook[i].TextNote}\t" +
                                 $"{tags}\t" +
                                 $"{noteBook[i].DateCreate}\t");
                }
            }
        }
    }
}
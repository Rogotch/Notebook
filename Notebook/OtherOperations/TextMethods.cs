namespace Notebook.OtherOperations
{
    public class TextMethods
    {

        public static string Reduction(string text, int charCount)
        {
            int found = 0;
            string firstWords;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    if (i >= charCount)
                    {
                        break;
                    }
                    found = i;
                }
            }

            if (found == 0)
            {
                firstWords = text.Substring(charCount);
            }
            else
            {
                firstWords = text.Substring(0, found);
            }

            return firstWords;
        }

        public static string Reduction(string text)
        {
            return Reduction(text, 20);
        }


    }
}
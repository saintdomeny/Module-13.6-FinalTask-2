using System.Collections;
using System.Diagnostics.Tracing;

namespace Module_13._6_FinalTask_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("D:\\Domeny\\Downloads\\Text1.txt");
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            char[] delimiters = new char[] { ' ', '\r', '\n' };

            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var repeatedWords = new Dictionary<string, int>();

            foreach (string word in words)
            {
                bool cont = repeatedWords.ContainsKey(word);
                int count;
                if (cont)
                {
                    repeatedWords.TryGetValue(word, out count);
                    repeatedWords.Remove(word);
                    repeatedWords.Add(word, count+1);
                }
                else
                {
                    repeatedWords.Add(word, 1);
                }
            }
            //Output of first 10 words.
            int i = 0;
            foreach (KeyValuePair<string, int> word in repeatedWords.OrderByDescending(key => key.Value))
            {
                if (i < 10)
                {
                    Console.WriteLine("Word: {0}, Repeats: {1}", word.Key, word.Value);
                    i++;
                }
            }

        }
    }
}
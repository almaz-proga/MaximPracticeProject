using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    class Program
    {
        static bool StringCheck(string word, out List<char> invalidchars)
        {
            string symbols = "abcdefghijklmnopqrstuvwxyz";
            invalidchars = new List<char>();

            foreach (char chars in word)
            {
                if (!symbols.Contains(chars) && !invalidchars.Contains(chars))
                {
                    invalidchars.Add(chars);
                }
            }
            return invalidchars.Count() == 0;
        }
        static Dictionary<char, int> CharCount(string word)
        {
            Dictionary<char, int> charcount = new Dictionary<char, int>();
            foreach(char c in word)
            {
                if (charcount.ContainsKey(c))
                {
                    charcount[c]++;
                }
                else
                {
                    charcount[c] = 1;
                }
            }
            return charcount;
        }
        static string MaxSubstring(string word)
        {
            int start = -1;
            int end = -1;
            string allowedchar = "aeiouy";
            string result = null;
            for (int i = 0; i < word.Length; i++)
            {
                if (allowedchar.Contains(word[i]) && start == -1)
                {
                    start = i;
                    end = i;
                }
                else if (allowedchar.Contains(word[i]) && start != -1)
                {
                    end = i;
                }
            }
            if(start == -1 && end == -1)
            {
                result = "В данной строке нет подходящей подстроки! ";
            }
            else
            {
                result = word.Substring(start, end - start + 1);
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string word = Console.ReadLine();
            if (StringCheck(word, out List<char> invalidchars)) 
            {
                Console.WriteLine("строка введена корректна!");
                string newword = null;
                if (word.Length % 2 == 0)
                {

                    for (int i = word.Length / 2 - 1; i >= 0; i--)
                    {
                        newword += word[i];
                    }
                    for (int i = word.Length - 1; i >= word.Length / 2; i--)
                    {
                        newword += word[i];
                    }
                }
                else
                {
                    for (int i = word.Length - 1; i >= 0; i--)
                    {
                        newword += word[i];
                    }
                    newword += word;
                }
                Console.WriteLine($"обработанная строка: {newword}");
                var charcount = CharCount(newword);
                Console.WriteLine("Кол-во повторяющихся символов: ");
                foreach (var pair in charcount)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value}");
                }
                string result = MaxSubstring(newword);
                Console.WriteLine($"Максимальная подстрока начинающаяся и заканчивающаяся на гласную: {result}");

            }
            else
            {
                Console.WriteLine("В строке содержатся недопустимые символы: " + string.Join(", ", invalidchars));
    
            }

            Console.ReadLine();
        }
    }
}

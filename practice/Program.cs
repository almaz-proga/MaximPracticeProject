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
        static void QuickSort(ref char[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotindex = Partition(ref array, low, high);
                QuickSort(ref array, low, pivotindex - 1);
                QuickSort(ref array, pivotindex + 1, high);
            }

        }
        static int Partition(ref char[] array, int low, int high)
        {
            char pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    char temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            char tempi = array[i + 1];
            array[i + 1] = array[high];
            array[high] = tempi;
            return i + 1;
        }
        static string TreeSort(string newword)
        {
            SortedDictionary<char, int> charCounts = new SortedDictionary<char, int>();

            foreach (char c in newword)
            {
                if (charCounts.ContainsKey(c))
                { 
                    charCounts[c]++;
                }
                else 
                {
                    charCounts[c] = 1; 
                }
            }

            var result = new System.Text.StringBuilder();
            foreach (var pair in charCounts)
            {
                result.Append(pair.Key, pair.Value);
            }

            return result.ToString();
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
                Console.Write("Выберите метод сортировки новой строки (1 - быстрая сортировка, 2 - сортировка деревом): ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                char[] array = newword.ToCharArray();

                Console.WriteLine($"обработанная строка: {newword}\n");

                var charcount = CharCount(newword);
                Console.WriteLine("Кол-во повторяющихся символов:");
                foreach (var pair in charcount)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value}");
                }

                string result = MaxSubstring(newword);
                Console.WriteLine($"Максимальная подстрока начинающаяся и заканчивающаяся на гласную: {result}\n");
                Console.Write("Отсортированная обработанная строка: ");

                if (choice == 1) 
                {
                    QuickSort(ref array, 0, array.Length - 1);
                    Console.WriteLine(new string(array));
                }
                else if(choice == 2)
                {   
                    string newwordsorted = TreeSort(newword);
                    Console.WriteLine(newwordsorted);
                }
            }
            else
            {
                Console.WriteLine("В строке содержатся недопустимые символы: " + string.Join(", ", invalidchars));
            }

            Console.ReadLine();
        }
    }
}

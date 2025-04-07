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

            foreach(char chars in word)
            {
                if(!symbols.Contains(chars) && !invalidchars.Contains(chars))
                {
                    invalidchars.Add(chars);
                }
            }
            return invalidchars.Count() == 0;
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
                Console.WriteLine(newword);

            }
            else
            {
                Console.WriteLine("В строке содержатся недопустимые символы: " + string.Join(" ,", invalidchars));
    
            }

            Console.ReadLine();
        }
    }
}

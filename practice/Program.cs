using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string word = Console.ReadLine();
            string newword = null;
            if (word.Length % 2 == 0)
            {
                
                for(int i = word.Length / 2 - 1; i >= 0; i--)
                {
                    newword += word[i];
                }
                for(int i = word.Length - 1; i >= word.Length / 2; i--)
                {
                    newword += word[i];
                }
            }
            else
            {
                for(int i = word.Length - 1; i >= 0; i--)
                {
                    newword += word[i];
                }
                newword += word;
            }
            Console.WriteLine(newword);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsNoUppercase = new string[]
            {
                "quick", "brown", "fox"
            };
            Console.WriteLine(IsAnyWordUpperCase(wordsNoUppercase));
            var wordsWithUppercase = new string[]
            {
                "quick", "brown", "FOX"
            };
            Console.WriteLine(IsAnyWordUpperCase(wordsWithUppercase));
            Console.ReadKey();
        }

        public static bool IsAnyWordUpperCase_Linq(
            IEnumerable<string> words)
        {
            return words.Any(word =>
                word.All(letter => char.IsUpper(letter))); 
        }

        public static bool IsAnyWordUpperCase(
            IEnumerable<string> words)
        {
            foreach(var word in words)
            {
                bool areAllUpperCase = true;
                foreach(var letter in word)
                {
                    if(char.IsLower(letter))
                    {
                        areAllUpperCase = false;
                    }
                }
                if(areAllUpperCase)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
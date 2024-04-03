using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace dictFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Enter a word");
            name = Console.ReadLine();
            Dictionary<char, int> frequencyDict = CalculateLetterFrequency(name);

            foreach (var entry in frequencyDict)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");

            }
            

            Console.ReadLine();
        }

        static Dictionary<char, int> CalculateLetterFrequency(string word)
        {
            Dictionary<char, int> frequencyDict = new Dictionary<char, int>();

            foreach (char letter in word)
            {
                char lowerCaseLetter = char.ToLower(letter);

                // Check if the character is a letter
                if (char.IsLetter(lowerCaseLetter))
                {
                    if (frequencyDict.ContainsKey(lowerCaseLetter))
                    {
                        frequencyDict[lowerCaseLetter]++;
                    }
                
                    else
                    {
                        frequencyDict[lowerCaseLetter] = 1;
                    }
                }
            }

            return frequencyDict;
        }
    }
}

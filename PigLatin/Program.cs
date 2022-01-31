using System;

namespace PigLatin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PigLatinTranslator.TranslateWord("apple"));
            Console.WriteLine(PigLatinTranslator.TranslateWord("Trebuchet"));
        
            Console.WriteLine(PigLatinTranslator.TranslateSentence("I like to eat honey waffles."));
        }
    }
}

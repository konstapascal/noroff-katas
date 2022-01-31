using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PigLatin
{
	internal static class PigLatinTranslator
	{
		static char [] vowels = {'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u'};
		
		internal static string TranslateWord(string word)
		{

			if (word == String.Empty) return String.Empty;
			
			char firstLetter = word[0];
			if (IsVowel(firstLetter)) return word + "yay";

			string temp = "";

			foreach (char letter in word)
			{
				if (IsVowel(letter)) break;
				if (IsConsonant(letter)) temp += letter;
			}

			word = word.Remove(0, temp.Length);

			string finalWord = word + temp + "ay";

			if(finalWord.Any(letter => Char.IsUpper(letter)))
			{
				CultureInfo culture = new CultureInfo("en-US", false);
				return culture.TextInfo.ToTitleCase(finalWord.ToLower());
			}

			return finalWord;
		}

		internal static string TranslateSentence(string sentence)
		{
			sentence = Regex.Replace(sentence, @"[^\w\s]", String.Empty);

			string[] words = sentence.Split(' ');
			List<string> newWords = new List<string>();

			foreach (string word in words)
				newWords.Add(TranslateWord(word));

			return String.Join(" ", newWords);
		}
		
		private static bool IsVowel(char letter) => vowels.Contains(letter);
		private static bool IsConsonant(char letter) => !IsVowel(letter);
	}
}

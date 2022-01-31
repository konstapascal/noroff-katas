using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardValidator
{
	internal class CardHandler
	{
		internal static bool ValidateCard(long cardNumber)
		{
			long digit = GetLastDigit(cardNumber);

			long cardNumberWithoutDigit = RemoveLastDigit(cardNumber);
			long reversedCardNumber = ReverseNumber(cardNumberWithoutDigit);
			long doubledDigits = DoubleDigits(reversedCardNumber);
			long addedDigits = AddAllDigits(doubledDigits);
			long digit2 = 10 - GetLastDigit(addedDigits);

			return digit == digit2;
		}

		private static long DoubleDigits(long number)
		{
			List<long> digits = new List<long>();

			foreach (char digit in number.ToString()) 
				digits.Add(ParseChar(digit));

			List<long> newDigits = new List<long>();

			for (int i = 0; i < digits.Count; i++)
			{
				if (i % 2 == 0)
				{
					long doubled = digits[i] * 2;

					if (doubled < 9)
					{
						newDigits.Add(doubled);
						continue;
					}

					newDigits.Add(AddAllDigits(doubled));
				}

				newDigits.Add(digits[i]);
			}

			return long.Parse(String.Join(String.Empty, newDigits));
		}

		private static long AddAllDigits(long number)
		{
			char [] digits = number.ToString().ToCharArray();

			long total = 0;

			for (int i = 0; i < digits.Length; i++)
				total += ParseChar(digits[i]);

			return total;
		}

		private static long ParseChar(char digit) => (long) Char.GetNumericValue(digit);

		private static long ReverseNumber(long number)
		{
			char [] cardNumberChars = number.ToString().ToCharArray();

			string finalCardNumberStr = "";

			for (int i = cardNumberChars.Length - 1; i >= 0; i--)
				finalCardNumberStr += cardNumberChars[i];

			return long.Parse(finalCardNumberStr);
		}

		private static long RemoveLastDigit(long number)
		{
			string cardNumberStr = number.ToString();
			string finalCardNumberStr = 
				cardNumberStr.Substring(0, cardNumberStr.Length - 1);

			return long.Parse(finalCardNumberStr);
		}

		private static long GetLastDigit(long number)
		{
			string cardNumberStr = number.ToString();
			string digit = cardNumberStr.Substring(cardNumberStr.Length - 1);

			return long.Parse(digit);
		}
	}
}

using System;

namespace CardValidator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(CardHandler.ValidateCard(1234567890123456));
			Console.WriteLine(CardHandler.ValidateCard(1234567890123452));
		}
	}
}

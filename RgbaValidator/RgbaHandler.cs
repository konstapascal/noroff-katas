using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RgbaValidator
{
	public static class RgbaHandler
	{
		public static bool ValidateString(string str)
		{
			// Check for whitespace before parantheses
			if (str[3] == ' ' || str[4] == ' ')
				return false;

			// Check if RGBA or RGB and extract values
			bool isRgba = IsRgba(str);
			string[] valuesArr = ExtractValues(str);

			// Validate RGBA or RGB
			if (isRgba)
				return ValidateRgbaValues(valuesArr);
			
			return ValidateRgbValues(valuesArr);
		}


		private static bool ValidateRgbaValues(string[] valuesArr)
		{
			if (valuesArr.Contains(string.Empty)) return false;



			bool IsRgbValid = ValidateRgbValues(valuesArr);
			bool IsAlphaValid = ValidateAlpha(a);

			return IsRgbValid && IsAlphaValid;
		}

		private static bool ArePercentsValid(string[] valuesArr)
		{
			List<double> newValuesArr = new();
			List<bool> boolValues = new();

			foreach (string value in valuesArr)
			{
				string withoutPercent = value.Remove(value.Length - 1);
				double newValue = Double.Parse(withoutPercent);
				
				newValuesArr.Add(newValue);
			}

			foreach (double item in newValuesArr)
				boolValues.Add(IsBetweenRange(item, 0, 100));
		
			if (boolValues.TrueForAll(value => value))
				return true;

			return false;
		}

		private static bool IsBetweenRange(double item, int v1, int v2) 
			=> (item >= v1 && item <= v2);

		private static bool ValidateAlpha(double a)
		{
			bool validAlpha = true;

			if (a > 1 || a < 0) validAlpha = false;

			return validAlpha;
		}

		private static bool ValidateRgbValues(string[] valuesArr)
		{
			if (valuesArr.Contains(string.Empty))
				return false;

			if (valuesArr.Any(value => value.EndsWith('%')))
				return ArePercentsValid(valuesArr);

			return false;
		}

		private static string[] ExtractValues(string str)
		{
			int start = str.IndexOf('(') + 1;
			int end = str.IndexOf(')');

			string values = str.Substring(start, end - start);
			string[] valuesArr = values.Split(',');

			return valuesArr;
		}

		private static bool IsRgba(string str) 
			=> str.ToLower().StartsWith("rgba");
	}
}

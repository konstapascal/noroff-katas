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
			if (str[3] == ' ' || str[4] == ' ') return false;

			if (IsRgba(str))
				return ValidateRgbaValues(ExtractValues(str));
			
			return ValidateRgbValues(ExtractValues(str));
		}

		private static bool ValidateRgbaValues(string[] valuesArr)
		{
			if (valuesArr.Contains(string.Empty)) return false;
			if (valuesArr.Length != 4) return false;

			bool IsRgbValid = ValidateRgbValues(valuesArr[..^1]);
			bool IsAlphaValid = ValidateAlpha(valuesArr[3]);

			return IsRgbValid && IsAlphaValid;
		}

		private static bool ValidateRgbValues(string[] valuesArr)
		{
			if (valuesArr.Contains(string.Empty)) return false;
			if (valuesArr.Length != 3) return false;

			bool usesPercent = usesPecentValues(valuesArr);

			return usesPercent ? ArePercentsValid(valuesArr) : AreValuesValid(valuesArr);
		}

		private static bool AreValuesValid(string[] valuesArr)
		{
			bool isInvalid = valuesArr.Any(value => !IsBetweenRange(Double.Parse(value), 0, 255));
		
			return isInvalid ? false : true;
		}

		private static bool usesPecentValues(string[] valuesArr) =>
			(valuesArr.Any(value => value.EndsWith('%'))) ? true : false;

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
		
			if (boolValues.TrueForAll(value => value)) return true;

			return false;
		}

		private static bool IsBetweenRange(decimal item, int v1, int v2) 
			=> (item >= v1 && item <= v2);
		private static bool IsBetweenRange(double item, int v1, int v2)
			=> (item >= v1 && item <= v2);

		private static bool ValidateAlpha(string alpha)
		{
			bool isPercentValue = alpha.Contains('%');
			bool hasLeadingZero = alpha.StartsWith('.');

			if (isPercentValue)
			{
				string alphaRemovedSign = alpha.Remove(alpha.Length - 1);
				double alphaRemovedSignDouble = Double.Parse(alphaRemovedSign);
			
				if (!IsBetweenRange(alphaRemovedSignDouble, 0, 100)) return false;
				return true;
			}

			// if (hasLeadingZero) { }

			decimal alphaDecimal = decimal.Parse(alpha, System.Globalization.NumberStyles.None);

			if (!IsBetweenRange(alphaDecimal, 0, 100)) return false;

			return true;
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

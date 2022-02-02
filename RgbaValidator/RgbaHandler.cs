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
			if (str[3] == '\u0020' || str[4] == '\u0020') return false;

			bool isRgba = IsRgba(str);
			string values = ExtractValues(str);
			
			string[] valuesArr = values.Split(',');

			if (isRgba) ValidateRgbaValues(valuesArr);

			return ValidateRgbValues(valuesArr);
		}


		private static bool ValidateRgbaValues(string[] valuesArr)
		{
			if (valuesArr.Length != 4) return false;

			List<double> newValuesArr = new();

			foreach (string item in valuesArr)
			{
				string trimmed = item.Trim();
				newValuesArr.Add(Double.Parse(trimmed));
			}

			double r = newValuesArr[0];
			double g = newValuesArr[1];
			double b = newValuesArr[2];
			double a = newValuesArr[3];

			bool IsRgbValid = ValidateRgbValues(r, g, b);
			bool IsAlphaValid = ValidateAlpha(a);

			return IsRgbValid && IsAlphaValid;
		}

		private static bool ValidateAlpha(double a)
		{
			bool validAlpha = true;

			if (a > 1 || a < 0) validAlpha = false;

			return validAlpha;
		}

		private static bool ValidateRgbValues(double r, double g, double b)
		{
			bool validR = true;
			bool validG = true;
			bool validB = true;
			
			if (r > 255 || r < 0) validR = false;
			if (g > 255 || g < 0) validG = false;
			if (b > 255 || b < 0) validB = false;

			return validR && validG && validB;
		}

		private static bool ValidateRgbValues(string[] valuesArr)
		{
			if (valuesArr.Length != 3) return false;

			double r = double.Parse(valuesArr[0]);
			double g = double.Parse(valuesArr[1]);
			double b = double.Parse(valuesArr[2]);

			return ValidateRgbValues(r, g, b);
		}

		private static string ExtractValues(string str)
		{
			int start = str.IndexOf('(') + 1;
			int end = str.IndexOf(')');

			string values = str.Substring(start, end - start);

			return values;
		}

		private static bool IsRgba(string str) => str.ToLower().StartsWith("rgba");
	}
}

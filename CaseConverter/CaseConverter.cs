using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseConverter
{
    internal class CaseConverter
    {
        internal static string ToCamelCase(string str)
        {
            string newStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                char curr = str[i];

                if (curr == '_')
                {
                    char next = str[i + 1];
                    char nextUpper = Char.ToUpper(next);
                    string nextUpperStr = nextUpper.ToString();

                    newStr = str.Remove(i, 2);
                    newStr = newStr.Insert(i, nextUpperStr);
                }
            }

            return newStr;
        }

        internal static string ToSnakeCase(string str)
        {
            string newStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                char curr = str[i];

                if (Char.IsUpper(curr))
                {
                    char currLower = Char.ToLower(curr);
                    string currLowerStr = currLower.ToString();

                    newStr = str.Remove(i, 1);
                    newStr = newStr.Insert(i, $"_{currLowerStr}");
                }
            }

            return newStr;
        }
    }
}

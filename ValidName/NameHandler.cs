using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidName
{
    public class NameHandler
    {
        public static bool Validate(string str)
        {
            // Checks for fails
            if (!IsValidLength(str)) return false;
            if (!isCapitalized(str)) return false;
            if (!hasValidInitials(str)) return false;
            if (!hasValidNames(str)) return false;
            if (!isCorrectOrder(str)) return false;

            return true;
        }

        private static bool isCorrectOrder(string str)
        {
            var strArr = str.Split(' ');

            // Has 3 terms
            if (strArr.Length == 3)
            {
                if (strArr[2].Length == 2) return false;
                if (strArr[0].Length == 2 && strArr[1].Length > 2) return false;

                return true;
            }

            // Has 2 terms
            return true;
        }

        private static bool hasValidNames(string str)
            => str.Split(' ').All(str => (str.Length > 2) ? !str.EndsWith('.') : true);

        private static bool hasValidInitials(string str)
            => str.Split(' ').All(term =>
            {
                if (term.Length == 1) return false;
                if (term.Length == 2 && !term.EndsWith('.')) return false;

                return true;
            });

        private static bool isCapitalized(string str)
            => str.Split(' ').All(term => Char.IsUpper(term[0]));

        private static bool IsValidLength(string str) 
            => (str.Split(' ').Length == 2) || (str.Split(' ').Length == 3);
    }
}

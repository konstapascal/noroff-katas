using System;

namespace CaseConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CaseConverter.ToCamelCase("hello_edabit"));
            Console.WriteLine(CaseConverter.ToSnakeCase("helloEdabit"));
        }
    }
}

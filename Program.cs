using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Args = { "Daniel" };
            CompareStrings(Args);
            Console.ReadKey();
        }
        private static void CompareStrings(params string[] stringsToCompare)
        {

            Console.WriteLine("Hello. Starting compareStrings");
            if (stringsToCompare.Length < 2) { Console.WriteLine("At least 2 strings are needed to compare.");return; }

            foreach (string stringElement in stringsToCompare)
            {
                Console.WriteLine(stringElement);
            }

        }
    }
}

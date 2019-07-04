using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace StringCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> M3uList = new List<string>(){ "Url1","Url2"};
            CompareStrings(M3uList,"I am String",M3uList,"Test string II");
            Console.ReadKey();
        }
       

        private static void CompareStrings(params dynamic[] StringsToCompare)
        {
            Console.WriteLine("Hello. Starting CompareStrings");
            List<string> stringsList = new List<string>();
            foreach(dynamic  Element in StringsToCompare)
            {
                if(Element is List<string>)
                {
                    stringsList.AddRange( Element);
                }else if(Element is string)
                {
                    stringsList.Add(Element);
                }
            }
            Console.WriteLine("Printing stringsList needed");
            foreach(string stringToPrint in stringsList)
            {
                Console.WriteLine(stringToPrint);
            }
        }
    }
}

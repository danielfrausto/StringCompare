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
            
            List<string> M3uList = new List<string>(){ "UrlOne","Url2"};
            CompareStrings(M3uList,"I am String",M3uList,"Test string II");
            Console.ReadKey();
        }
       

        private static void CompareStrings(params dynamic[] StringsToCompare)
        {
            //  Check if there's more 2 or more strings to compare.
            if (StringsToCompare.Count() < 2 && !(StringsToCompare[0] is List<string>)) {
                Console.WriteLine("2 or more strings needed to use CompareStrings()");
                return;
            }

            Console.WriteLine(AppStrings.VoidCompareStrings);
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

            //  Setup string containers
            for(int x = 0; x < stringsList.Count()-1; x++)
            {
                string Primary = (stringsList[x].Length <= stringsList[x + 1].Length) ? stringsList[x] : stringsList[x + 1];
                string Secondary = (stringsList[x].Length > stringsList[x + 1].Length) ? stringsList[x] : stringsList[x + 1];
                Console.WriteLine( "~:  Primary = "+Primary + " | Secondary = "+Secondary);
            }
        }
    }
}

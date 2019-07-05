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
                Console.WriteLine(AppStrings.CompareStringsWarning);
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
            for(int x = 0; x <= stringsList.Count()-2; x++)
            {
                //  bool to detect difference in string
                bool differenceDetected = false;

                string Primary = (stringsList[x].Length >= stringsList[x + 1].Length) ? stringsList[x] : stringsList[x + 1];
                string Secondary = (stringsList[x].Length < stringsList[x + 1].Length) ? stringsList[x] : stringsList[x + 1];
                
                //  Just to check propper string was set as Primary/Secondary. Comment out to not print line.
                //Console.WriteLine( "~:  Primary = "+Primary.Length + " | Secondary = "+Secondary.Length);

                //  Start to compare strings
                string outputSame = string.Empty;
                string []differeces = AppContainers.Differences;
                for(int i =0; i < Primary.Length; i++)
                {
                    if (i < Secondary.Length)
                    {
                        if (Primary[i] == Secondary[i] && differenceDetected == false)
                        {
                            outputSame = outputSame + Primary[i];
                        }
                        else
                        {
                            differenceDetected = true;
                        }
                        if (differenceDetected == true)
                        {
                            differeces[0] = differeces[0] + Primary[i].ToString();
                            differeces[1] = differeces[1] + Secondary[i].ToString();
                        }
                    }else if (i >= Secondary.Length)
                    {
                        differeces[0] = differeces[0] + Primary[i].ToString();
                    }
                }
                if (outputSame != "")
                {
                    Console.WriteLine(AppStrings.SameIndicator + outputSame);
                    Console.WriteLine(AppStrings.DifferenceIndicatorA + differeces[0]);
                    Console.WriteLine(AppStrings.DifferenceIndicatorB + differeces[1]);
                }
            }
        }
    }
}

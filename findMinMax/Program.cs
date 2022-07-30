using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace findMinMax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double EPS = 0.0001;

            #region taskText
            /* task
               user input 5 numbers (any format) ( realization notes input + split + format validation?)
               find min/max number
               find this number index (not use lists?)
               minimize count of comparisons
            */
            #endregion

            Console.WriteLine("Input 5 number separeted by spaces: \n");
            string inputDataRaw = Console.ReadLine();
            string[] inputDataSplitted = inputDataRaw.Split(' ');

            if (inputDataSplitted.Length != 5)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: invalid numbers amount");
                Console.ForegroundColor = ConsoleColor.White;
                endDialog();
            }
            else
            {
                List<double> doubleList = new List<double>(inputDataSplitted.Length);
                for (int i = 0; i < inputDataSplitted.Length; i++)
                {
                    doubleList.Add(GetDoubleNumber(inputDataSplitted[i]));
                }

                #region array min max

                //double maxValue = doubleList.Max();
                //int maxindex = doubleList.IndexOf(maxValue);
                //double minValue = doubleList.Min();
                //int minIndex = doubleList.IndexOf(minValue);

                //Console.WriteLine("Max is number on place {0}: {1}, \n Min in place {2} number: {3}", maxindex+1, maxValue, minIndex+1, minValue );

                #endregion







                endDialog();
            }
        }

        private static void endDialog()
        {
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        private static double GetDoubleNumber(string stringValue)
        {
            bool success = double.TryParse(stringValue, out double number);
            if (success)
            {
                return number;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: parsing error of {0}", stringValue);
                Console.ForegroundColor = ConsoleColor.White;
                return 0;
            }
        }
    }
}

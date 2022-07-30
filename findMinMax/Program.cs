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

                #region logical and + compare

                double maxNumber;
                int numberPlace;

                if (compare(EPS, doubleList, 0, 1) & compare(EPS, doubleList, 0, 2) & compare(EPS, doubleList, 0, 3) & compare(EPS, doubleList, 0, 4))
                {
                    Console.WriteLine();
                    maxNumber = doubleList[0];
                    numberPlace = 1;
                }
                else
                {
                    if (compare(EPS, doubleList, 1, 2) & compare(EPS, doubleList, 1, 3) & compare(EPS, doubleList, 1, 4))
                    {
                        maxNumber = doubleList[1];
                        numberPlace = 2;
                    }

                    else
                    {
                        if (compare(EPS, doubleList, 2, 3) & compare(EPS, doubleList, 2, 4))
                        {
                            maxNumber = doubleList[2];
                            numberPlace = 3;
                        }
                        else
                        {
                            if (compare(EPS, doubleList, 3, 4))
                            {
                                maxNumber = doubleList[3];
                                numberPlace = 4;
                            }
                            else
                            {
                                maxNumber = doubleList[4];
                                numberPlace = 5;
                            }
                        }

                    }

                }

                Console.WriteLine("Max number is {0} \n Place: {1}", maxNumber, numberPlace);
                #endregion





                endDialog();
            }
        }

        private static bool compare(double EPS, List<double> doubleList, int indexFirstNumber, int indexSecondNumber)
        {
            if (doubleList[indexFirstNumber] > doubleList[indexSecondNumber])
            {
                Console.WriteLine("TRUE  {0} > {1}", doubleList[indexFirstNumber], doubleList[indexSecondNumber]);
                return true;
            }
            else
            {
                Console.WriteLine("FALSE {0} > {1}", doubleList[indexFirstNumber], doubleList[indexSecondNumber]);
                return false;
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

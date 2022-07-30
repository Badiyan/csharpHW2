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
//            const double EPS = 0.0001;

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
                Console.WriteLine("\n First varaint - arrays: \n");
                FirstVariantUseArray(doubleList);

                #endregion

                #region logical and + compare
                Console.WriteLine("\n Second varaint - if else  // one with all other: \n");
                SecondVarianIfElse(doubleList);
                #endregion

                #region pair min max with a lot variables
                Console.WriteLine("\n third varaint - if else extra variables \n");
                PairCompair(doubleList);
                #endregion

                #region pair min max without extra vars 
                Console.WriteLine("\n 4 varaint - if else compare 2 and 3\n");
                PairCompair2(doubleList);
                #endregion

                endDialog();
            }
        }

        private static void PairCompair(List<double> doubleList)
        {
            double number1, number2, number3, number4, number5, firstPairMax, secondPairMax, firstPairMin, secondPairMin, max, min;
            number1 = doubleList[0];
            number2 = doubleList[1];
            number3 = doubleList[2];
            number4 = doubleList[3];
            number5 = doubleList[4];

            if (number1 > number2)
            {
                firstPairMax = number1;
                firstPairMin = number2;
            }
            else
            {
                firstPairMax = number2;
                firstPairMin = number1;
            }

            if (number3 > number4)
            {
                secondPairMax = number3;
                secondPairMin = number4;
            }
            else
            {
                secondPairMax = number4;
                secondPairMin = number3;
            }


            if (firstPairMax > secondPairMax)
            {
                max = firstPairMax;
            }
            else
            {
                max = secondPairMax;
            }

            if (firstPairMin < secondPairMin)
            {
                min = firstPairMin;
            }
            else
            {
                min = secondPairMin;
            }

            if (number5 > max)
            {
                max = number5;
            }

            if (number5 < min)
            {
                min = number5;
            }

            int minNumberIndex = doubleList.IndexOf(min) + 1;
            int maxNumberIndex = doubleList.IndexOf(max) + 1;

            Console.WriteLine("Max number is {0} on place {1} \n Min number is {2} on place {3}", max, maxNumberIndex, min, minNumberIndex);
        }

        private static void PairCompair2(List<double> doubleList)
        {
            double number1, number2, number3, number4, number5, max, min;
            number1 = doubleList[0];
            number2 = doubleList[1];
            number3 = doubleList[2];
            number4 = doubleList[3];
            number5 = doubleList[4];
            

            if (number1 > number2)
            {
                max = number1;
                min = number2;
            }
            else
            {
                max = number2;
                min = number1;
            }

            if (number3 > max)
            {
                max = number3;
            }
            else
            {
                if (number3 < min)
                {
                    min = number3;
                }
            }

            if (number4 > max)
            {
                max = number4;
            }
            else
            {
                if (number4 < min)
                {
                    min = number4;
                }
            }

            if (number5 > max)
            {
                max = number5;
            }
            else
            {
                if (number5 < min)
                {
                    min = number5;
                }
            }

            int minNumberIndex = doubleList.IndexOf(min) + 1;
            int maxNumberIndex = doubleList.IndexOf(max) + 1;

            Console.WriteLine("Max number is {0} on place {1} \n Min number is {2} on place {3}", max, maxNumberIndex, min, minNumberIndex);
        }

        private static void SecondVarianIfElse(List<double> doubleList)
        {
            double maxNumber;
            int maxNumberPlace;

            if (IsFirstNumberBigger(doubleList, 0, 1) & IsFirstNumberBigger(doubleList, 0, 2) & IsFirstNumberBigger(doubleList, 0, 3) & IsFirstNumberBigger(doubleList, 0, 4))
            {
                maxNumber = doubleList[0];
                maxNumberPlace = 1;

            }
            else
            {
                if (IsFirstNumberBigger(doubleList, 1, 2) & IsFirstNumberBigger(doubleList, 1, 3) & IsFirstNumberBigger(doubleList, 1, 4))
                {
                    maxNumber = doubleList[1];
                    maxNumberPlace = 2;

                }

                else
                {
                    if (IsFirstNumberBigger(doubleList, 2, 3) & IsFirstNumberBigger(doubleList, 2, 4))
                    {
                        maxNumber = doubleList[2];
                        maxNumberPlace = 3;

                    }
                    else
                    {
                        if (IsFirstNumberBigger(doubleList, 3, 4))
                        {
                            maxNumber = doubleList[3];
                            maxNumberPlace = 4;
                        }
                        else
                        {
                            maxNumber = doubleList[4];
                            maxNumberPlace = 5;
                        }
                    }

                }

            }

            Console.WriteLine("Max number is {0} \n Place: {1}", maxNumber, maxNumberPlace);

            double minNumber;
            int minNumberPlace;

            if (IsFirstNumberSmaller(doubleList, 0, 1) & IsFirstNumberSmaller(doubleList, 0, 2) & IsFirstNumberSmaller(doubleList, 0, 3) & IsFirstNumberSmaller(doubleList, 0, 4))
            {
                minNumber = doubleList[0];
                minNumberPlace = 1;

            }
            else
            {
                if (IsFirstNumberSmaller(doubleList, 1, 2) & IsFirstNumberSmaller(doubleList, 1, 3) & IsFirstNumberSmaller(doubleList, 1, 4))
                {
                    minNumber = doubleList[1];
                    minNumberPlace = 2;

                }

                else
                {
                    if (IsFirstNumberSmaller(doubleList, 2, 3) & IsFirstNumberSmaller(doubleList, 2, 4))
                    {
                        minNumber = doubleList[2];
                        minNumberPlace = 3;

                    }
                    else
                    {
                        if (IsFirstNumberSmaller(doubleList, 3, 4))
                        {
                            minNumber = doubleList[3];
                            minNumberPlace = 4;
                        }
                        else
                        {
                            minNumber = doubleList[4];
                            minNumberPlace = 5;
                        }
                    }

                }

            }

            Console.WriteLine("Min number is {0} \n Place: {1}", minNumber, minNumberPlace);
        }

        private static void FirstVariantUseArray(List<double> doubleList)
        {
            double maxValue = doubleList.Max();
            int maxindex = doubleList.IndexOf(maxValue);
            double minValue = doubleList.Min();
            int minIndex = doubleList.IndexOf(minValue);

            Console.WriteLine("Max is number on place {0}: {1}, \n Min in place {2} number: {3}", maxindex + 1, maxValue, minIndex + 1, minValue);
        }

        private static bool IsFirstNumberBigger( List<double> doubleList, int indexFirstNumber, int indexSecondNumber)
        {
            if (doubleList[indexFirstNumber] > doubleList[indexSecondNumber])
            {
               // Console.WriteLine("TRUE  {0} > {1}", doubleList[indexFirstNumber], doubleList[indexSecondNumber]);
                return true;
            }
            else
            {
               // Console.WriteLine("FALSE {0} > {1}", doubleList[indexFirstNumber], doubleList[indexSecondNumber]);
                return false;
            }
        }

        private static bool IsFirstNumberSmaller(List<double> doubleList, int indexFirstNumber, int indexSecondNumber)
        {
            if (doubleList[indexFirstNumber] < doubleList[indexSecondNumber])
            {
                // Console.WriteLine("TRUE  {0} < {1}", doubleList[indexFirstNumber], doubleList[indexSecondNumber]);
                return true;
            }
            else
            {
               // Console.WriteLine("FALSE {0} < {1}", doubleList[indexFirstNumber], doubleList[indexSecondNumber]);
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

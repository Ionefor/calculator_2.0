using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator_2._0
{
    public class Main
    {     
        public Main(string FirstPart, string SecondPart)
        {
            _ = decimal.Parse(FirstPart);
            _ = decimal.Parse(SecondPart);
        }

        /* Сумма */
        public static decimal Sum(decimal FirstNumber, decimal SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }

        /* Разность */
        public static decimal Difference(decimal FirstNumber, decimal SecondNumber)
        {
            return FirstNumber - SecondNumber;
        }

        /* Произведение */
        public static decimal Product(decimal FirstNumber, decimal SecondNumber)
        {
            return FirstNumber * SecondNumber;
        }

        /* Приведение вещественных чисел к целым */
        public static void DecimalToInt(string NumOne, string NumTwo, out int NOne, out int NTwo)
        {
            bool flagComma = true;
            int countOne = 0, countTwo = 0;
            decimal NewNumOne, NewNumTwo;

            foreach (char c in NumOne)
            {
                if (c == ',')
                {
                    flagComma = false;
                }
                else if (!flagComma)
                {
                    countOne++;
                }
            }

            flagComma = true;

            foreach (char c in NumTwo)
            {
                if (c == ',')
                {
                    flagComma = false;
                }
                else if (!flagComma)
                {
                    countTwo++;
                }
            }

            NewNumOne = decimal.Parse(NumOne);
            NewNumTwo = decimal.Parse(NumTwo);

            int count = (countOne > countTwo) ? countOne : countTwo;

            for (int i = 0; i < count; i++)
            {
                NewNumOne *= 10;
                NewNumTwo *= 10;
            }

            NOne = (int)NewNumOne;
            NTwo = (int)NewNumTwo;
        }

        /* Частное */
        public static decimal Quotient(decimal FirstNumber, decimal SecondNumber)
        {
            string NumberOneS = Convert.ToString(FirstNumber);
            string NumberTwoS = Convert.ToString(SecondNumber);
            string TempResult = "";

            int countZero = 0, countNum = 0;
            int countSize = 0;
            int countSign = 1;
            bool flagNull = false;

            DecimalToInt(NumberOneS, NumberTwoS, out int NumberOne, out int NumberTwo);

            while (NumberOne != 0)
            {
                while (NumberOne >= NumberTwo)
                {
                    NumberOne -= NumberTwo;
                    countNum++;
                }
                
                if (TempResult == "")
                {
                    TempResult += Convert.ToString(countNum) + ',';

                    while(countNum >0)
                    {
                        countNum /= 10;
                        countSize++;
                    }
                }
                else
                {
                    TempResult += Convert.ToString(countNum);
                }
               
                while (NumberOne < NumberTwo && NumberOne != 0)
                {
                    NumberOne *= 10;
                    countZero++;

                    if(countZero > 1)
                    {
                        TempResult += '0';
                    }
                }

                for (int i = countSize + 2; i < TempResult.Length;i++)
                {
                    if(TempResult[i] == TempResult[i-1])
                    {
                        countSign++;
                    }
                    else
                    {
                        countSign=1;
                    }

                    if(TempResult[^1] == '0')
                    {
                        flagNull = true;
                    }
                }

                if(countSign == 3)
                {
                    break;
                }
                
                if(TempResult.Length > 15 && flagNull)
                {
                    TempResult = TempResult[..^1];
                }
                else if(TempResult.Length > 15)
                {
                    break;
                }

                countNum = 0;
                countZero = 0;
                flagNull = false;
            }
           
            return _ = decimal.Parse(TempResult);
        }
    }
}

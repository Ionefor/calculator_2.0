using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator_2._0
{
    public class main
    {
        public bool TypeNumbers(string TextNumber)
        {
            bool flagDouble = false;

            foreach (char c in TextNumber)
            {
                if (c == ',')
                {
                    flagDouble = true;
                    break;
                }
            }
            return flagDouble;

        }


        public main(string FirstPart, string SecondPart)
        {
            /*if(TypeNumbers(FirstPart))
            {
                double FirstNumber= Double.Parse(FirstPart);
            }
            else
            {
                int FirstNumber = int.Parse(FirstPart);
            }

            if (TypeNumbers(SecondPart))
            {
                double SecondNumber = Double.Parse(SecondPart);
            }
            else
            {
                int SecondNumber = int.Parse(SecondPart);
            }*/
            decimal FirstNumber = decimal.Parse(FirstPart);
            decimal SecondNumber = decimal.Parse(SecondPart);

        }

        public decimal Sum(decimal FirstNumber, decimal SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }

        public decimal Difference(decimal FirstNumber, decimal SecondNumber)
        {
            return FirstNumber - SecondNumber;
        }

        public decimal Product(decimal FirstNumber, decimal SecondNumber)
        {
            return FirstNumber * SecondNumber;
        }

        public decimal Quotient(decimal FirstNumber, decimal SecondNumber)
        {
            return FirstNumber * SecondNumber;
        }
    }
}

#nullable disable
using System.Text.RegularExpressions;

namespace calculator_2._0
{
    public partial class Form1 : Form
    {
        public string FirstPart, SecondPart, CurrentLine, expression;
        public char FlagOperation = '!';
        public bool FlagEqually = false , FlagComma = false, FlagReplay = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void NullKey_Click(object sender, EventArgs e)
        {
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "0";
            }
            else
            {
                Result.Text = "0";
                FlagEqually = false;
            }         
        }

        private void OneKey_Click_Click(object sender, EventArgs e)
        {
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "1";
            }
            else
            {                
                Result.Text = "1";
                FlagEqually = false;
            }                      
        }

        private void TwoKey_Click(object sender, EventArgs e)
        {
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "2";
            }
            else
            {
                Result.Text = "2";
                FlagEqually = false;
            }           
        }

        private void ThreeKey_Click(object sender, EventArgs e)
        {
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "3";
            }
            else
            {
                Result.Text = "3";
                FlagEqually = false;
            }
        }

        private void FourKey_Click(object sender, EventArgs e)
        {
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "4";
            }
            else
            {
                Result.Text = "4";
                FlagEqually = false;
            }           
        }

        private void FiveKey_Click(object sender, EventArgs e)
        {       
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "5";
            }
            else
            {
                Result.Text = "5";
                FlagEqually = false;
            }            
        }

        private void SixKey_Click(object sender, EventArgs e)
        {
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "6";
            }
            else
            {
                Result.Text = "6";
                FlagEqually = false;
            }           
        }

        private void SevenKey_Click(object sender, EventArgs e)
        {
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "7";
            }
            else
            {
                Result.Text = "7";
                FlagEqually = false;
            }
        }

        private void EightKey_Click(object sender, EventArgs e)
        {
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "8";
            }
            else
            {
                Result.Text = "8";
                FlagEqually = false;
            }            
        }

        private void NineKey_Click(object sender, EventArgs e)
        {
            if (!FlagEqually && Result.Text != "0")
            {
                Result.Text += "9";
            }
            else
            {
                Result.Text = "9";
                FlagEqually = false;
            }           
        }

        private void PlusKey_Click(object sender, EventArgs e)
        {          
            FlagEqually = false;
            FlagComma = false;
            FlagReplay = false;
            FlagOperation = '+';

            FirstPart = Result.Text;
            Result.Text += "+\r\n";                     
        }

        private void MinusKey_Click(object sender, EventArgs e)
        {
            FlagEqually = false;         
            FlagComma = false;
            FlagOperation = '-';

            FirstPart = Result.Text;
            Result.Text += "-\r\n";
        }

        private void MultiplicationKey_Click(object sender, EventArgs e)
        {
            FlagEqually = false;           
            FlagComma = false;
            FlagOperation = '*';

            FirstPart = Result.Text;
            Result.Text += "*\r\n";
        }

        private void DivisionKey_Click(object sender, EventArgs e)
        {
            FlagEqually = false;
            FlagComma = false;
            FlagOperation = '/';
            
            FirstPart = Result.Text;
            Result.Text += "÷\r\n";
        }

        private void CommaKey_Click(object sender, EventArgs e)
        {           
            FlagEqually = false;

            if (FlagOperation != '!')
            {
                CurrentLine = Result.Text;
                CurrentLine = Regex.Replace(CurrentLine, @"[ \r\n+*÷-]", "");
                CurrentLine = CurrentLine[FirstPart.Length..];

                foreach (Char c in CurrentLine)
                {
                    if (c == ',')
                    {
                        FlagComma = true;
                        break;
                    }
                }

                if (CurrentLine == "" && !FlagComma)
                {
                    Result.Text += "0,";
                }
                else if (!FlagComma)
                {
                    Result.Text += ",";
                }
            }
            else
            {
                foreach (Char c in Result.Text)
                {
                    if (c == ',')
                    {
                        FlagComma = true;
                        break;
                    }
                }

                if (Result.Text == "" && !FlagComma)
                {
                    Result.Text += "0,";
                }
                else if (!FlagComma)
                {
                    Result.Text += ",";
                }
            }
        }

        private void ClearKey_Click(object sender, EventArgs e)
        {
            FlagEqually = false;

            if (Result.Text.Length != 0)
            {
                Result.Text = null;
                FirstPart = "";
                SecondPart = "";
            }         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RemoveKey_Click(object sender, EventArgs e)
        {
            if(Result.Text.Length != 0 && !FlagEqually)
            {
                Result.Text = Result.Text[..^1];
            }       
        }

        private void EquallyKey_Click(object sender, EventArgs e)
        {
            if (FlagOperation != '!')
            {
                FlagComma = false;
                FlagEqually = true;

                if(FlagReplay)
                {
                    int len = FirstPart.Length + SecondPart.Length;

                    FirstPart = Regex.Replace(Result.Text, @"[ \r\n=+*÷-]", "");
                    FirstPart = FirstPart[len..];
                }
                else
                {
                    SecondPart = Result.Text;
                    SecondPart = Regex.Replace(SecondPart, @"[ \r\n=+*÷-]", "");
                    SecondPart = SecondPart[FirstPart.Length..];
                }

                _ = new Main(FirstPart, SecondPart);

                switch (FlagOperation)
                {
                    case '+':
                        {                          
                            expression = FirstPart + '+' + SecondPart + '=' + '\r' + '\n';
                            
                            Result.Text = expression + Convert.ToString(Main.Sum(decimal.Parse(FirstPart), decimal.Parse(SecondPart)));
                            break;
                        }
                    case '-':
                        {
                            expression = FirstPart + '-' + SecondPart + '=' + '\r' + '\n';

                            Result.Text = expression + Convert.ToString(Main.Difference(decimal.Parse(FirstPart), decimal.Parse(SecondPart)));
                            break;
                        }
                    case '*':
                        {
                            expression = FirstPart + '*' + SecondPart + '=' + '\r' + '\n';

                            Result.Text = expression + Convert.ToString(Main.Product(decimal.Parse(FirstPart), decimal.Parse(SecondPart)));
                            break;
                        }
                    case '/':
                        {
                            if (SecondPart == "0")
                            {
                                Result.Text = "Деление на ноль невозможно";
                                break;
                            }

                            expression = FirstPart + '÷' + SecondPart + '=' + '\r' + '\n';
                            Result.Text = expression + Convert.ToString(Main.Quotient(decimal.Parse(FirstPart), decimal.Parse(SecondPart)));
                            break;
                        }
                    default: break;
                }
                FlagReplay = true;
            }
        }      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkVarneyGUICalc
{
    // InputToList Breaks input equation(string) to a List that contains an element for each signed number or operator
    // Class's methods scan through the individual chars of the input string breaking them up using an algorithm
    class InputToList
    {
        //i and k are counters for the loop through the string. K is always 1 above i until the last element
        int i = 0;
        int k = 0;
        Boolean itsSigned = false;

        StringBuilder stringBuilder = new StringBuilder();

        public List<string> Breakup(string input)
        {
            List<string> brokenUp = new List<string>();
            if (input[0] == '+' || input[0] == '-')
                itsSigned = true;

            // Asseses wether to add a number or a operator

            while (k < input.Length)
            {

                if (char.IsNumber(input[i]) || itsSigned == true || input[i] == '.')
                {
                    AddNumber(input, brokenUp);
                }

                if (input[i] == '-' || input[i] == '+' && itsSigned == false)
                {
                    AddOpp(input, brokenUp);
                }

                if (input[i] == '*' || input[i] == '/' || input[i] == '%' || input[i] == '^')
                {
                    AddOpp(input, brokenUp);
                }
            }
            return brokenUp;
        }

        //Adds the number by appending the chars to a string, until an operator is reached

        private void AddNumber(string input, List<string> brokenUp)
        {
            while (char.IsNumber(input[i]) || itsSigned == true || input[i] == '.')
            {
                stringBuilder.Append(input[i]);
                itsSigned = false;
                if (k < input.Length)
                {
                    k++;
                }
                if (i < (input.Length - 1))
                    i++;
                else
                    break;
            }
            brokenUp.Add(stringBuilder.ToString());
            stringBuilder.Clear();
        }

        //adds a operator to the list, if another operator followers, changes the value of the Booleon itsSigned to true
        //so the program knows to add it with a number
        private void AddOpp(string input, List<string> brokenUp)
        {
            stringBuilder.Append(input[i]);
            brokenUp.Add(stringBuilder.ToString());
            stringBuilder.Clear();
            if (k < input.Length)
            {
                k++;
            }
            if (i < (input.Length - 1))
            {
                i++;
                if (input[i] == '-' || input[i] == '+')
                {
                    itsSigned = true;
                }
            }
        }
    }
}

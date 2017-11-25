using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkVarneyGUICalc
{
    //Class Checks that the string input is in the correct format (num, op, num, op, num)
    class InputChecker
    {

        public Boolean CheckInput(string input)
        {
            Boolean areCharValid = true;
            Boolean isformatCorrect = true;
            Boolean isDecptCorrect = true;
            Boolean isThereMoreThanOneChar = true;

            isThereMoreThanOneChar = IsThereMoreThanOneChar(input);

            if (isThereMoreThanOneChar == true)
            {
                areCharValid = AreTheCharsValid(input);
                isformatCorrect = IsTheFormatCorrect(input);
                isDecptCorrect = DecimalChecker(input);
                if (areCharValid == true && isformatCorrect == true && isDecptCorrect == true)
                    return true;
                else
                    return false;
            }
            else
                return false; 
        }

        private Boolean IsThereMoreThanOneChar(string input)
        {
            if (input.Length > 2)
            {
                return true;
            }
            else
            {
                return false; 
            }
                
        }

        //method loops through input ensuring that only numbers, decimal points and the correct 6 operators are contained 
        //in the input string
        private Boolean AreTheCharsValid(string input)
        {
            Boolean localAreCharValid = true;
            for (int i = 0; i < input.Length; i++)
            {
                if ((Char.IsNumber(input[i]) == false) && (input[i] != '+' && input[i] != '-' && input[i] != '.'))
                {
                    if (input[i] != '*' && input[i] != '/' && input[i] != '%' && input[i] != '^')
                        localAreCharValid = false;
                }

            }

            return localAreCharValid;
        }

        //impliments algorithm to ensure that incorrect combinations of operators and numbers are not accepted
        private Boolean IsTheFormatCorrect(string input)
        {
            Boolean localIsFormatCorrect = true;
            Boolean toggle = false;
            int i = 0;
            int k = i + 1;

            if (input[i] == '*' || input[i] == '/' || input[i] == '%')
                localIsFormatCorrect = false;

            for (i = 0; i < (input.Length - 1); i++)
            {
                k = i + 1;
                if (input[i] == '*' && ((Char.IsNumber(input[k]) == false) && input[k] != '.' && input[k] != '-' && input[k] != '+'))
                    localIsFormatCorrect = false;
                if (input[i] == '/' && ((Char.IsNumber(input[k]) == false) && input[k] != '.' && input[k] != '-' && input[k] != '+'))
                    localIsFormatCorrect = false;
                if (input[i] == '%' && ((Char.IsNumber(input[k]) == false) && input[k] != '.' && input[k] != '-' && input[k] != '+'))
                    localIsFormatCorrect = false;
                if (input[i] == '^' && ((Char.IsNumber(input[k]) == false) && input[k] != '.' && input[k] != '-' && input[k] != '+'))
                    localIsFormatCorrect = false;
                if (input[i] == '.' && (Char.IsNumber(input[k]) == false))
                    localIsFormatCorrect = false;
                if (input[i] == '+' || input[i] == '-')
                {
                    if (input[k] != '+' && input[k] != '-')
                        toggle = false;

                    if (toggle == true)
                        localIsFormatCorrect = false;
                    if (input[k] == '*' || input[k] == '/' || input[k] == '%')
                        localIsFormatCorrect = false;
                    if (input[k] == '+' || input[k] == '-')
                        toggle = true;
                }
            }
            if (Char.IsNumber(input[k]) == false)
                localIsFormatCorrect = false;

            return localIsFormatCorrect;
        }

        //Checks that only one decimal place is between each operator
        private Boolean DecimalChecker(string input)
        {
            int y = 0;
            Boolean localIsDecptCorrect = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.')
                    y++;
                if (input[i] == '/' || input[i] == '%' || input[i] == '*')
                    y = 0;
                if (input[i] == '^' || input[i] == '-' || input[i] == '+')
                    y = 0;
                if (y > 1)
                    localIsDecptCorrect = false;
            }

            return localIsDecptCorrect;
        }
    }
}

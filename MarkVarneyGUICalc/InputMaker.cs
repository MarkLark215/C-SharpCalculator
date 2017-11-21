using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkVarneyGUICalc
{
    public class InputMaker
    {
        /*stringBuilder holds a "string" (I know 'not really') and ShouldIReplace acts as a switch so that the program knows when to 
        clear stringBuilder and start writing again to the stringBuilder
        */
        StringBuilder stringBuilder = new StringBuilder();
        Boolean shouldIReplace = true;

        //Adds chars to the string
        public void AddToString(char character)
        {

            if (character == '.')
            {
                if ((stringBuilder.ToString().Length == 0) || shouldIReplace == true)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append('0');
                    stringBuilder.Append(character);
                    shouldIReplace = false;
                }
                else
                    stringBuilder.Append(character);
            }
            if (Char.IsNumber(character))
            {
                if (shouldIReplace == true)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(character);
                }
                else
                    stringBuilder.Append(character);
            }
            if (character == '+' || character == '-' || character == '^')
            {
                stringBuilder.Append(character);
                shouldIReplace = false;
            }
            if (character == '*' || character == '/' || character == '%')
            {
                stringBuilder.Append(character);
                shouldIReplace = false;
            }

            shouldIReplace = false;
        }

        //Overload, so strings can be added
        public void AddToString(string temp)
        {
            stringBuilder.Clear();
            stringBuilder.Append(temp);
        }

        //Returns the correct string to the caller
        public string GetString()
        {

            if (stringBuilder.ToString().Length == 0)
            {
                return "0";
            }
            else
            {
                string x = stringBuilder.ToString();

                return x;
            }
        }

        //Called by calcForm1 to reset ShouldIReplace
        public void SetShouldIReplace(Boolean temp)
        {
            shouldIReplace = temp;
        }

        //So the CL can clear the the string

        public void Clear()
        {
            stringBuilder.Clear();
        }

        //So CE can backspace
        public void Bckspc()
        {

            string before = stringBuilder.ToString();
            if (before.Length > 0)
            {
                int x = before.Length;
                stringBuilder.Remove(x - 1, 1);
            }

        }
    }
}


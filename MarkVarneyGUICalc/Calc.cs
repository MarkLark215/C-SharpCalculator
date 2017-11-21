using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkVarneyGUICalc
{
    public class Calc
    {
        public string DoCalc(string input)
        {            
            InputChecker inputchecker1 = new InputChecker();

            if (inputchecker1.CheckInput(input) == true)
            {
                InputToList inputToList1 = new InputToList();
                List<string> items = inputToList1.Breakup(input);
                if (items.Count <= 1)
                {
                   return "Invalid Input";
                }
                else
                {                      
                        List<string> powered = new List<string>();
                        ToThePower toThePower1 = new ToThePower();
                        powered = toThePower1.DoThePower(items);
                        List<string> muledDivedModed = new List<string>();
                        MulDivMod instance2 = new MulDivMod();
                    try
                    {
                        muledDivedModed = instance2.Simplify(powered);
                    }
                    catch (DivideByZeroException)
                    {
                        return "Division by zero";
                    }

                    double result = AddSub.AdderSubber(muledDivedModed);

                        string resultString = result.ToString();
                        return resultString;                                     
                }
            }
            else
                return "Invalid Input";
        }   
    }
}

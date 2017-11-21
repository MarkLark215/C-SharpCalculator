using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkVarneyGUICalc
{
    class AddSub
    {
        public static double AdderSubber(List<string> items)

        {            
            // get inital number (z) that will be added/subtracted

            double z = Double.Parse(items[0]);

            //loop through string array adding and subtracting z by the number that comes next
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals("+"))
                {
                    int k;
                    k = i + 1;
                    double temp = Double.Parse(items[k]);
                    z = checked(z + temp);
                }
                if (items[i].Equals("-"))
                {
                    int k;
                    k = i + 1;
                    double temp = Double.Parse(items[k]);
                    z = z - temp;
                }
            }

            // return z which is now the result of the equation in the string array
            return z;            
        }
    }
}

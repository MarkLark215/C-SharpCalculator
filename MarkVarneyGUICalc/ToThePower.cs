using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkVarneyGUICalc
{
    class ToThePower
    {
        List<string> powered = new List<string>();
        int i;
        int k = 0;
        double z;
        int p = 0;

        public List<string> DoThePower(List<string> items)
        {

            // loop through items, if a sequence of '*', '/' or '%' is encountered call the relvant methods, than add 
            //the result to muledDivedModed in the correct order
            while (i < (items.Count))
            {
                p = i - 1;
                if (i < (items.Count - 1))
                {
                    k = i + 1;
                }
                if (Double.TryParse(items[i], out z) && (items[k].Equals("+") || items[k].Equals("-")))
                {
                    powered.Add(items[i]);
                    i++;
                    p = i - 1;
                }
                if (Double.TryParse(items[i], out z) && (items[k].Equals("*") || items[k].Equals("/") || items[k].Equals("%")))
                {
                    powered.Add(items[i]);
                    i++;
                    p = i - 1;
                }
                if (items[i].Equals("+") || items[i].Equals("-") || items[i].Equals("*") || items[i].Equals("/") || items[i].Equals("%"))
                {
                    powered.Add(items[i]);
                    i++;
                    p = i - 1;
                }

                //If '^' is encountered make a sublist containing the numbers and '^' that need to be computed and send to Calc,
                //add result to powered
                if (Double.TryParse(items[i], out z) && items[k].Equals("^"))
                {
                    List<string> tempList = SublistMaker(items);
                    double result = Calc(tempList);
                    powered.Add(result.ToString());
                }
                if (i < items.Count && Double.TryParse(items[i], out z) && i == (items.Count - 1) && (items[p].Equals("+") || items[p].Equals("-")))
                {
                    powered.Add(items[i]);
                    i++;
                    p = i - 1;
                }
                if (i < items.Count && Double.TryParse(items[i], out z) && i == (items.Count - 1) && (items[p].Equals("/") || items[p].Equals("*") || items[p].Equals("%")))
                {
                    powered.Add(items[i]);
                    i++;
                    p = i - 1;
                }
            }

            return powered;
        }

        private List<string> SublistMaker(List<string> items)
        {
            List<string> temp = new List<string>();

            while (Double.TryParse(items[i], out z) || items[i].Equals("^"))
            {
                temp.Add(items[i]);
                if (i < (items.Count))
                {
                    i++;
                    p = i - 1;
                }
                if (i > (items.Count - 1))
                {

                    break;
                }
            }
            return temp;
        }

        private double Calc(List<string> templist)
        {
            Double basenum = Double.Parse(templist[0]);

            for (int i = 0; i < templist.Count; i++)
            {
                if (templist[i].Equals("^"))
                {
                    int k;
                    k = i + 1;
                    double exponential = Double.Parse(templist[k]);
                    basenum = Math.Pow(basenum, exponential);
                }
            }

            return basenum;
        }
    }
}

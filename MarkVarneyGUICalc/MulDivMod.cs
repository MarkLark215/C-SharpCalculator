using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkVarneyGUICalc
{
    //Class contains a method that loops through items adding numbers to the list muledDivedModed that do not need to be  
    //timesed, Divided or  moduloed and + and - operators. If sequences of numbers with * or % or / are encountered 
    //these are evaluated and the result placed in the correct position in muledDivedModed.
    class MulDivMod
    {
        List<string> muledDivedModed = new List<string>();

        //i is a counter, p is a counter that sits one below i while k sits 1 above. Z is just for the tryparses.  
        int i;
        int k = 0;
        double z;
        int p = 0;

        public List<string> Simplify(List<string> items)
        {

            if (items.Count <= 1)
                muledDivedModed = items;

            else
                muledDivedModed = DoSimplify(items);

            return muledDivedModed;
        }

        private List<string> DoSimplify(List<string> items)
        {
            // loop through items, if a sequence of '*', '/' or '%' is encountered call the relvant methods, than add 
            //the result to muledDivedModed
            while (i < (items.Count))
            {
                p = i - 1;
                if (i < (items.Count - 1))
                {
                    k = i + 1;
                }

                if (Double.TryParse(items[i], out z) && (items[k].Equals("+") || items[k].Equals("-")))
                {
                    muledDivedModed.Add(items[i]);
                    i++;
                    p = i - 1;
                }

                if (items[i].Equals("+") || items[i].Equals("-"))
                {
                    muledDivedModed.Add(items[i]);
                    i++;
                    p = i - 1;
                }

                if (Double.TryParse(items[i], out z) && (items[k].Equals("*") || items[k].Equals("/") || items[k].Equals("%")))
                {
                    List<string> tempList = SublistMaker(items);
                    double result = Calc(tempList);
                    muledDivedModed.Add(result.ToString());

                }

                if (i < items.Count && Double.TryParse(items[i], out z) && i == (items.Count - 1) && (items[p].Equals("+") || items[p].Equals("-")))
                {
                    muledDivedModed.Add(items[i]);
                    i++;
                    p = i - 1;
                }
            }

            return muledDivedModed;
        }

        private List<string> SublistMaker(List<string> items)
        {
            //Put numbers that need to be evaluated in sub array
            List<string> temp = new List<string>();
            while (Double.TryParse(items[i], out z) || items[i].Equals("*") || items[i].Equals("/") || items[i].Equals("%"))
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

        //Evaluate sub array, return result

        private double Calc(List<string> subList)
        {
            try
            {
                Double y = Double.Parse(subList[0]);
                for (int i = 0; i < subList.Count; i++)
                {
                    if (subList[i].Equals("*"))
                    {
                        int k;
                        k = i + 1;
                        double temp = Double.Parse(subList[k]);
                        y = (y * temp);
                    }
                    if (subList[i].Equals("/"))
                    {

                        int k;
                        k = i + 1;
                        double temp = Double.Parse(subList[k]);
                        y = y / temp;
                        if (Double.IsInfinity(y) == true)
                            throw new DivideByZeroException();
                    }
                    if (subList[i].Equals("%"))
                    {

                        int k;
                        k = i + 1;
                        double temp = Double.Parse(subList[k]);
                        y = y % temp;
                        if (Double.IsInfinity(y) == true)
                            throw new DivideByZeroException();
                    }

                }

                return y;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException();
            }
        }
    }
}

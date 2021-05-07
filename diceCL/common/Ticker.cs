using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public class Ticker : Type
    {
        //Create a Ticker with Max value and a starting value
        public Ticker(int max, int starting)
        {
            if(max < 0)
            {
                max = -max;//If max is a negative set it equal to negative max
            }
            if (max < starting)
            {
                starting = max;//If starting value is greater that max it sets starter to max
            }
            if (-max > starting)
            {
                starting = -max;//If starting value is less than negative max it sets starter to negative max
            }
            number = starting;
            maxNum = max;
        }
        //Modifys the ticker value in ticker
        public int modify(int mod)
        {
            number += mod;
            if (number > maxNum)//Stops number being greater that max
            {
                number = maxNum;
            }else if(number < -maxNum)//Stops the value be less the negative MaxNumber
            {
                number = -maxNum;
            }
            return number;
        }
    }
}

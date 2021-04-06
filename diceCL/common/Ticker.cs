using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public class Ticker : Type
    {

        public Ticker(int max, int starting)
        {
            if (max < starting)
            {
                starting = max;
            }
            number = starting;
            maxNum = max;
        }
        
        public int modify(int mod)
        {
            number += mod;
            if (number > maxNum)
            {
                number = maxNum;
            }else if(number < -maxNum)
            {
                number = -maxNum;
            }
            return number;
        }
        
        
    }
}

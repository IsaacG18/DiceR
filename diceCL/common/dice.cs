using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public class dice : Type
    {
        private int modifyNum;
        Random rand = new Random();
        //Creates a dice object with a user enter mod number
        public dice(int num, int mod)
        {
            if (num < 0)
            {
                num = -num;
            }
            maxNum = num;
            modify(mod);
        }
        //Creates a dice object with a  mod number of 0
        public dice(int num)
        {
            if (num < 0)
            {
                num = -num;
            }
            maxNum = num;
            modify(0);
        }
        //Set mod number
        public int modify(int mod)
        {
            modifyNum = mod;
            return modifyNum;
        }
        //get mod number
        public int getModify()
        {
            return modifyNum;
        }
        //Random generates number based on dice fields
        public int rollDice()
        {
            number = rand.Next(1, maxNum + 1) + modifyNum;
            return getNumber();
        }
    }
}

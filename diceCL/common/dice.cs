using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public class dice
    {
        private int maxNum;
        private int roll;
        Random rand = new Random();
        public dice(int num)
        {
            maxNum = num + 1;
        }
        public int modify(int mod, bool add)
        {
            if (add == true)
            {
                roll += mod;
            }
            else
            {
                roll -= mod;
            }
            return roll;
        }
        public int rollDice()
        {
            roll = rand.Next(1, maxNum);
            return getRoll();
        }
        public int getRoll()
        {
            return roll;
        }
        public int getSize()
        {
            return maxNum;
        }
    }
}

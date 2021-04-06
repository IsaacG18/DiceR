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
        public dice(int num, int mod)
        {
            maxNum = num + 1;
            modify(mod);
        }
        public dice(int num)
        {
            maxNum = num + 1;
            modify(0);
        }
        public int modify(int mod)
        {
            modifyNum = mod;
            return modifyNum;
        }
        public int rollDice()
        {
            number = rand.Next(1, maxNum) + modifyNum;
            return getNumber();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public abstract class Type
    {
        protected int number;
        protected int maxNum;
        //Gets and returns Number
        public int getNumber()
        {
            return number;
        }
        //Gets and returns maxNum
        public int getMaxSize()
        {
            return maxNum;
        }
    }
}

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
        public int getNumber()
        {
            return number;
        }
        public int getSize()
        {
            return maxNum;
        }
    }
}

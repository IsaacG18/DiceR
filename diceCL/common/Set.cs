using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public abstract class Set
    {
        protected string name;
        protected int max;
        protected int retNum;
        protected int amount;

        public bool isEmpty()
        {
            if (amount == 0)
            {
                return true;
            }
            return false;
        }
        public bool isFull()
        {
            if (amount == max)
            {
                return true;
            }
            return false;
        }
        public void reset()
        {
            amount = 0;
        }
        public string getName()
        {
            return name;
        }
        public string setName(string sName)
        {
            name = sName;
            return name;
        }
        public int size()
        {
            return amount;
        }
        public int getRetNum()
        {
            return retNum;
        }
    }
}

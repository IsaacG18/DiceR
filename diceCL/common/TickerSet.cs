using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public class TickerSet : Set
    {
        
        private Ticker[] tSet;
        private Ticker retTicker;

        public TickerSet(int count, string sName)
        {
            max = count;
            amount = 0;
            tSet = new Ticker[count];
            setName(sName);
        }
       
        public Ticker tick()
        {
            return retTicker;
        }
        public bool addTicker(Ticker t)
        {
            if (isFull())
            {
                return false;
            }
            tSet[amount] = t;
            amount++;
            return true;
        }
        public bool addFull(Ticker t)
        {
            while (!isFull())
            {
                addTicker(t);
            }
            return true;
        }
        public bool deleteTicker(int num)
        {
            if (isEmpty())
            {
                return false;
            }
            for (int i = 0; i < amount; i++)
            {
                if (tSet[i].getNumber() == num)
                {
                    Ticker[] temp = tSet;
                    amount--;
                    for (int j = i; j < amount; j++)
                    {
                        tSet[j] = temp[j + 1];
                    }
                    return true;
                }
            }
            return false;
        }
        
        public bool getTicker(int num)
        {
            if (amount <= num)
            {
                return false;
            }
            retNum = tSet[num].getNumber();
            retTicker = tSet[num];
            return true;
        }
        
    }
}

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

        //TickerSet CTOR, it inisalizes max and name
        public TickerSet(int count, string sName)
        {
            max = count;
            amount = 0;
            tSet = new Ticker[count];
            setName(sName);
        }
        //Returns retTicker
        public Ticker tick()
        {
            return retTicker;
        }
        //Adds a new Ticker and returns true if added
        public bool addTicker(Ticker t)
        {
            if (isFull())//Check if has tSet is full
            {
                return false;
            }
            tSet[amount] = t;
            amount++;
            return true;
        }
        //Adds until the tSet is full
        public bool addFull(Ticker t)
        {
            while (addTicker(t));//Loop until addTicker returns false

            return true;
        }
        //Deletes a Ticker based on its number
        public bool deleteTicker(int num)
        {
            if (isEmpty())//Checks if tSet is empty
            {
                return false;
            }
            for (int i = 0; i < amount; i++)//Loops though each set tSet
            {
                if (tSet[i].getNumber() == num)//Checks if number matches arguement
                {
                    Ticker[] temp = tSet;
                    amount--;
                    for (int j = i; j < amount; j++)//Saves over deleted value with a loop
                    {
                        tSet[j] = temp[j + 1];
                    }
                    return true;
                }
            }
            return false;
        }
        //Get ticker based on postion
        public bool getTicker(int num)
        {
            if (amount <= num)//Check if number is greater the postion
            {
                return false;
            }
            retNum = tSet[num].getNumber();
            retTicker = tSet[num];
            return true;
        }
        
    }
}

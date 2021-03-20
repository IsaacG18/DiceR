using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public class DiceSet
    {
        private dice[] dSet;
        private int max;
        private int retNum;
        private int amount;
        public DiceSet(int count)
        {
            max = count;
            amount = 0;
            dSet = new dice[count];
        }
        public bool isEmpty()
        {
            if (amount == 0)
            {
                return true;
            }
                return false;
        }
        public bool ifFull()
        {
            if (amount == max)
            {
                return true;
            }
            return false;
        }

        public bool addDice(dice d)
        {
            if (ifFull())
            {
                return false;
            }
            dSet[amount] = d;
            amount++;
            return true;
        }
        public int addSetDice(dice[] d)
        {
            int added = 0;
            for (int i = 0; i < d.Length; i++)
            {
                if (!addDice(d[i]))
                {
                    break;
                }
                added++;
            }
            return added;
        }
        public bool delDice(int size)
        {
            if (isEmpty())
            {
                return false;
            }
            for (int i = 0; i < amount; i++)
            {
                if (dSet[i].getSize() == size)
                {
                    dice[] temp = dSet;
                    amount--;
                    for (int j = i; j < amount; j++)
                    {
                        dSet[j] = temp[j + 1];
                    }
                    return true;
                }
            }
            return false;
        }

        public bool addFull(int num)
        {
            while (!ifFull())
            {
                dice d = new dice(num);
                addDice(d);
            }
            return true;
        }
        public void reset()
        {
            amount = 0;
        }
        public bool deleteDice(int num)
        {
            if (isEmpty())
            {
                return false;
            }
            for (int i = 0; i < amount; i++)
            {
                if (dSet[i].getRoll() == num)
                {
                    dice[] temp = dSet;
                    amount--;
                    for (int j = i; j < amount; j++)
                    {
                        dSet[j] = temp[j + 1];
                    }
                    return true;
                }
            }
            return false;
        }
        public bool getDice(int num)
        {
            if (isEmpty())
            {
                return false;
            }
            for (int i = 0; i < amount; i++)
            {
                if (dSet[i].getRoll() == num)
                {
                    retNum = num;
                    return true;
                }
            }
            return false;
        }
        public int getAllNum(int num)
        {
            int count = 0;
            for (int i = 0; i < amount; i++)
            {
                if (dSet[i].getRoll() == num)
                {
                    count++;
                }
            }
            return count;
        }
        public int num()
        {
            return retNum;
        }
        public int[] rollAll(int modD, int modAll)
        {
            int[] rolls = new int[amount];
            retNum = modAll;
            for (int i = 0; i < amount; i++)
            {
                retNum += rolls[i] = dSet[i].rollDice() + modD;
            }
            return rolls;
        }
    }
}

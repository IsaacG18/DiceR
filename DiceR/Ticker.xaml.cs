using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DiceR.common;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiceR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ticker : Page
    {
        static int memory = 5;
        TickerSet[] tSA = new TickerSet[memory];
        TickerSet cTS;
        int current = 0;
        int currentVal = 0;
        int size = 4;
        public Ticker()
        {
            this.InitializeComponent();
        }
        private void addSet(object sender, RoutedEventArgs e)
        {
            string name = setName.Text;
            cTS = new TickerSet(size, name);
            memoryName();
        }
        private void deleteSet(object sender, RoutedEventArgs e)
        {
            cTS = new TickerSet(size, "Empty Slot");
            tSA[current] = cTS;
            memoryName();
        }
        private void Reset(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                changeNum(i, "");
            }
            
            cTS = new TickerSet(size, cTS.getName());
            tSA[current] = cTS;
        }
        private void memoryName()
        {
            TextBlock[] memory = { memory1, memory2, memory3, memory4, memory5 };
            memory[current].Text = cTS.getName();
            setName.Text = "";
        }
        private void Select1(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;
            cTS = tSA[0];
            current = 0;
        }
        private void Select2(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;
            cTS = tSA[1];
            current = 1;
        }
        private void Select3(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;
            cTS = tSA[2];
            current = 2;
        }
        private void Select4(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;
            cTS = tSA[3];
            current = 3;
        }
        private void Select5(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;
            cTS = tSA[4];
            current = 4;
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            
            int amount, max, start;
            try
            {
                amount = Int32.Parse(amountRoll.Text);
            }
            catch
            {
                amount = 1;
            }
            try
            {
                max = Int32.Parse(maxNum.Text);
            }
            catch
            {
                max = 0;
            }

            try
            {
                start = Int32.Parse(startNum.Text);
            }
            catch
            {
                start = 0;
            }
            if(cTS == null)
            {
                cTS = new TickerSet(size, "Empty Slot");
            }


            for (int i = 0; i < amount; i++)
            {
                if(currentVal >= size)
                {
                    break;
                }

                common.Ticker tick = new common.Ticker(max, start);
                cTS.addTicker(tick);
                changeNum(i, start.ToString());
                currentVal++;
            }

            amountRoll.Text = "";
            maxNum.Text = "";
            startNum.Text = "";

        }
        public void changeNum(int valNum, string change)
        {
            TextBlock[] value = { value1, value2, value3, value4 };
            value[valNum].Text = change;
        }

        private void modBut(object sender, RoutedEventArgs e)
        {
            int i = 0;
            Button[] butAdd = { addNum1, addNum2, addNum3, addNum4 };
            Button[] butSub = { subNum1, subNum2, subNum3, subNum4 };
            foreach (Button b in butAdd) {
                if (sender == b)
                {
                    modNum(i, true);
                }
                i++;
            }
            i = 0;
            foreach (Button b in butSub)
            {
                if (sender == b)
                {
                    modNum(i , false);
                }
                i++;
            }

        }
        private void modNum(int num, bool boolAdd)
        {
            TextBox[] textB = {Num1, Num2, Num3, Num4 };
            int mod = 0 ;
            try
            {
                mod = Int32.Parse(textB[num].Text);
            }
            catch
            {
                
            }
            
            if (!boolAdd) mod = -mod;
            cTS.getTicker(num);
            cTS.tick().modify(mod);

            changeNum(num, cTS.tick().getNumber().ToString());
        }
    }
}

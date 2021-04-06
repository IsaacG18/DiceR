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
    public sealed partial class Versus : Page
    {
        static int amount = 5;
        DiceSet rDS = new DiceSet(amount, "Right");
        DiceSet lDS = new DiceSet(amount, "Left");
        public Versus()
        {
            this.InitializeComponent();
        }

        private void addDice(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int[] diceNum = { 4, 6, 8, 10, 12, 20 };
            Button[] addLeftDice = { LD4, LD6, LD8, LD10, LD12, LD20 }; 
            Button[] addRightDice = { RD4, RD6, RD8, RD10, RD12, RD20 };
            foreach (Button b in addRightDice)
            {
                if (sender == b)
                {
                    dice d = new dice(diceNum[i]);
                    rDS.addDice(d);
                }
                i++;
            }
            i = 0;
            foreach (Button b in addLeftDice)
            {
                if (sender == b)
                {
                    dice d = new dice(diceNum[i]);
                    lDS.addDice(d);
                }
                i++;
            }
        }

        private void rollAll(object sender, RoutedEventArgs e)
        {
            int modRight = 0;
            try
            {
                modRight = Int32.Parse(RightMod.Text);
            }
            catch
            {
                modRight = 0;
            }
            int modLeft = 0;
            try
            {
                modLeft = Int32.Parse(LeftMod.Text);
            }
            catch
            {
                modLeft = 0;
            }
            int[] leftNums = lDS.rollAll(modLeft);
            int[] rightNums = rDS.rollAll(modRight);
            TextBlock[] diceRollsLeft = { result1, result2, result3, result4, result5};
            TextBlock[] diceRollsRight = {result6, result7, result8, result9, result10 };
            int i = 0;
            int size = leftNums.Length;
            foreach (TextBlock dR in diceRollsLeft)
            {
                if (size > i)
                {
                    dR.Text = leftNums[i].ToString();
                }
                else
                {
                    dR.Text = "";
                }
                i++;
            }
            i = 0;
            size = rightNums.Length;
            foreach (TextBlock dR in diceRollsRight)
            {
                if (size > i)
                {
                    dR.Text = leftNums[i].ToString();
                }
                else
                {
                    dR.Text = "";
                }
                i++;
            }
            Left.Text = lDS.getRetNum().ToString();
            Right.Text = rDS.getRetNum().ToString();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            if(sender == RightClear)
            {
                rDS.reset();
                TextBlock[] diceRollsRight = { result6, result7, result8, result9, result10 };
                foreach (TextBlock dR in diceRollsRight)
                {
                        dR.Text = "";
                }
                Right.Text = "";
                RightMod.Text = "";
            }
            else if(sender == LeftClear)
            {
                lDS.reset();
                TextBlock[] diceRollsLeft = { result1, result2, result3, result4, result5 };
                foreach (TextBlock dR in diceRollsLeft)
                {
                    dR.Text = "";
                }
                Left.Text = "";
                LeftMod.Text = "";
            }
        }
    }
}

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
            int[] diceNum = { 4, 6, 8, 10, 12, 20 };//Array of interagers that represet the values of the dice rolls
            Button[] addLeftDice = { LD4, LD6, LD8, LD10, LD12, LD20 }; //Array of button that represet the left sides dice adding
            Button[] addRightDice = { RD4, RD6, RD8, RD10, RD12, RD20 };//Array of button that represet the rights sides dice adding

            foreach (Button b in addRightDice)//For each button in addRightDice
            {
                if (sender == b)//If button and sender match
                {
                    dice d = new dice(diceNum[i]);
                    rDS.addDice(d);//Adds a new dice to right dice set
                }
                i++;
            }
            i = 0;
            foreach (Button b in addLeftDice)//For each button in addLeftDice
            {
                if (sender == b)//If button and sender match
                {
                    dice d = new dice(diceNum[i]);
                    lDS.addDice(d);//Adds a new dice to right dice set
                }
                i++;
            }
            errorMessage("");
        }

        private void rollAll(object sender, RoutedEventArgs e)
        {
            int modRight = 0;
            try
            {
                modRight = Int32.Parse(RightMod.Text);//Try to convert string to int for modify right
            }
            catch
            {
                if(RightMod.Text.Trim() == "")
                {
                    modRight = 0;
                }
                else
                {
                    errorMessage("Right Modify to delete an is illegal input");
                    return;
                }
                
            }
            if (modRight < 0)
            {
                errorMessage("Right Modify is less than or equal to 0 which is an illegal input");
            }
            int modLeft = 0;
            try
            {
                modLeft = Int32.Parse(LeftMod.Text);//Try to convert string to int for modify left
            }
            catch
            {
                if (LeftMod.Text.Trim() == "")
                {
                    modLeft = 0;
                }
                else
                {
                    errorMessage("Left Modify to delete an is illegal input");
                    return;
                }
            }
            if (modLeft < 0)
            {
                errorMessage("Left Modify is less than or equal to 0 which is an illegal input");
            }
            int[] leftNums = lDS.rollAll(modLeft);//Roll left dice set and get values in int vector
            int[] rightNums = rDS.rollAll(modRight);//Try to convert string to int for modify right
            TextBlock[] diceRollsLeft = { result1, result2, result3, result4, result5};//Array of text blocks that represet the left sides dice rolls displayed
            TextBlock[] diceRollsRight = {result6, result7, result8, result9, result10 };//Array of text blocks that represet the right sides dice rolls displayed
            int i = 0;
            int size = leftNums.Length;
            foreach (TextBlock dR in diceRollsLeft)//Loops through each diceRollsLeft
            {
                if (size > i)//Check if loop goes above size
                {
                    dR.Text = leftNums[i].ToString();//Get that dice value as a string and display it
                }
                else
                {
                    dR.Text = "";//Reset text block value
                }
                i++;
            }
            i = 0;
            size = rightNums.Length;
            foreach (TextBlock dR in diceRollsRight)//Loops through each diceRollsRight
            {
                if (size > i)//Check if loop goes above size
                {
                    dR.Text = rightNums[i].ToString();//Get that dice value as a string and display it
                }
                else
                {
                    dR.Text = "";//Reset text block value
                }
                i++;
            }
            Left.Text = lDS.getRetNum().ToString();//Gets the total of the left side and displays it
            Right.Text = rDS.getRetNum().ToString();//Gets the total of the right side and displays it
            errorMessage("");
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            if(sender == RightClear)//If button and sender match
            {
                rDS.reset();
                TextBlock[] diceRollsRight = { result6, result7, result8, result9, result10 };//Array of text blocks that represet the right sides results
                foreach (TextBlock dR in diceRollsRight)//Loops through each diceRollsRight
                {
                        dR.Text = "";//Reset text block value
                }
                Right.Text = "";
                RightMod.Text = "";
            }
            else if(sender == LeftClear)//If button and sender match
            {
                lDS.reset();
                TextBlock[] diceRollsLeft = { result1, result2, result3, result4, result5 };
                foreach (TextBlock dR in diceRollsLeft)//Loops through each diceRollsLeft
                {
                    dR.Text = "";//Reset text block value
                }
                Left.Text = "";
                LeftMod.Text = "";
            }
            errorMessage("");
        }
        private void errorMessage(string errorMes)
        {
            error.Text = errorMes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class Game : Page
    {
        int amount;
        bool ready = false;
        DiceSet rDS;
        DiceSet lDS;
        int[] rSaved;
        int[] lSaved;
        public Game()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
        }
        private void Display()
        {
            if (ready)
            {

                TextBlock[] diceRollsLeft = { result1, result2, result3, result4, result5, result6 };//Array of text box that represet left side rolls being displayed
                TextBlock[] diceRollsRight = { result7, result8, result9, result10, result11, result12 };//Array of text box that represet right side rolls being displayed
                TextBlock[] savedLeft = { saved1, saved2, saved3, saved4, saved5, saved6 };//Array of text box that represet left side saved values being displayed
                TextBlock[] savedRight = { saved7, saved8, saved9, saved10, saved11, saved12 };//Array of text box that represet left side saved values being displayed
                int i = 0;
                foreach (TextBlock dR in diceRollsLeft)//For each TextBlock in diceRollsLeft
                {
                    if (lDS.size() > i)//Check if loop goes above size
                    {
                        lDS.getAndDeleteDice(i, "element", false);//Get item by postion in left dice set
                        dR.Text = lDS.getRetNum().ToString();//Get that dice value as a string and display it
                    }
                    else
                    {
                        dR.Text = "";//Reset text box value
                    }
                    i++;
                }
                i = 0;
                foreach (TextBlock dR in diceRollsRight)//For each TextBlock in diceRollsRight
                {
                    if (rDS.size() > i)//Check if loop goes above size
                    {
                        rDS.getAndDeleteDice(i, "element", false);//Get item by postion in right dice set
                        dR.Text = rDS.getRetNum().ToString();//Get that dice value as a string and display it
                    }
                    else
                    {
                        dR.Text = "";//Reset text box value
                    }
                    i++;
                }
                i = 0;
                foreach (TextBlock sL in savedLeft)//For each TextBlock in savedLeft
                {
                    if (lSaved.Length > i)//Check if loop goes above size
                    {
                        sL.Text = lSaved[i].ToString();//Get that dice value as a string and display it
                    }
                    else
                    {
                        sL.Text = "";//Reset text box value
                    }
                    i++;
                }
                i = 0;
                foreach (TextBlock sR in savedRight)//For each TextBlock in savedRight
                {
                    if (rSaved.Length > i)//Check if loop goes above size
                    {
                        sR.Text = rSaved[i].ToString();//Get that dice value as a string and display it
                    }
                    else
                    {
                        sR.Text = "";//Reset text box value
                    }
                    i++;
                }
            }
        }
        private void addSet(object sender, RoutedEventArgs e)
        {
            try
            {
                amount = Int32.Parse(Size.Text);// Try to convert string to int for amount
                Size.Text = "";
            }
            catch
            {
                errorMessage("Amount to delete an is illegal input");
                return;
            }
            if (amount <= 0)
            {
                errorMessage("Amount is less than or equal to 0 which is an illegal input");
                return;
            }
            LeftPlayer.Text = "Left Player";
            RightPlayer.Text = "Right Player";
            int i = 2;
            Button[] diceCount = { two, three, four, five, six };//Array of button that represent how many dice will be added
            foreach (Button b in diceCount)//For each button in diceCount
            {
                if (b == sender)//Check if loop goes above size
                {
                    rDS = new DiceSet(i, "Right");
                    lDS = new DiceSet(i, "Left");
                    rSaved = new int[i];
                    lSaved = new int[i];
                }
                i++;
            }

            
            rDS.addFull(amount);//adds full with dice size of amount to right dice set
            lDS.addFull(amount);//adds full with dice size of amount to left dice set

            ready = true;
            lDS.rollAll(0);//Roll all dice in left dice set
            rDS.rollAll(0);//Roll all dice in right dice set
            Display();
            errorMessage("");
        }
        private void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args)
        {
            if (ready == true)//Only runs if user has start a game
            {
                errorMessage("");
                switch (args.KeyCode)
                {
                    case 13://Enter key
                        lDS.rollAll(0);
                        rDS.rollAll(0);
                        Display();
                        break;
                    case 49://1 key
                        updateSaved(true, 0);
                        break;
                    case 50://2 key
                        updateSaved(true, 1);
                        break;
                    case 51://3 key
                        updateSaved(true, 2);
                        break;
                    case 52://4 key
                        updateSaved(true, 3);
                        break;
                    case 53://5 key
                        updateSaved(true, 4);
                        break;
                    case 54://6 key
                        updateSaved(true, 5);
                        break;
                    case 55://7 key
                        movedSaved(true);
                        break;
                    case 98://b key
                        updateSaved(false, 0);
                        break;
                    case 110://n key
                        updateSaved(false, 1);
                        break;
                    case 109://m key
                        updateSaved(false, 2);
                        break;
                    case 44://, key
                        updateSaved(false, 3);
                        break;
                    case 46://. key
                        updateSaved(false, 4);
                        break;
                    case 47:/// key
                        updateSaved(false, 5);
                        break;
                    case 118://v key
                        movedSaved(false);
                        break;
                    default:
                        break;
                }
            }
        }
        private void movedSaved(bool left)
        {
            if (left)//Check if to effect the left or the right based on the argument
            {
                if (lSaved[0] != 0)//Check if the top value in lsaved does not equal 0
                {
                    dice d = new dice(amount, 0);
                    lDS.addDice(d);//Add a dice to left dice set
                    popNum(lSaved);
                    Display();
                }
            }else
            {
                if (rSaved[0] != 0)//Check if the top value in rsaved does not equal 0
                {
                    dice d = new dice(amount, 0);
                    rDS.addDice(d);//Add a dice to right dice set
                    popNum(rSaved);
                    Display();
                }
            }
        }
        private void updateSaved(bool left, int elem)
        {

                if (left)
                {
                    if (lDS.getAndDeleteDice(elem, "element", false))//Checks if element exist
                    {
                    if (lDS.getRetNum() != 0)//Check if it does it does not equal 0
                    {
                        pushNum(lDS.getRetNum(), lSaved);
                        lDS.getAndDeleteDice(elem, "element", true);//Delete value in left dice set
                    }
                    }
                }
                else
                {
                    if (rDS.getAndDeleteDice(elem, "element", false))//Checks if element exist
                {
                    if (rDS.getRetNum() != 0)//Check if it does it does not equal 0
                    {
                        pushNum(rDS.getRetNum(), rSaved);
                        rDS.getAndDeleteDice(elem, "element", true);// Delete value in right dice set


                    }
                    }
                }
            Display();
            valuesCheck();
            
        }
        private bool pushNum(int value, int[] array)
        {
            for (int i = 0; i < array.Length; i++)//Loops through each value in array
            {
                if (array[i] == 0)
                {
                    array[i] = value;//Adds a value at the first 0 value
                    return true;
                }
            }
            return false;
        }
        private bool popNum(int[] array)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
                    array[i] = array[i + 1];//Saved the next value over the current value
                if (i == array.Length - 2)
                {
                    array[i + 1] = 0;//Turns the last value to 0 only after the value is last postion is moved
                }
            }
            return true;
        }


        private bool valuesCheck()
        {
            bool outPutL = true;
            bool outPutR = true;
            int first = lSaved[0];
            foreach (int lN in lSaved)//Loop through each int inside lSaved
            {
                if (lN == 0 || first != lN)//Check if match the first value or equals 0
                {
                    outPutL = false;//Set false
                    break;
                }
            }
            first = rSaved[0];
            foreach (int rN in rSaved)//Loop through each int inside lSaved
            {
                if (rN == 0 || first != rN)//Check if match the first value or equals 0
                {
                    outPutR = false;
                    break;
                };
            }
            return victoryCheck(outPutL, outPutR);//Send the results to victory check and returns the result
        }
        private bool victoryCheck(bool left, bool right)
        {
            if (left == true && right == true)//Checks in both left and right have won
            {
                LeftPlayer.Text = "Tied";
                RightPlayer.Text = "Tied";
                ready = false;
                return true;
            }
            else if(left == true)//Check if left has won
            {
                LeftPlayer.Text = "Left Wins";
                RightPlayer.Text = "Left Wins";
                ready = false;
                return true;
            }else if(right == true)//Check if right has won
            {
                RightPlayer.Text = "Right Wins";
                LeftPlayer.Text = "Right Wins";
                ready = false;
                return true;
            }
            return false;

        }

        private void GetRules(object sender, RoutedEventArgs e)
        {
            rulesPopUp.IsOpen = true;
        }
        private void errorMessage(string errorMes)
        {
            error.Text = errorMes;
        }
        
    }
}

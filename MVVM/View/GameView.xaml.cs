using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using TicTacToe.Core;

namespace TicTacToe.MVVM.View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        private readonly string UserSymbol = GlobalData.UserSymbol, ComputerSymbol = GlobalData.ComputerSymbol, UserName = GlobalData.UserName;
        private bool firstTurn = true, secondTurn = true, thirdTurn = true;
        private readonly bool First = GlobalData.UserFirst;
        public GameView()
        {
            InitializeComponent();
            SetScoreboard();
            if (First == false)
            {
                ComputerMove();
                DisplayMessage($"Your Move :)");
            }
            else
            {
                DisplayMessage($"{UserName} You're First!");
            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            ChangeButtonProperties(sender as Button, true);
            ComputerMove();
        }
        private bool ButtonIsClicked(Button theButton) => theButton.Content.ToString() != "" ? true : false;
        private void ChangeButtonProperties(Button theButton, bool userTurn = false)
        {
            theButton.Content = userTurn ? UserSymbol : ComputerSymbol;
            theButton.IsEnabled = false;
        }
        private void CatScratch()
        {
            if (ButtonIsClicked(button1) && ButtonIsClicked(button2) &&
                ButtonIsClicked(button3) && ButtonIsClicked(button4) &&
                ButtonIsClicked(button5) && ButtonIsClicked(button6) &&
                ButtonIsClicked(button7) && ButtonIsClicked(button8) &&
                ButtonIsClicked(button9))
            {
                DisplayMessage("Cat Scratch!");
                GlobalData.CatScratches += 1;
                SetScoreboard();
            }
            else
            {
                DisplayMessage("");
            }
        }
        private void ComputerMove()
        {
            //Check the first turn
            if (firstTurn)
            {
                if (UserSymbolButton(button5))
                {
                    ChangeButtonProperties(button1);
                }
                else
                {
                    ChangeButtonProperties(button5);
                }
                if (First)
                {
                    DisplayMessage("Great Choice!");
                }
                else
                {
                    DisplayMessage("Good Luck!");
                }
                firstTurn = false;
                return;
            }
            //Second Turn
            if (secondTurn)
            {
                if (UserSymbolButton(button1) && UserSymbolButton(button6))//Button1 and Button6
                {
                    ChangeButtonProperties(button3);
                }
                else if (UserSymbolButton(button1) && UserSymbolButton(button8))
                {
                    ChangeButtonProperties(button4);
                }
                else if (UserSymbolButton(button1) && UserSymbolButton(button9))
                {
                    ChangeButtonProperties(button4);
                }
                else if (UserSymbolButton(button2) && UserSymbolButton(button9))
                {
                    ChangeButtonProperties(button3);
                }
                else if (UserSymbolButton(button3) && UserSymbolButton(button7))
                {
                    ChangeButtonProperties(button4);
                }
                else if (UserSymbolButton(button5) && UserSymbolButton(button9))
                {
                    ChangeButtonProperties(button3);
                }
                else if (UserSymbolButton(button8) && UserSymbolButton(button3))
                {
                    ChangeButtonProperties(button6);
                }
                else if (UserSymbolButton(button8) && UserSymbolButton(button6))
                {
                    ChangeButtonProperties(button9);
                }
                else if(UserSymbolButton(button6) && UserSymbolButton(button7))
                {
                    ChangeButtonProperties(button8);
                }
                else
                {
                    if (PreventWin() == false)
                    {
                        DefaultMoves();
                    }
                }
                DisplayMessage("I See What You're Trying 🤭");
                secondTurn = false;
                return;
            }
            if (thirdTurn)
            {
                if (MoveForWin() == false)
                {
                    if (UserSymbolButton(button1) && UserSymbolButton(button3) && !UserSymbolButton(button4))
                    {
                        ChangeButtonProperties(button4);
                    }
                    else if (UserSymbolButton(button1) && UserSymbolButton(button6) && UserSymbolButton(button8))
                    {
                        ChangeButtonProperties(button3);
                    }
                    else if (UserSymbolButton(button1) && UserSymbolButton(button8) && ComputerSymbolButton(button2) && ComputerSymbolButton(button5))
                    {
                        ChangeButtonProperties(button4);
                    }
                    else
                    {
                        if (PreventWin() == false)
                        {
                            DefaultMoves();
                        }
                    }
                    DisplayMessage("Keep Trying!");
                }
                thirdTurn = false;
                return;
            }
            if (MoveForWin() == false)
            {
                if (PreventWin() == false)
                {
                    CatScratch();
                    DefaultMoves();
                    return;
                }
            }
        }
        private bool ComputerSymbolButton(Button theButton) => theButton.Content.ToString() == ComputerSymbol;
        private void DefaultMoves()
        {
            //No Other moves, move to the next button
            if (NoTextButton(button1)) ChangeButtonProperties(button1);
            else if (NoTextButton(button2)) ChangeButtonProperties(button2);
            else if (NoTextButton(button3)) ChangeButtonProperties(button3);
            else if (NoTextButton(button4)) ChangeButtonProperties(button4);
            else if (NoTextButton(button5)) ChangeButtonProperties(button5);
            else if (NoTextButton(button6)) ChangeButtonProperties(button6);
            else if (NoTextButton(button7)) ChangeButtonProperties(button7);
            else if (NoTextButton(button8)) ChangeButtonProperties(button8);
            else if (NoTextButton(button9)) ChangeButtonProperties(button9);
        }
        private void DisplayMessage(string message) => MessageBlock.Text = message;
        private void HighlightButton(Button theButton) => theButton.Style = FindResource("TicTacButtonRedTheme") as Style;
        private void LockAllTiles()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
        }
        private bool MoveForWin()
        {
            //Diag (1, 5, 9)
            if (ComputerSymbolButton(button1) && ComputerSymbolButton(button5) && NoTextButton(button9)) // Computer already filled 1 and 5, computer move on 9
            {
                WinMove(button9, button1, button5);
                return true;
            }
            else if (NoTextButton(button1) && ComputerSymbolButton(button5) && ComputerSymbolButton(button9)) //Computer filled on 5 and 9, computer move on 1
            {
                WinMove(button1, button5, button9);
                return true;
            }
            else if (ComputerSymbolButton(button1) && NoTextButton(button5) && ComputerSymbolButton(button9)) //Computer filled on 1 and 9, computer move on 5
            {
                WinMove(button5, button1, button9);
                return true;
            }
            //Diag 2 (3, 5, 7)
            else if (ComputerSymbolButton(button3) && ComputerSymbolButton(button5) && NoTextButton(button7)) //Computer filled on button 3 and 5, computer move on 7
            {
                WinMove(button7, button3, button5);
                return true;
            }
            else if (NoTextButton(button3) && ComputerSymbolButton(button5) && ComputerSymbolButton(button7)) //Computer filled on buttons 5 and 7, computer move on 3 
            {
                WinMove(button3, button5, button7);
                return true;
            }
            else if (ComputerSymbolButton(button3) && NoTextButton(button5) && ComputerSymbolButton(button7)) //Computer fille on buttons 3 and 7, computer move on 5
            {
                WinMove(button5, button3, button7);
                return true;
            }
            //Horizontal 1 (1, 2, 3)
            else if (ComputerSymbolButton(button1) && ComputerSymbolButton(button2) && NoTextButton(button3)) //Computer filled on buttons 1 and 2, computer move on 3
            {
                WinMove(button3, button1, button2);
                return true;
            }
            else if (NoTextButton(button1) && ComputerSymbolButton(button2) && ComputerSymbolButton(button3)) //Computer filled on buttons 2 and 3, computer move on 1
            {
                WinMove(button1, button2, button3);
                return true;
            }
            else if (ComputerSymbolButton(button1) && NoTextButton(button2) && ComputerSymbolButton(button3)) //Computer filled on buttons 1 and 3, computer move on 2
            {
                WinMove(button2, button1, button3);
                return true;
            }
            //Horizontal 2 (4, 5, 6)
            else if (ComputerSymbolButton(button4) && ComputerSymbolButton(button5) && NoTextButton(button6)) //Computer filled on buttons 4 and 5, computer move on 6
            {
                WinMove(button6, button4, button5);
                return true;
            }
            else if (NoTextButton(button4) && ComputerSymbolButton(button5) && ComputerSymbolButton(button6))//Computer filled on buttons 5 and 6, computer move on 4
            {
                WinMove(button4, button5, button6);
                return true;
            }
            else if (ComputerSymbolButton(button4) && NoTextButton(button5) && ComputerSymbolButton(button6))//Computer filled on buttons 4 and 6, computer moved on 5
            {
                WinMove(button5, button4, button6);
                return true;
            }
            //Horizontal 3 (7, 8, 9)
            else if (ComputerSymbolButton(button7) && ComputerSymbolButton(button8) && NoTextButton(button9)) //Computeer filled on 7 and 8, computer move on 9
            {
                WinMove(button9, button7, button8);
                return true;
            }
            else if (NoTextButton(button7) && ComputerSymbolButton(button8) && ComputerSymbolButton(button9))//Computer filled on buttons 8 and 9, computer move on 7
            {
                WinMove(button7, button8, button9);
                return true;
            }
            else if (ComputerSymbolButton(button7) && NoTextButton(button8) && ComputerSymbolButton(button9))//Computer filled on buttons 7 and 9, computer move on 8
            {
                WinMove(button8, button7, button9);
                return true;
            }
            //Vertical 1 (1, 4, 7)
            else if (ComputerSymbolButton(button1) && ComputerSymbolButton(button4) && NoTextButton(button7))//Computer filled on buttons 1 and 4, computer move on 7
            {
                WinMove(button7, button1, button4);
                return true;
            }
            else if (NoTextButton(button1) && ComputerSymbolButton(button4) && ComputerSymbolButton(button7))//computer filled on buttons 4 and 7, computer move on 1
            {
                WinMove(button1, button4, button7);
                return true;
            }
            else if (ComputerSymbolButton(button1) && NoTextButton(button4) && ComputerSymbolButton(button7))//Computer filled on buttons 1 and 7, computer move on 4
            {
                WinMove(button4, button1, button7);
                return true;
            }
            //Vertical 2 (2, 5, 8)
            else if (ComputerSymbolButton(button2) && ComputerSymbolButton(button5) && NoTextButton(button8))//Computer filled on buttons 2 and 5, computer move on 8
            {
                WinMove(button8, button2, button5);
                return true;
            }
            else if (NoTextButton(button2) && ComputerSymbolButton(button5) && ComputerSymbolButton(button8))//Computer filled on buttons 5 and 8, computer move on 2
            {
                WinMove(button2, button5, button8);
                return true;
            }
            else if (ComputerSymbolButton(button2) && NoTextButton(button5) && ComputerSymbolButton(button8))//Computer filled on buttons 2 and 8, computer move on 5
            {
                WinMove(button5, button2, button8);
                return true;
            }
            //Vertical 3 (3, 6, 9)
            else if (ComputerSymbolButton(button3) && ComputerSymbolButton(button6) && NoTextButton(button9))//Computer filled on buttons 3 and 6, computer move on 9
            {
                WinMove(button9, button3, button6);
                return true;
            }
            else if (NoTextButton(button3) && ComputerSymbolButton(button6) && ComputerSymbolButton(button9))//Computer filled on buttons 6 and 9, computer move on button 3
            {
                WinMove(button3, button6, button9);
                return true;
            }
            else if (ComputerSymbolButton(button3) && NoTextButton(button6) && ComputerSymbolButton(button9))//Computer filled on buttons 3 and 9, computer move on button 6
            {
                WinMove(button6, button3, button9);
                return true;
            }
            return false;
        }
        private bool NoTextButton(Button theButton) => theButton.Content.ToString() == "";
        private bool PreventWin()
        {
            if (
                 (NoTextButton(button1) && UserSymbolButton(button5) && UserSymbolButton(button9)) ||
                 (NoTextButton(button1) && UserSymbolButton(button2) && UserSymbolButton(button3)) ||
                 (NoTextButton(button1) && UserSymbolButton(button4) && UserSymbolButton(button7))
               )
            {
                ChangeButtonProperties(button1);
                return true;
            }
            else if (
                 (UserSymbolButton(button1) && NoTextButton(button2) && UserSymbolButton(button3)) ||
                 (NoTextButton(button2) && UserSymbolButton(button5) && UserSymbolButton(button8)) ||
                 (NoTextButton(button2) && UserSymbolButton(button5) && UserSymbolButton(button8))
                )
            {
                ChangeButtonProperties(button2);
                return true;
            }
            else if (
                 (NoTextButton(button3) && UserSymbolButton(button5) && UserSymbolButton(button7)) ||
                 (UserSymbolButton(button1) && UserSymbolButton(button2) && NoTextButton(button3)) ||
                 (NoTextButton(button3) && UserSymbolButton(button6) && UserSymbolButton(button9))
                )
            {
                ChangeButtonProperties(button3);
                return true;
            }
            else if (
                  (NoTextButton(button4) && UserSymbolButton(button5) && UserSymbolButton(button6)) || 
                  (UserSymbolButton(button1) && NoTextButton(button4) && UserSymbolButton(button7))
                )
            {
                ChangeButtonProperties(button4);
                return true;
            }
            else if (
                 (UserSymbolButton(button1) && NoTextButton(button5) && UserSymbolButton(button9)) ||
                 (UserSymbolButton(button3) && NoTextButton(button5) && UserSymbolButton(button7)) ||
                 (UserSymbolButton(button4) && NoTextButton(button5) && UserSymbolButton(button6)) ||
                 (UserSymbolButton(button2) && NoTextButton(button5) && UserSymbolButton(button8))
                )
            {
                ChangeButtonProperties(button5);
                return true;
            }
            else if (
                 (UserSymbolButton(button4) && UserSymbolButton(button5) && NoTextButton(button6)) ||
                 (UserSymbolButton(button3) && NoTextButton(button6) && UserSymbolButton(button9))
                )
            {
                ChangeButtonProperties(button6);
                return true;
            }
            else if (
                 (UserSymbolButton(button3) && UserSymbolButton(button5) && NoTextButton(button7)) ||
                 (NoTextButton(button7) && UserSymbolButton(button8) && UserSymbolButton(button9)) ||
                 (UserSymbolButton(button1) && UserSymbolButton(button4) && NoTextButton(button7))
                )
            {
                ChangeButtonProperties(button7);
                return true;
            }
            else if (
                 (UserSymbolButton(button7) && NoTextButton(button8) && UserSymbolButton(button9)) ||
                 (UserSymbolButton(button2) && UserSymbolButton(button5) && NoTextButton(button8))
                )
            {
                ChangeButtonProperties(button8);
                return true;
            }
            else if (
                (UserSymbolButton(button1) && UserSymbolButton(button5) && NoTextButton(button9)) ||
                (UserSymbolButton(button7) && UserSymbolButton(button8) && NoTextButton(button9)) ||
                (UserSymbolButton(button3) && UserSymbolButton(button6) && NoTextButton(button9))
               )
            {
                ChangeButtonProperties(button9);
                return true;
            }
            //No Win Prevented
            return false;
        }
        private void ResetButton(Button theButton)
        {
            theButton.Content = "";
            theButton.IsEnabled = true;
            theButton.Style = FindResource("TicTacButtonTheme") as Style;
        }
        private void ResetGame(object sender, RoutedEventArgs e)
        {
            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);
            firstTurn = true;
            secondTurn = true;
            thirdTurn = true;
            SetScoreboard();
            if (First == false)
            {
                ComputerMove();
                DisplayMessage($"Your Move :)");
            }
            else
            {
                DisplayMessage($"{UserName} You're First!");
            }
        }
        private void SetScoreboard()
        {
            WinsText.Text = GlobalData.Wins.ToString();
            LosesText.Text = GlobalData.Loses.ToString();
            TiesText.Text = GlobalData.CatScratches.ToString();
        }
        private bool UserSymbolButton(Button theButton) => theButton.Content.ToString() == UserSymbol;
        private void WinMove(Button winningButton, Button button2, Button button3)
        {
            ChangeButtonProperties(winningButton);
            HighlightButton(winningButton);
            HighlightButton(button2);
            HighlightButton(button3);
            DisplayMessage("Rip X.X");
            GlobalData.Loses += 1;
            LockAllTiles();
            SetScoreboard();
        }
    }
}

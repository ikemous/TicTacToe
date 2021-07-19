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
        private string UserSymbol = GlobalData.UserSymbol;
        private string ComputerSymbol = GlobalData.ComputerSymbol;
        private bool firstTurn = true, secondTurn = true, thirdTurn = true;
        private bool First = GlobalData.UserFirst;
        private bool computerWins = false;
        private bool userWins = false;

        public GameView()
        {
            InitializeComponent();

        }
        private bool UserSymbolButton(Button theButton) => theButton.Content.ToString() == UserSymbol;
        private bool NoTextButton(Button theButton) => theButton.Content.ToString() == "";
        private bool PreventWin()
        {
            //Diag 1 (1, 5, 9)
            if (UserSymbolButton(button1) && UserSymbolButton(button5) && NoTextButton(button9))// User clicked 1 and 5, computer move on 9
            {
                ChangeButtonProperties(button9);
                return true;
            }
            else if (NoTextButton(button1) && UserSymbolButton(button5) && UserSymbolButton(button9)) //User clicked on 5 and 9, computer move on 1
            {
                ChangeButtonProperties(button1);
                return true;
            }
            else if (UserSymbolButton(button1) && NoTextButton(button5) && UserSymbolButton(button9))//User clicked on 1 and 9, computer move on 5
            {
                ChangeButtonProperties(button5);
                return true;
            }
            //Diag 2 (3, 5, 7)
            else if (UserSymbolButton(button3) && UserSymbolButton(button5) && NoTextButton(button7))//User clicked on button 3 and 5, computer move on 7
            {
                ChangeButtonProperties(button7);
                return true;
            }
            else if (NoTextButton(button3) && UserSymbolButton(button5) && UserSymbolButton(button7))//User clicked on buttons 5 and 7, computer move on 3
            {
                ChangeButtonProperties(button3);
                return true;
            }
            else if (UserSymbolButton(button3) && NoTextButton(button5) && UserSymbolButton(button7))//User clicked on buttons 3 and 7, computer move on 5
            {
                ChangeButtonProperties(button5);
                return true;
            }
            //Horizontal 1 (1, 2, 3)
            else if (UserSymbolButton(button1) && UserSymbolButton(button2) && NoTextButton(button3))//User clicked on buttons 1 and 2, computer move on 3
            {
                ChangeButtonProperties(button3);
                return true;
            }
            else if (NoTextButton(button1) && UserSymbolButton(button2) && UserSymbolButton(button3))//User clicked on buttons 2 and 3, computer move on 1
            {
                ChangeButtonProperties(button1);
                return true;
            }
            else if (UserSymbolButton(button1) && NoTextButton(button2) && UserSymbolButton(button3))//User clicked on buttons 1 and 3, computer move on 2
            {
                ChangeButtonProperties(button2);
                return true;
            }
            //Horizontal 2 (4, 5, 6)
            else if (UserSymbolButton(button4) && UserSymbolButton(button5) && NoTextButton(button6))//User clicked on buttons 4 and 5, computer move on 6
            {
                ChangeButtonProperties(button6);
                return true;
            }
            else if (NoTextButton(button4) && UserSymbolButton(button5) && UserSymbolButton(button6))//User clicked on buttons 5 and 6, computer move on 4
            {
                ChangeButtonProperties(button4);
                return true;
            }
            else if (UserSymbolButton(button4) && NoTextButton(button5) && UserSymbolButton(button6))//User clicked on buttons 4 and 6, computer moved on 5
            {
                ChangeButtonProperties(button5);
                return true;
            }
            //Horizontal 3 (7, 8, 9)
            else if (UserSymbolButton(button7) && UserSymbolButton(button8) && NoTextButton(button9))//User clicked on 7 and 8, computer move on 9
            {
                ChangeButtonProperties(button9);
                return true;
            }
            else if (NoTextButton(button7) && UserSymbolButton(button8) && UserSymbolButton(button9))//User clicked on buttons 8 and 9, computer move on 7
            {
                ChangeButtonProperties(button7);
                return true;
            }
            else if (UserSymbolButton(button7) && NoTextButton(button8) && UserSymbolButton(button9))//User clicked on buttons 7 and 9, computer move on 8
            {
                ChangeButtonProperties(button8);
                return true;
            }
            //Vertical 1 (1, 4, 7)
            if (UserSymbolButton(button1) && UserSymbolButton(button4) && NoTextButton(button7))//User clicked on buttons 1 and 4, computer move on 7
            {
                ChangeButtonProperties(button7);
                return true;
            }
            else if (NoTextButton(button1) && UserSymbolButton(button4) && UserSymbolButton(button7))//User clicked on buttons 4 and 7, computer move on 1
            {
                ChangeButtonProperties(button1);
                return true;
            }
            else if (UserSymbolButton(button1) && NoTextButton(button4) && UserSymbolButton(button7))//User clicked on buttons 1 and 7, computer move on 4
            {
                ChangeButtonProperties(button4);
                return true;
            }
            //Vertical 2 (2, 5, 8)
            if (UserSymbolButton(button2) && UserSymbolButton(button5) && NoTextButton(button8))//User clicked on buttons 2 and 5, computer move on 8
            {
                ChangeButtonProperties(button8);
                return true;
            }
            else if (NoTextButton(button2) && UserSymbolButton(button5) && UserSymbolButton(button8))//User clicked on buttons 5 and 8, computer move on 2
            {
                ChangeButtonProperties(button2);
                return true;
            }
            else if (UserSymbolButton(button2) && NoTextButton(button5) && UserSymbolButton(button8))//User clicked on buttons 2 and 8, computer move on 5
            {
                ChangeButtonProperties(button5);
                return true;
            }
            //Vertical 3 (3, 6, 9)
            if (UserSymbolButton(button3) && UserSymbolButton(button6) && NoTextButton(button9))//User clicked on buttons 3 and 6, computer move on 9
            {
                ChangeButtonProperties(button9);
                return true;
            }
            else if (NoTextButton(button3) && UserSymbolButton(button6) && UserSymbolButton(button9))//User clicked on buttons 6 and 9, computer move on button 3
            {
                ChangeButtonProperties(button3);
                return true;
            }
            else if (UserSymbolButton(button3) && NoTextButton(button6) && UserSymbolButton(button9))//User clicked on buttons 3 and 9, computer move on button 6
            {
                ChangeButtonProperties(button6);
                return true;
            }
            //No Win Prevented
            return false;
        }
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
        private void ComputerMove()
        {
            //Check the first turn
            if (firstTurn == true)
            {
                if (UserSymbolButton(button5))
                {
                    ChangeButtonProperties(button1);
                }
                else
                {
                    ChangeButtonProperties(button5);
                }
                firstTurn = false;
                return;
            }
            //Second Turn
            if (secondTurn == true)
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
                else
                {
                    if (PreventWin() == false)
                    {
                        DefaultMoves();
                    }
                }
                secondTurn = false;
                return;
            }
        }
        private void ChangeButtonProperties(Button theButton, bool userTurn = false, string log = "")
        {
            if (userTurn)
            {
                theButton.Content = UserSymbol;
            }
            else
            {
                theButton.Content = ComputerSymbol;
            }
            theButton.IsEnabled = false;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            clickedButton.Content = UserSymbol.ToString();
            HighlightButton(clickedButton);
            ComputerMove();
        }
        private void ResetButton(Button theButton)
        {
            theButton.Content = "";
            theButton.IsEnabled = true;
            theButton.Background = Brushes.White;
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
            computerWins = false;
            userWins = false;
            /*
            if (First == false)
            {
                computerMove();
            }
            else
            {
                label1.Text = $"Hello {Username}, You're First!";
            }*/
        }

        private void HighlightButton(Button theButton)
        {
            theButton.Background = Brushes.Red;
        }

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
    }
}

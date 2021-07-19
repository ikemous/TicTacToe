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
        private bool ButtonEqualsUserSymbol(Button theButton) => theButton.Content.ToString() == UserSymbol;
        private bool ButtonEqualsNoText(Button theButton) => theButton.Content.ToString() == "";
        private bool PreventWin()
        {
            //Diag 1 (1, 5, 9)
            if (ButtonEqualsUserSymbol(button1) && ButtonEqualsUserSymbol(button5) && ButtonEqualsNoText(button9))// User clicked 1 and 5, computer move on 9
            {
                ChangeButtonProperties(button9);
                return true;
            }
            else if (ButtonEqualsNoText(button1) && ButtonEqualsUserSymbol(button5) && ButtonEqualsUserSymbol(button9)) //User clicked on 5 and 9, computer move on 1
            {
                ChangeButtonProperties(button1);
                return true;
            }
            else if (ButtonEqualsUserSymbol(button1) && ButtonEqualsNoText(button5) && ButtonEqualsUserSymbol(button9))//User clicked on 1 and 9, computer move on 5
            {
                ChangeButtonProperties(button5);
                return true;
            }
            //Diag 2 (3, 5, 7)
            else if (ButtonEqualsUserSymbol(button3) && ButtonEqualsUserSymbol(button5) && ButtonEqualsNoText(button7))//User clicked on button 3 and 5, computer move on 7
            {
                ChangeButtonProperties(button7);
                return true;
            }
            else if (ButtonEqualsNoText(button3) && ButtonEqualsUserSymbol(button5) && ButtonEqualsUserSymbol(button7))//User clicked on buttons 5 and 7, computer move on 3
            {
                ChangeButtonProperties(button3);
                return true;
            }
            else if (ButtonEqualsUserSymbol(button3) && ButtonEqualsNoText(button5) && ButtonEqualsUserSymbol(button7))//User clicked on buttons 3 and 7, computer move on 5
            {
                ChangeButtonProperties(button5);
                return true;
            }
            //Horizontal 1 (1, 2, 3)
            else if (ButtonEqualsUserSymbol(button1) && ButtonEqualsUserSymbol(button2) && ButtonEqualsNoText(button3))//User clicked on buttons 1 and 2, computer move on 3
            {
                ChangeButtonProperties(button3);
                return true;
            }
            else if (ButtonEqualsNoText(button1) && ButtonEqualsUserSymbol(button2) && ButtonEqualsUserSymbol(button3))//User clicked on buttons 2 and 3, computer move on 1
            {
                ChangeButtonProperties(button1);
                return true;
            }
            else if (ButtonEqualsUserSymbol(button1) && ButtonEqualsNoText(button2) && ButtonEqualsUserSymbol(button3))//User clicked on buttons 1 and 3, computer move on 2
            {
                ChangeButtonProperties(button2);
                return true;
            }
            //Horizontal 2 (4, 5, 6)
            else if (ButtonEqualsUserSymbol(button4) && ButtonEqualsUserSymbol(button5) && ButtonEqualsNoText(button6))//User clicked on buttons 4 and 5, computer move on 6
            {
                ChangeButtonProperties(button6);
                return true;
            }
            else if (ButtonEqualsNoText(button4) && ButtonEqualsUserSymbol(button5) && ButtonEqualsUserSymbol(button6))//User clicked on buttons 5 and 6, computer move on 4
            {
                ChangeButtonProperties(button4);
                return true;
            }
            else if (ButtonEqualsUserSymbol(button4) && ButtonEqualsNoText(button5) && ButtonEqualsUserSymbol(button6))//User clicked on buttons 4 and 6, computer moved on 5
            {
                ChangeButtonProperties(button5);
                return true;
            }

            //No Win Prevented
            return false;
        }

        private void ComputerMove()
        {
            //Check the first turn
            if (firstTurn == true)
            {
                if (ButtonEqualsUserSymbol(button5))
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

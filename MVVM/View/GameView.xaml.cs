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
        private bool ButtonEqualsUserSymbol(Button theButton) => theButton.Content.ToString() == UserSymbol ? true : false;
        private bool PreventWin()
        {
            //Diag 1 (1, 5, 9)
            if (ButtonEqualsUserSymbol(button1) && button5.Content.ToString() == UserSymbol && button9.Content.ToString() == "")// User clicked 1 and 5, computer move on 9
            {
                ChangeButtonProperties(button9);
                return true;
            }
            else if (button1.Content.ToString() == "" && button5.Content.ToString() == UserSymbol && button9.Content.ToString() == UserSymbol) //User clicked on 5 and 9, computer move on 1
            {
                ChangeButtonProperties(button1);
                return true;
            }
            else if (button1.Content.ToString() == UserSymbol && button5.Content.ToString() == "" && button9.Content.ToString() == UserSymbol)//User clicked on 1 and 9, computer move on 5
            {
                ChangeButtonProperties(button5);
                return true;
            }
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

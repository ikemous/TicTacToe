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

        private void ComputerMove()
        {
            //Check the first turn
            if (firstTurn == true)
            {
                if (button5.Content == UserSymbol)
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

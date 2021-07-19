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

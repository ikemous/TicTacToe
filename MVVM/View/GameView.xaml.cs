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

    }
}

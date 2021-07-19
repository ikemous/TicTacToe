using System;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.Core;

namespace TicTacToe.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
        }
        private void HandleXClick(object sender, RoutedEventArgs e)
        {
            GlobalData.UserSymbol = "X";
            GlobalData.ComputerSymbol = "O";
        }
        private void HandleOClick(object sender, RoutedEventArgs e)
        {
            GlobalData.UserSymbol = "O";
            GlobalData.ComputerSymbol = "Y";
        }
        private void HandlePlacementClick(object sender, RoutedEventArgs e)
        {
            GlobalData.UserFirst = !GlobalData.UserFirst;
        }

        private void HandleTextBoxChange(object sender, TextChangedEventArgs e)
        {

        }
    }
}

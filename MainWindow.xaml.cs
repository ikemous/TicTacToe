using System;
using System.Windows;
using TicTacToe.Core;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            StartButton.Visibility = Visibility.Collapsed;
        }
        private void MainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            if(StartButton.Visibility == Visibility.Collapsed)
            {
                StartButton.Visibility = Visibility.Visible;
            }
        }
    }
}

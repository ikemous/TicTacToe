using System;
using System.Windows;
using System.Windows.Input;
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
        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
        private void MinimizeWindow(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
    }
}

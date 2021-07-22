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
        /*
            HandleXClick()
            Purpose: Handle the X Symbol Radio Button by changing user
                    Prefernce to X
            Parameters:
                object sender - sender of the function action
                RoutedEventArgs e - Event object for the click
            Returns: None
         */
        private void HandleXClick(object sender, RoutedEventArgs e)
        {
            GlobalData.UserSymbol = "X";
            GlobalData.ComputerSymbol = "O";
        }
        /*
            HandleXClick()
            Purpose: Handle the O Symbol Radio  by Changing the User
                    Prefernce to Y
            Parameters:
                object sender - sender of the function action
                RoutedEventArgs e - Event object for the click
            Returns: None
         */
        private void HandleOClick(object sender, RoutedEventArgs e)
        {
            GlobalData.UserSymbol = "O";
            GlobalData.ComputerSymbol = "X";
        }
        /*
            HandleTextChange()
            Purpose: Update the Username Value on textbox change
            Parameters:
                object sender - sender of the function action
                TextChangedEventArgs e - Event object for the text change
            Returns: None
         */
        private void HandleTextChange(object sender, TextChangedEventArgs e) => GlobalData.UserName = UserNameTextBox.Text;
        /*
            HandlePlayerRadioClick()
            Purpose: Indicates that the user is first to go
            Parameters:
                object sender - sender of the function action
                RoutedEventArgs e - Event object for the click
            Returns: None
         */
        private void HandlePlayerRadioClick(object sender, RoutedEventArgs e) => GlobalData.UserFirst = true;
        /*
            HandleXClick()
            Purpose: Indicates that the computer is first to go
            Parameters:
                object sender - sender of the function action
                RoutedEventArgs e - Event object for the click
            Returns: None
         */
        private void HandleComptuerRadioClick(object sender, RoutedEventArgs e) => GlobalData.UserFirst = false;
    }
}

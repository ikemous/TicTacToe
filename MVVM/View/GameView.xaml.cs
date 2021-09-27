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
        #region variables
        //Symbols used thruogh the game
        private readonly string UserSymbol = GlobalData.UserSymbol, ComputerSymbol = GlobalData.ComputerSymbol, UserName = GlobalData.UserName;
        //Bools to run the first three turns of the game
        private bool firstTurn = true, secondTurn = true, thirdTurn = true;
        //Bool to determine who goes first
        private readonly bool First = GlobalData.UserFirst;
        #endregion variables
        public GameView()
        {
            InitializeComponent();
            SetScoreboard();
            if (First == false)
            {
                ComputerMove();
                DisplayMessage($"Your Move :)");
            }
            else
            {
                DisplayMessage($"{UserName} You're First!");
            }
        }
        /*
            ButtonClick()
            Purpose: Click event on the tic tac toe buttons
            Parameters:
                object sender, RoutedEventArgs e - Standard button click requirements
            Returns: None
        */
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            //Change Properties for the button that was cliked
            ChangeButtonProperties(sender as Button, true);
            //Initiate the computer move
            ComputerMove();
        }
        /*
            ButtonIsClicked()
            Purpose: Check if the button is clicked
            Parameters:
                Button theButton - Button that was clicked
            Returns: 
                true - Button has content inside it
                false - Button content is empty
        */
        private bool ButtonIsClicked(Button theButton) => theButton.Content.ToString() != "";
        /*
            ChangeButtonProperties()
            Purpose: Change the properties of the button
            Parameters:
                Button theButton - Button that will have its properties changed
                bool userTurn - determine if buttons properties need to match the users symbol(Default True)
            Returns: None
        */
        private void ChangeButtonProperties(Button theButton, bool userTurn = false)
        {
            //Change content to symbol
            theButton.Content = userTurn ? UserSymbol : ComputerSymbol;
            //Disable Button
            theButton.IsEnabled = false;
        }
        /*
            CatScratch()
            Purpose: Check if the game is at a tie
            Parameters: None
            Returns: None
        */
        private void CatScratch()
        {
            //Check if all buttons are clicked
            if (ButtonIsClicked(button1) && ButtonIsClicked(button2) &&
                ButtonIsClicked(button3) && ButtonIsClicked(button4) &&
                ButtonIsClicked(button5) && ButtonIsClicked(button6) &&
                ButtonIsClicked(button7) && ButtonIsClicked(button8) &&
                ButtonIsClicked(button9))
            {
                //Display a cat scratch message
                DisplayMessage("Cat Scratch!");
                //Increase Tie Count
                GlobalData.CatScratches += 1;
                //UpdateScoreboard
                SetScoreboard();
            }
            //Not a tie
            else
            {
                //Empty Message
                DisplayMessage("");
            }
        }
        /*
            ComputerMove()
            Purpose: Have the computer select a box
            Parameters: None
            Returns: None
        */
        private void ComputerMove()
        {
            //Check the first turn
            if (firstTurn)
            {
                //Button 5 is clicked
                if (UserSymbolButton(button5))
                {
                    //Computer Move at button1
                    ChangeButtonProperties(button1);
                }
                //Any other button is clicked
                else
                {
                    //Computer Move at button5
                    ChangeButtonProperties(button5);
                }
                //Check if the user is first
                if (First)
                {
                    //Display Great Choice message
                    DisplayMessage("Great Choice!");
                }
                //Computer is first
                else
                {
                    //Display Good luck message
                    DisplayMessage("Good Luck!");
                }
                //Make first turn is over
                firstTurn = false;
                //Return to prevent any other moves
                return;
            }
            //Second Turn
            if (secondTurn)
            {
                //Check if button1 and button6 are clicked
                if (UserSymbolButton(button1) && UserSymbolButton(button6))
                {
                    //Computer Move on button3
                    ChangeButtonProperties(button3);
                }
                //Check if button1 and button8 are clicked
                else if (UserSymbolButton(button1) && UserSymbolButton(button8))
                {
                    //Computer move on button4
                    ChangeButtonProperties(button4);
                }
                //Check if button1 and button9 are clicked
                else if (UserSymbolButton(button1) && UserSymbolButton(button9))
                {
                    //Computer move on button4
                    ChangeButtonProperties(button4);
                }
                //Check if button2 and button9 are clicked
                else if (UserSymbolButton(button2) && UserSymbolButton(button9))
                {
                    //Move on button3
                    ChangeButtonProperties(button3);
                }
                //Check if button3 and button7 are clicked
                else if (UserSymbolButton(button3) && UserSymbolButton(button7))
                {
                    //Move on button4
                    ChangeButtonProperties(button4);
                }
                //Check if button5 and button9 are clicked
                else if (UserSymbolButton(button5) && UserSymbolButton(button9))
                {
                    //Computer move on button3
                    ChangeButtonProperties(button3);
                }
                //Check if button 8 and button3 are clicked
                else if (UserSymbolButton(button8) && UserSymbolButton(button3))
                {
                    //Computer move on button6
                    ChangeButtonProperties(button6);
                }
                //Check if button8 and button6 are clicked
                else if (UserSymbolButton(button8) && UserSymbolButton(button6))
                {
                    //Computer move on button9
                    ChangeButtonProperties(button9);
                }
                //Check if button6 and button7 are clicked
                else if(UserSymbolButton(button6) && UserSymbolButton(button7))
                {
                    //Computer move on button8
                    ChangeButtonProperties(button8);
                }
                //Prevent win or move to the next default
                else
                {
                    //Computer didnt prevent win
                    if (PreventWin() == false)
                    {
                        //Take next available spot
                        DefaultMoves();
                    }
                }
                //Display Tauting message
                DisplayMessage("OOPSIE! I see it! ;)");
                //Indicate that second turn is Over
                secondTurn = false;
                //Return to avoid going into the other code
                return;
            }
            //Check if its the third turn
            if (thirdTurn)
            {
                //Check if computer can win
                if (MoveForWin() == false)
                {
                    //Check if button1 and button3 are clicked and button4 isn't taken
                    if (UserSymbolButton(button1) && UserSymbolButton(button3) && !UserSymbolButton(button4))
                    {
                        //Computer Move on button 4
                        ChangeButtonProperties(button4);
                    }
                    //Check if button1 and button6 and button8 are clicked
                    else if (UserSymbolButton(button1) && UserSymbolButton(button6) && UserSymbolButton(button8))
                    {
                        //Computer move on button3
                        ChangeButtonProperties(button3);
                    }
                    //Check if button1 and button8 are taken by the user. Also check if button2 and button5 are Taken by the computer
                    else if (UserSymbolButton(button1) && UserSymbolButton(button8) && ComputerSymbolButton(button2) && ComputerSymbolButton(button5))
                    {
                        //Computer Move on Button4
                        ChangeButtonProperties(button4);
                    }
                    //No special cases move to prevent win
                    else
                    {
                        //Computer cant prevent win
                        if (PreventWin() == false)
                        {
                            //Move to next open spot
                            DefaultMoves();
                        }
                    }
                    //Display Taunting Message
                    DisplayMessage("Keep Trying!");
                }
                //Indicate end of Thrid Turn
                thirdTurn = false;
                //Return to avoid the next lines of code
                return;
            }
            //Computer Cant Win
            if (MoveForWin() == false)
            {
                //No way to prevent the win
                if (PreventWin() == false)
                {
                    //Move to next available spot
                    DefaultMoves();
                    //Check for Tie
                    CatScratch();
                }
            }
        }
        /*
            ComputerSymbolButton()
            Purpose: Check if the button is taken by the computer
            Parameters:
                Button theButton - Button that is being checked
            Returns: 
                true - Button is taken by the computer
                false - Button isn't Taken by the computer
        */
        private bool ComputerSymbolButton(Button theButton) => theButton.Content.ToString() == ComputerSymbol;
        /*
            DefaultMoves()
            Purpose: Move to the next available slot
            Parameters: None
            Returns: None
        */
        private void DefaultMoves()
        {
            //No Other moves, move to the next button
            if (NoTextButton(button1)) ChangeButtonProperties(button1); //Computer Move To Button1
            else if (NoTextButton(button2)) ChangeButtonProperties(button2); //Computer Move To Button2
            else if (NoTextButton(button3)) ChangeButtonProperties(button3);//computer Move To Button3
            else if (NoTextButton(button4)) ChangeButtonProperties(button4);//Computer Move to Button4
            else if (NoTextButton(button5)) ChangeButtonProperties(button5);//Computer Move To Button5
            else if (NoTextButton(button6)) ChangeButtonProperties(button6);//Computer Move to Button6
            else if (NoTextButton(button7)) ChangeButtonProperties(button7);//Computer Move To Button7
            else if (NoTextButton(button8)) ChangeButtonProperties(button8);//Computer Move To Button8
            else if (NoTextButton(button9)) ChangeButtonProperties(button9);//Computer Move To Button9
        }
        /*
            DisplayGame()
            Purpose: Replace the message TextBlock to the parameter value
            Parameters:
                string Message - message to be displayed
            Returns: None
        */
        private void DisplayMessage(string message) => MessageBlock.Text = message;
        /*
            HighlightButton()
            Purpose: Highlight the button to red
            Parameters:
                Button theButton - button to be highlighted
            Returns: None
        */
        private void HighlightButton(Button theButton) => theButton.Style = FindResource("TicTacButtonRedTheme") as Style;
        /*
            LockAllTiles()
            Purpose: Lock every tile of the game
            Parameters: None
            Returns: None
        */
        private void LockAllTiles()
        {
            button1.IsEnabled = false;//Lock Button1
            button2.IsEnabled = false;//Lock Button2
            button3.IsEnabled = false;//Lock Button3
            button4.IsEnabled = false;//Lock Button4
            button5.IsEnabled = false;//Lock Button5
            button6.IsEnabled = false;//Lock Button6
            button7.IsEnabled = false;//Lock Button7
            button8.IsEnabled = false;//Lock Button8
            button9.IsEnabled = false;//Lock Button9
        }
        /*
            MoveForWin()
            Purpose: Check for a win and move to win if possible
            Parameters: None
            Returns: 
                true - Computer Has moved and won
                false - No win Conditions
        */
        private bool MoveForWin()
        {
            //Diag (1, 5, 9)
            if (ComputerSymbolButton(button1) && ComputerSymbolButton(button5) && NoTextButton(button9)) // Computer already filled 1 and 5, computer move on 9
            {
                //Computer wins
                WinMove(button9, button1, button5);
                return true;
            }
            else if (NoTextButton(button1) && ComputerSymbolButton(button5) && ComputerSymbolButton(button9)) //Computer filled on 5 and 9, computer move on 1
            {
                //Computer wins
                WinMove(button1, button5, button9);
                return true;
            }
            else if (ComputerSymbolButton(button1) && NoTextButton(button5) && ComputerSymbolButton(button9)) //Computer filled on 1 and 9, computer move on 5
            {
                //Computer wins
                WinMove(button5, button1, button9);
                return true;
            }
            //Diag 2 (3, 5, 7)
            else if (ComputerSymbolButton(button3) && ComputerSymbolButton(button5) && NoTextButton(button7)) //Computer filled on button 3 and 5, computer move on 7
            {
                //Computer wins
                WinMove(button7, button3, button5);
                return true;
            }
            else if (NoTextButton(button3) && ComputerSymbolButton(button5) && ComputerSymbolButton(button7)) //Computer filled on buttons 5 and 7, computer move on 3 
            {
                //Computer wins
                WinMove(button3, button5, button7);
                return true;
            }
            else if (ComputerSymbolButton(button3) && NoTextButton(button5) && ComputerSymbolButton(button7)) //Computer fille on buttons 3 and 7, computer move on 5
            {
                //Computer wins
                WinMove(button5, button3, button7);
                return true;
            }
            //Horizontal 1 (1, 2, 3)
            else if (ComputerSymbolButton(button1) && ComputerSymbolButton(button2) && NoTextButton(button3)) //Computer filled on buttons 1 and 2, computer move on 3
            {
                //Computer wins
                WinMove(button3, button1, button2);
                return true;
            }
            else if (NoTextButton(button1) && ComputerSymbolButton(button2) && ComputerSymbolButton(button3)) //Computer filled on buttons 2 and 3, computer move on 1
            {
                //Computer wins
                WinMove(button1, button2, button3);
                return true;
            }
            else if (ComputerSymbolButton(button1) && NoTextButton(button2) && ComputerSymbolButton(button3)) //Computer filled on buttons 1 and 3, computer move on 2
            {
                //Computer wins
                WinMove(button2, button1, button3);
                return true;
            }
            //Horizontal 2 (4, 5, 6)
            else if (ComputerSymbolButton(button4) && ComputerSymbolButton(button5) && NoTextButton(button6)) //Computer filled on buttons 4 and 5, computer move on 6
            {
                //Computer wins
                WinMove(button6, button4, button5);
                return true;
            }
            else if (NoTextButton(button4) && ComputerSymbolButton(button5) && ComputerSymbolButton(button6))//Computer filled on buttons 5 and 6, computer move on 4
            {
                //Computer wins
                WinMove(button4, button5, button6);
                return true;
            }
            else if (ComputerSymbolButton(button4) && NoTextButton(button5) && ComputerSymbolButton(button6))//Computer filled on buttons 4 and 6, computer moved on 5
            {
                //Computer wins
                WinMove(button5, button4, button6);
                return true;
            }
            //Horizontal 3 (7, 8, 9)
            else if (ComputerSymbolButton(button7) && ComputerSymbolButton(button8) && NoTextButton(button9)) //Computeer filled on 7 and 8, computer move on 9
            {
                //Computer wins
                WinMove(button9, button7, button8);
                return true;
            }
            else if (NoTextButton(button7) && ComputerSymbolButton(button8) && ComputerSymbolButton(button9))//Computer filled on buttons 8 and 9, computer move on 7
            {
                //Computer wins
                WinMove(button7, button8, button9);
                return true;
            }
            else if (ComputerSymbolButton(button7) && NoTextButton(button8) && ComputerSymbolButton(button9))//Computer filled on buttons 7 and 9, computer move on 8
            {
                //Computer wins
                WinMove(button8, button7, button9);
                return true;
            }
            //Vertical 1 (1, 4, 7)
            else if (ComputerSymbolButton(button1) && ComputerSymbolButton(button4) && NoTextButton(button7))//Computer filled on buttons 1 and 4, computer move on 7
            {
                //Computer wins
                WinMove(button7, button1, button4);
                return true;
            }
            else if (NoTextButton(button1) && ComputerSymbolButton(button4) && ComputerSymbolButton(button7))//computer filled on buttons 4 and 7, computer move on 1
            {
                //Computer wins
                WinMove(button1, button4, button7);
                return true;
            }
            else if (ComputerSymbolButton(button1) && NoTextButton(button4) && ComputerSymbolButton(button7))//Computer filled on buttons 1 and 7, computer move on 4
            {
                //Computer wins
                WinMove(button4, button1, button7);
                return true;
            }
            //Vertical 2 (2, 5, 8)
            else if (ComputerSymbolButton(button2) && ComputerSymbolButton(button5) && NoTextButton(button8))//Computer filled on buttons 2 and 5, computer move on 8
            {
                //Computer wins
                WinMove(button8, button2, button5);
                return true;
            }
            else if (NoTextButton(button2) && ComputerSymbolButton(button5) && ComputerSymbolButton(button8))//Computer filled on buttons 5 and 8, computer move on 2
            {
                //Computer wins
                WinMove(button2, button5, button8);
                return true;
            }
            else if (ComputerSymbolButton(button2) && NoTextButton(button5) && ComputerSymbolButton(button8))//Computer filled on buttons 2 and 8, computer move on 5
            {
                //Computer wins
                WinMove(button5, button2, button8);
                return true;
            }
            //Vertical 3 (3, 6, 9)
            else if (ComputerSymbolButton(button3) && ComputerSymbolButton(button6) && NoTextButton(button9))//Computer filled on buttons 3 and 6, computer move on 9
            {
                //Computer wins
                WinMove(button9, button3, button6);
                return true;
            }
            else if (NoTextButton(button3) && ComputerSymbolButton(button6) && ComputerSymbolButton(button9))//Computer filled on buttons 6 and 9, computer move on button 3
            {
                //Computer wins
                WinMove(button3, button6, button9);
                return true;
            }
            else if (ComputerSymbolButton(button3) && NoTextButton(button6) && ComputerSymbolButton(button9))//Computer filled on buttons 3 and 9, computer move on button 6
            {
                //Computer wins
                WinMove(button6, button3, button9);
                return true;
            }
            return false;
        }
        /*
            NoTextButton()
            Purpose: Check if the button has no text
            Parameters: 
                Button theButton - Button to check if there is content
            Returns: 
                true - Button has no text
                false - Button has text
        */
        private bool NoTextButton(Button theButton) => theButton.Content.ToString() == "";
        /*
            PreventWin()
            Purpose: Prevent the win of the user
            Parameters: None
            Returns: 
                true - Computer Prevented the win
                false - No Win To Prevent
        */
        private bool PreventWin()
        {
            //Move to button1 to prevent win
            if (
                 (NoTextButton(button1) && UserSymbolButton(button5) && UserSymbolButton(button9)) ||
                 (NoTextButton(button1) && UserSymbolButton(button2) && UserSymbolButton(button3)) ||
                 (NoTextButton(button1) && UserSymbolButton(button4) && UserSymbolButton(button7))
               )
            {
                ChangeButtonProperties(button1);
                return true;
            }
            //Move to button2 to prevent win
            else if (
                 (UserSymbolButton(button1) && NoTextButton(button2) && UserSymbolButton(button3)) ||
                 (NoTextButton(button2) && UserSymbolButton(button5) && UserSymbolButton(button8)) ||
                 (NoTextButton(button2) && UserSymbolButton(button5) && UserSymbolButton(button8))
                )
            {
                ChangeButtonProperties(button2);
                return true;
            }
            //Move to button3 to prevent win
            else if (
                 (NoTextButton(button3) && UserSymbolButton(button5) && UserSymbolButton(button7)) ||
                 (UserSymbolButton(button1) && UserSymbolButton(button2) && NoTextButton(button3)) ||
                 (NoTextButton(button3) && UserSymbolButton(button6) && UserSymbolButton(button9))
                )
            {
                ChangeButtonProperties(button3);
                return true;
            }
            //Move to button4 to prevent win
            else if (
                  (NoTextButton(button4) && UserSymbolButton(button5) && UserSymbolButton(button6)) || 
                  (UserSymbolButton(button1) && NoTextButton(button4) && UserSymbolButton(button7))
                )
            {
                ChangeButtonProperties(button4);
                return true;
            }
            //Move to button5 to prevent win
            else if (
                 (UserSymbolButton(button1) && NoTextButton(button5) && UserSymbolButton(button9)) ||
                 (UserSymbolButton(button3) && NoTextButton(button5) && UserSymbolButton(button7)) ||
                 (UserSymbolButton(button4) && NoTextButton(button5) && UserSymbolButton(button6)) ||
                 (UserSymbolButton(button2) && NoTextButton(button5) && UserSymbolButton(button8))
                )
            {
                ChangeButtonProperties(button5);
                return true;
            }
            //Move to button6 to prevent win
            else if (
                 (UserSymbolButton(button4) && UserSymbolButton(button5) && NoTextButton(button6)) ||
                 (UserSymbolButton(button3) && NoTextButton(button6) && UserSymbolButton(button9))
                )
            {
                ChangeButtonProperties(button6);
                return true;
            }
            //Move to button7 to prevent win
            else if (
                 (UserSymbolButton(button3) && UserSymbolButton(button5) && NoTextButton(button7)) ||
                 (NoTextButton(button7) && UserSymbolButton(button8) && UserSymbolButton(button9)) ||
                 (UserSymbolButton(button1) && UserSymbolButton(button4) && NoTextButton(button7))
                )
            {
                ChangeButtonProperties(button7);
                return true;
            }
            //Move to button8 to prevent win
            else if (
                 (UserSymbolButton(button7) && NoTextButton(button8) && UserSymbolButton(button9)) ||
                 (UserSymbolButton(button2) && UserSymbolButton(button5) && NoTextButton(button8))
                )
            {
                ChangeButtonProperties(button8);
                return true;
            }
            //Move to button9 to prevent win
            else if (
                (UserSymbolButton(button1) && UserSymbolButton(button5) && NoTextButton(button9)) ||
                (UserSymbolButton(button7) && UserSymbolButton(button8) && NoTextButton(button9)) ||
                (UserSymbolButton(button3) && UserSymbolButton(button6) && NoTextButton(button9))
               )
            {
                ChangeButtonProperties(button9);
                return true;
            }
            //No Win Prevented
            return false;
        }
        /*
            ResetButton()
            Purpose: Reset the button that was given
            Parameters: 
                Button theButton - button to be reset
            Returns: None
        */
        private void ResetButton(Button theButton)
        {
            //Reset Text
            theButton.Content = "";
            //Enable the button
            theButton.IsEnabled = true;
            //Reset Style To Original Theme
            theButton.Style = FindResource("TicTacButtonTheme") as Style;
        }
        /*
            ResetGame()
            Purpose: Reset the whole game state
            Parameters: 
                object sender, RoutedEventArgs e - Required Parameters for a button click
            Returns: 
                true - Computer Prevented the win
                false - No Win To Prevent
        */
        private void ResetGame(object sender, RoutedEventArgs e)
        {
            //Reset all buttons
            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);
            //Reset Turns
            firstTurn = true;
            secondTurn = true;
            thirdTurn = true;
            //Update Scoreboard
            SetScoreboard();
            //User isn't first to go
            if (First == false)
            {
                //Computer Move
                ComputerMove();
                //Display Threatening message
                DisplayMessage($"Your Move :)");
            }
            //User is first to go
            else
            {
                //Display indicator telling the user to move
                DisplayMessage($"{UserName} You're First!");
            }
        }
        /*
            SetScoreboard()
            Purpose: Update the scoreboard the the most recent score
            Parameters: None
            Returns: None
        */
        private void SetScoreboard()
        {
            //Set Wins Text
            WinsText.Text = GlobalData.Wins.ToString();
            //set Loses Text
            LosesText.Text = GlobalData.Loses.ToString();
            //Set Ties Text
            TiesText.Text = GlobalData.CatScratches.ToString();
        }
        /*
            UserSymbolButton()
            Purpose: Check if the button is taken by the user
            Parameters: 
                Button theButton - is the button to be checked if it contains the userSymbol
            Returns: 
                true - Button is taken by the user
                false - Button isn't taken by the user
        */
        private bool UserSymbolButton(Button theButton) => theButton.Content.ToString() == UserSymbol;
        /*
            WinMove()
            Purpose: 
                Make the computer win the game
                highlight the winning buttons
                displaying taunting message
                Update loss count
            Parameters: 
                Button winningButton - button that needs its properties to change
                Button button2, button3 - Winning buttons to highlight
            Returns: 
                true - Computer Prevented the win
                false - No Win To Prevent
        */
        private void WinMove(Button winningButton, Button button2, Button button3)
        {
            //Change property of winning button
            ChangeButtonProperties(winningButton);
            //Highlight all buttons
            HighlightButton(winningButton);
            HighlightButton(button2);
            HighlightButton(button3);
            //Display message
            DisplayMessage("HAHA YOU LOSE! LOOOOOSER!!!");
            //Update loss
            GlobalData.Loses += 1;
            //Lock all tiles
            LockAllTiles();
            //Update Scoreboard
            SetScoreboard();
        }
    }
}

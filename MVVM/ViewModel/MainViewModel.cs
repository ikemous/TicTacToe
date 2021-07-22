using System;
using TicTacToe.Core;

namespace TicTacToe.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        // Create model and commands for the views
        public RelayCommand MainMenuViewCommand { get; set; }
        public MainMenuViewModel MainMenuVM { get; set; }
        public RelayCommand GameViewCommand { get; set; }
        public GameViewModel GameVM { get; set; }

        //Create object to control current views
        private object _currentView;

        //Get and set the private object for current views
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChange();
            }
        }
        public MainViewModel()
        {
            //Define the Views
            MainMenuVM = new MainMenuViewModel();
            GameVM = new GameViewModel();
            CurrentView = MainMenuVM;
            //MainViewCommand is sent, set current view
            MainMenuViewCommand = new RelayCommand(theObject =>
            {
                CurrentView = MainMenuVM;
            });

            //GameViewCommand is sent, set current view
            GameViewCommand = new RelayCommand(theObject =>
            {
                CurrentView = GameVM;
            });
        }
    }
}

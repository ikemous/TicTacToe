﻿using System;
using TicTacToe.Core;

namespace TicTacToe.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand MainMenuViewCommand { get; set; }
        public MainMenuViewModel MainMenuVM { get; set; }
        public RelayCommand GameViewCommand { get; set; }
        public GameViewModel GameVM { get; set; }


        private object _currentView;

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
            MainMenuVM = new MainMenuViewModel();
            GameVM = new GameViewModel();
            CurrentView = MainMenuVM;

            MainMenuViewCommand = new RelayCommand(theObject =>
            {
                CurrentView = MainMenuVM;
            });

            GameViewCommand = new RelayCommand(theObject =>
            {
                CurrentView = GameVM;
            });
        }
    }
}

using PumpYourBrain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpYourBrain.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand CountGameViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand ExitViewCommand { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ExersicesViewCommand { get; set; }
        public RelayCommand LeaderBoardViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public ExitViewModel ExitVM { get; set; }
        public ExersicesViewModel ExersicesVM { get; set; }
        public LeaderBoardViewModel LeaderBoardVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public CountGameViewModel CountGameVM { get; set; }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
            
        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
            ExersicesVM= new ExersicesViewModel();
            LeaderBoardVM = new LeaderBoardViewModel();
            SettingsVM = new SettingsViewModel();
            ExitVM = new ExitViewModel();
            CountGameVM = new CountGameViewModel();
            HomeViewCommand = new RelayCommand(o => { 
                CurrentView = HomeVM;
            });
            ExersicesViewCommand = new RelayCommand(o => {
                CurrentView = ExersicesVM;
            });
            LeaderBoardViewCommand = new RelayCommand(o => {
                CurrentView = LeaderBoardVM;
            });
            SettingsViewCommand = new RelayCommand(o => {
                CurrentView = SettingsVM;
            });
            ExitViewCommand = new RelayCommand(o => {
                CurrentView = ExitVM;
            });
            CountGameViewCommand = new RelayCommand(o => {
                CurrentView = CountGameVM;
            });
        }
    }
}

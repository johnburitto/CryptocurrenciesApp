using System.Windows;
using UserInterface.Core;

namespace UserInterface.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private object? _currentView;

        public object? CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public static MainViewModel? Instance { get; set; }
        public HomeViewModel HomeViewModel { get; set; }
        public SearchViewModel SearchViewModel { get; set; }
        public ConvertViewModel ConvertViewModel { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SearchViewCommand { get; set; }
        public RelayCommand ConvertViewCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }

        public MainViewModel()
        {
            HomeViewModel = new HomeViewModel();
            SearchViewModel = new SearchViewModel();
            ConvertViewModel = new ConvertViewModel();
            CurrentView = HomeViewModel;
            HomeViewCommand = new RelayCommand(_ =>
            {
                CurrentView = HomeViewModel;
            }, _ =>
            {
                return true;
            });
            SearchViewCommand = new RelayCommand(_ =>
            {
                CurrentView = SearchViewModel;
            }, _ =>
            {
                return true;
            });
            ConvertViewCommand = new RelayCommand(_ =>
            {
                CurrentView = ConvertViewModel;
            }, _ =>
            {
                return true;
            });
            ExitCommand = new RelayCommand(_ =>
            {
                Application.Current.MainWindow.Close();
            }, _ =>
            {
                return true;
            });
            Instance = this;
        }
    }
}

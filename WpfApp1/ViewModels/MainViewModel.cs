using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class MainViewModel: ObservableObject
    {
        private readonly NavigationService _navigationService;
        private readonly DialogService _dialogService;
        private readonly SettingsService _settingsService;

        public MainViewModel(NavigationService navigationService,DialogService dialogService, SettingsService settingsService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _settingsService = settingsService;

            NavigateHomeCommand = new RelayCommand(() =>
            {
                CurrentView = this._navigationService.GetViewModel<HomeViewModel>();
            }); 

            NavigateAboutCommand = new RelayCommand(() =>
            {
                CurrentView = this._navigationService.GetViewModel<AboutViewModel>();
            });

            NavigateTodoItemCommand = new RelayCommand(() =>
            {
                CurrentView = this._navigationService.GetViewModel<TodoItemViewModel>();
            });

            ShowDialogCommand = new RelayCommand(() => _dialogService.ShowMessage("Hello", "This is a custom dialog"));
            ToggleThemeCommand = new RelayCommand(SwitchTheme);
            LoadParentChildViewCommand = new RelayCommand(() =>
            {
                CurrentView= _navigationService.GetViewModel<ParentViewModel>();
            });

            CurrentView = _navigationService.GetViewModel<HomeViewModel>();
            ApplyTheme(_settingsService.Current.Theme);
        }

        private void SwitchTheme()
        {
            var newTheme = _settingsService.Current.Theme == "Light" ? "Dark" : "Light";
            _settingsService.Current.Theme = newTheme;
            _settingsService.Save();
            ApplyTheme(newTheme);
        }
        private void ApplyTheme(string themeName)
        {
            string path = $"Themes/{themeName}.xaml";
            var dict = new ResourceDictionary() { Source = new Uri(path, UriKind.Relative) };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        private object? _currentView=null;

        public object? CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public IRelayCommand NavigateHomeCommand { get; set; }
        public IRelayCommand NavigateAboutCommand { get; set; }
        public IRelayCommand NavigateTodoItemCommand { get; set; }
        public IRelayCommand ShowDialogCommand { get; }
        public IRelayCommand ToggleThemeCommand { get; }
        public IRelayCommand LoadParentChildViewCommand { get; }
    }
}

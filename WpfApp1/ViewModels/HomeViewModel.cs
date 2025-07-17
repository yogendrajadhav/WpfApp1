using CommunityToolkit.Mvvm.ComponentModel;
using WpfApp1.Services;

namespace WpfApp1.ViewModels;

public class HomeViewModel: ObservableObject
{
    private readonly DialogService _dialogService;

    public HomeViewModel(DialogService dialogService)
    {
        _dialogService = dialogService;
    }
      
    public string Message
    {
        get
        {
           // _dialogService.ShowMessage("Hello", "Welcome to the Home View!");
         //   bool result = _dialogService.Confirm("Are you sure?");
            return "Welcome to the Home View!";
        }
    }
}
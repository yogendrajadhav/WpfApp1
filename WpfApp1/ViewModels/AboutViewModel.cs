using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.ViewModels;

public class AboutViewModel: ObservableObject
{
    public string Message => "Welcome to the About View!";
}
using System.Windows;

namespace WpfApp1.Services;

public class DialogService
{
    public DialogService() 
    {
            
    }
    public void ShowMessage(string title, string message)
    {
        MessageBox.Show(title,message, MessageBoxButton.OK, MessageBoxImage.Information);
    }
    public bool Confirm(string message)
    {
        return MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
    }
}
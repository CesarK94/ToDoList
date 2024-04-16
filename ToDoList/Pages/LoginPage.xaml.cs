using ToDoList.ViewModel;

namespace ToDoList.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(Navigation);
    }

}
using ToDoList.ViewModel;

namespace ToDoList.Pages;

public partial class RegistroPage : ContentPage
{
	public RegistroPage()
	{
		InitializeComponent();
        BindingContext = new RegistroViewModel(Navigation);
    }
}
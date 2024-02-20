using ToDoList.ViewModel;

namespace ToDoList.Pages;

public partial class RegistroTareaPage : ContentPage
{
	public RegistroTareaPage(RegistroTareaViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
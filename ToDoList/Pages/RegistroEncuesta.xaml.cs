using ToDoList.ViewModel;

namespace ToDoList.Pages;

public partial class RegistroEncuesta : ContentPage
{
	public RegistroEncuesta(RegistroEncuestaViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
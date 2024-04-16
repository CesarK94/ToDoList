using ToDoList.ViewModel;

namespace ToDoList.Pages;

public partial class ToDoPage : ContentPage
{
	public ToDoPage(TodoViewModel mv)
	{
        InitializeComponent();
		BindingContext = mv;
	}

	protected override void OnAppearing()
	{
        base.OnAppearing();
		TodoViewModel mViewModel = ((TodoViewModel)BindingContext);

        if (mViewModel.AgregarTareaCommand.CanExecute(null))
		{
			mViewModel.AgregarTareaCommand.Execute(null);
		}
    }
}
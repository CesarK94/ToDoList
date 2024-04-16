using Newtonsoft.Json;
using ToDoList.ViewModel;

namespace ToDoList.Pages;

public partial class ToDoPage : ContentPage
{
	public ToDoPage(TodoViewModel mv)
	{
        InitializeComponent();
        GetProfileInfo();
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

	private void GetProfileInfo()
    {
		var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
        UserEmial.Text = userInfo.User.Email;
    }
}
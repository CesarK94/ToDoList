using ToDoList.Pages;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ValidateToken();
        }

        private async void ValidateToken()
        {
            var token = Preferences.Get("FreshFirebaseToken", "");
            if (string.IsNullOrEmpty(token))
            {
                await Shell.Current.GoToAsync(nameof(LoginPage));
                return;
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(ToDoPage));
            }
        }
    }

}

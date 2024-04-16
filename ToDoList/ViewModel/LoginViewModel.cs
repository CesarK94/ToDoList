using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Pages;

namespace ToDoList.ViewModel
{
    internal class LoginViewModel
    {
        public string webApKey = "AIzaSyA96ynqRYTGjjNIOvLcu8rMnPTqDcOncEE";
        private INavigation _navigation;
        private string userEmail;
        private string userPassword;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Command RegistroBtn { get; }
        public Command LoginBtn { get; }
        public string UserEmail
        {
            get => userEmail; set
            {
                userEmail = value;
                RaisePropertyChanged("UserEmail");
            }
        }

        public string UserPassword
        {
            get => userPassword; set
            {
                userPassword = value;
                RaisePropertyChanged("UserPassword");
            }
        }
        public LoginViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegistroBtn = new Command(RegistroBtnAsync);
            LoginBtn = new Command(LoginBtnAsync);
        }

        private async void LoginBtnAsync(object obj)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedcontent);
                await Shell.Current.GoToAsync(nameof(ToDoPage));

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                throw;
            }
        }

        private async void RegistroBtnAsync(object obj)
        {
            await Shell.Current.GoToAsync(nameof(RegistroPage));
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}

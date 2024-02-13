using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace ToDoList.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public string mensaje = "Click";
        private int count;

        public MainViewModel()
        {

        }
        [RelayCommand]
        private void Increment()
        {
            count++;
            Mensaje = $"Clicks {count} .";
        }

        [RelayCommand]
        private void StartApp()
        {
            Shell.Current.GoToAsync("TO_DO");
        }
    }
}
